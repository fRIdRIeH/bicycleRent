using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Forms.Inventory;
using bicycleRent.Models;
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using ZstdSharp.Unsafe;

namespace bicycleRent.Forms.Rent
{
    public partial class RentEditForm : Form
    {
        private readonly RentRepository _rentRepository;
        private readonly Models.User _user;
        private readonly MySqlConnection _connection;
        Models.Client selectedClient;
        List<int> inventoryIds = new List<int>();
        TimeSpan duration;
        decimal total = 0;
        int clientId = 0;
        int _rentIdFromMainForm;
        string _key;
        private List<int> _selectedInventoryIds = new();
        private List<int> oldInventoryIds = new();
        private Dictionary<int, int> _selectedPrices = new(); // key = InventoryId, value = InventoryPriceId
        private readonly PaymentRepository _paymentRepository;
        List<Models.Client> clients;
        Models.Rent recievedRent;

        public RentEditForm(RentRepository rentRepository, Models.User user, MySqlConnection connection, int idFormMain, string key)
        {
            InitializeComponent();
            this.TopMost = true;
            this._rentRepository = rentRepository;
            this._user = user;
            this._connection = connection;
            this._rentIdFromMainForm = idFormMain;
            this._key = key;

            _paymentRepository = new PaymentRepository(connection);

            btnEditRent.Enabled = false;

            recievedRent = _rentRepository.Get(_rentIdFromMainForm);

            LoadData();
        }

        private void RentAddForm_Load(object sender, EventArgs e)
        {
            //Установка кастомного формата для отображения и даты и времени
            dtpStart.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpEnd.CustomFormat = "dd.MM.yyyy HH:mm:ss";
        }

        private void AddInventoryCard(Models.Inventory inventory, int selectedPriceId)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1220, 130),
            };

            //
            // Ярлыки для карточки инвентаря
            //

            int invLblPosY = 10;

            //для id инвентаря
            Label lblInventoryName = new Label()
            {
                Text = $"{inventory.InventoryId} - {inventory.InventoryTypeName} {inventory.InventoryName} {inventory.InventoryNumber}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, invLblPosY),
                AutoSize = true,
            };
            //заголовок филиала
            Label lblFilial = new Label()
            {
                Text = "Пункт проката:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 35),
                AutoSize = true
            };
            //заголовок статуса инвентаря
            Label lblStatus = new Label()
            {
                Text = "Статус:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(200, 35),
                AutoSize = true
            };

            //
            // Данные филиала и статуса
            //

            //Название филиала
            Label lblFilialName = new Label()
            {
                Text = $"{inventory.FilialName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 55),
                AutoSize = true
            };
            //Статус велосипеда
            Label lblStatusName = new Label()
            {
                Text = $"{inventory.Status}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(200, 55),
                AutoSize = true
            };

            //Заголовок тарифа
            Label lblPrice = new Label()
            {
                Text = "Тариф: ",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 85),
                AutoSize = true
            };
            //combobox для тарифа
            ComboBox cbPrice = new ComboBox()
            {
                Name = "cbPrice",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(100, 82),
                Size = new Size(250, 33),
                AutoSize = true,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            //Заполнение cbPrice по inventoryId

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            var prices = _inventoryPriceRepository.GetAll(inventory.InventoryId);

            cbPrice.SelectedValueChanged += (s, e) => Count();

            cbPrice.DataSource = null;
            cbPrice.DataSource = prices;
            cbPrice.DisplayMember = "TimeName";         // Показываемое имя (например, "Свыше часа")
            cbPrice.ValueMember = "InventoryPriceId";   // Id, по которому мы будем тянуть цену для расчета

            //foreach (var price in prices)
            //    MessageBox.Show($"InventoryPriceId: {price.InventoryPriceId} — {price.TimeName}");

            //оно должно подставлять выбранный ранее тариф, но оно этого не делает
            cbPrice.SelectedValue = selectedPriceId;

            //Блокируем возможность изменять тарифы при закрытой аренде
            if(recievedRent.Status == "Закрыта")
            {
                cbPrice.Enabled = false;
            }

            //bool found = prices.Any(p => p.InventoryPriceId == selectedPriceId);
            //MessageBox.Show($"Найдено: {found} ТарифId: {selectedPriceId}");


            //Кнопка на удаление инвентаря из списка выбранных
            Button btnRemove = new Button()
            {
                Text = "❌",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Cursor = Cursors.Hand,
                Size = new Size(30, 30),
                Location = new Point(1180, 10),
            };

            // Подписка на событие нажатия
            btnRemove.Click += (sender, e) =>
            {
                flpSelectedInventory.Controls.Remove(inventoryPanel);
                // Дополнительно: если у тебя есть список с selectedInventoryIds — удаляй оттуда
                inventoryIds.Remove(inventory.InventoryId);

            };

            // Добавляем ярлыки в панель
            inventoryPanel.Controls.Add(lblInventoryName);
            inventoryPanel.Controls.Add(lblFilial);
            inventoryPanel.Controls.Add(lblStatus);
            // Добавляем данные в панель
            inventoryPanel.Controls.Add(lblFilialName);
            inventoryPanel.Controls.Add(lblStatusName);
            // Добавляем ярлык и данные для выбора тарифа
            inventoryPanel.Controls.Add(lblPrice);
            inventoryPanel.Controls.Add(cbPrice);

            cbPrice.SelectedValue = selectedPriceId;

            // Добавляем кнопку в панель
            inventoryPanel.Controls.Add(btnRemove);

            flpSelectedInventory.Controls.Add(inventoryPanel);
        }

        public void LoadData()
        {
            //заполнение combobox клиентов

            ClientRepository _clientRepository = new ClientRepository(_connection);
            clients = _clientRepository.GetAll();

            // Отображение в ComboBox
            cbClients.DataSource = null;
            cbClients.DataSource = clients;
            cbClients.DisplayMember = "Display";
            cbClients.ValueMember = "Id";
            cbClients.DropDownStyle = ComboBoxStyle.DropDown; // чтобы можно было вводить

            // Подсказки с поиском по вхождению
            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(clients.Select(c => c.Display).ToArray());

            cbClients.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbClients.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbClients.AutoCompleteCustomSource = autoSource;

            //заполнение combobox залогов

            DepositRepository _depositRepository = new DepositRepository(_connection);
            var deposits = _depositRepository.GetAll();

            cbDeposit.DataSource = null;
            cbDeposit.DataSource = deposits;
            cbDeposit.DisplayMember = "Name";
            cbDeposit.ValueMember = "Id";

            //Заполнение cbPaymentType :D

            cbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;

            cbPaymentType.Items.Add("Нал.");
            cbPaymentType.Items.Add("Безнал.");

            Models.Rent rent = _rentRepository.Get(_rentIdFromMainForm);

            //Заполнение ячеек на форме из аренды
            if (_key == "editRent")
            {
                //Заполнение списка инвентарей


                InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
                var inventoryList = _inventoryRepository.GetInventoryIdsForRent(rent.RentId);
                _selectedPrices = _rentRepository.GetSelectedPricesByRentId(rent.RentId);

                ShowSelectedInventories(inventoryList);


                //Заполнение клиента
                var client = _clientRepository.Get(rent.ClientId);

                cbClients.SelectedValue = client.Id;

                //Заполнение времени
                dtpStart.Value = rent.TimeStart;
                dtpEnd.Value = rent.TimeEnd;

            }

            //Заполнение списка оплат по аренде(если они есть)

            var payments = _paymentRepository.GetAllForRent(_rentIdFromMainForm);

            //очищаем flpPayments, чтобы оплаты не дублировались
            flpPayments.Controls.Clear();

            foreach (var payment in payments)
            {
                AddPaymentCard(payment);
            }

            //Добавляем возможность возобновить аренду, если закрыта по ошибке или прямем кнопки

            if (rent.Status == "Закрыта")
            {
                lblResume.Visible = true;
                btnResumeRent.Visible = true;
            }
            else
            {
                lblResume.Visible = false;
                btnResumeRent.Visible = false;
            }

            flpSelectedInventory.FlowDirection = FlowDirection.TopDown;
            flpSelectedInventory.WrapContents = false;
            flpSelectedInventory.AutoScroll = true;
        }

        private void cbClients_Leave(object sender, EventArgs e)
        {
            var text = cbClients.Text.ToLower();

            var matchedClient = clients
                .FirstOrDefault(c => c.Display.ToLower().Contains(text));

            if (matchedClient != null)
            {
                cbClients.SelectedItem = matchedClient;

                lblForClient.Text = $"{matchedClient.Surname} {matchedClient.Name[0]}. {matchedClient.Patronymic[0]}.";
                clientId = matchedClient.Id;
            }
            else
            {
                MessageBox.Show("Клиент не найден");
                cbClients.SelectedItem = null;
            }
        }

        private void btnChooseInventory_Click(object sender, EventArgs e)
        {
            InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
            InventorySelectForm inventorySelectForm = new InventorySelectForm(_inventoryRepository);

            //подписка на событие после открытия формы выбора
            inventorySelectForm.OnInventoriesChosen += ShowSelectedInventories;
            inventorySelectForm.ShowDialog();
        }

        private void ShowSelectedInventories(List<int> selectedIds)
        {
            InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
            inventoryIds = selectedIds;

            //foreach (int id in selectedIds)
            //{
            //    var inv = _inventoryRepository.GetInventory(id);

            //    AddInventoryCard(inv);
            //}

            foreach (int id in selectedIds)
            {
                if (!_selectedInventoryIds.Contains(id))
                    _selectedInventoryIds.Add(id); // добавляем только новые

                var inv = _inventoryRepository.GetInventory(id);
                if (_selectedPrices.TryGetValue(inv.InventoryId, out int selectedPriceId))
                {
                    //MessageBox.Show($"{inv.InventoryId} = {selectedPriceId}");
                    AddInventoryCard(inv, selectedPriceId);
                }
                else
                {
                    AddInventoryCard(inv, 0); // для новых
                }
            }
        }

        private void cbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"{cbClients.SelectedValue}");

            ClientRepository _clientRepository = new ClientRepository(_connection);

            selectedClient = cbClients.SelectedItem as Models.Client;

            lblForClient.Text = $"{selectedClient.Surname} {selectedClient.Name[0]}. {selectedClient.Patronymic[0]}.";

            clientId = selectedClient.Id;
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            Count();
        }

        public void Count()
        {
            total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                var cbPrice = inventoryPanel.Controls.OfType<ComboBox>().FirstOrDefault(cb => cb.Name == "cbPrice");
                if (cbPrice?.SelectedValue is int inventoryPriceId)
                {
                    var selectedPrice = _inventoryPriceRepository.Get(inventoryPriceId);
                    if (selectedPrice != null)
                    {
                        if (selectedPrice.TimeName.ToLower().Contains("свыше часа"))
                        {
                            total += selectedPrice.Price * totalMinutes;
                        }
                        else
                        {
                            total += selectedPrice.Price;
                        }
                    }
                }
            }

            lblForPrice.Text = $"{total} ₽";

            // Подсчёт времени
            TimeSpan duration = dtpEnd.Value - dtpStart.Value;
            lblForTimePeriod.Text = $"{totalMinutes} минут";

            btnEditRent.Enabled = true;
        }

        //private void btnCreateRent_Click(object sender, EventArgs e)
        //{
        //    string status = "";
        //    if (dtpStart.Value > DateTime.Now)
        //    {
        //        status = "Забронирована";
        //    }
        //    if (dtpStart.Value <= DateTime.Now)
        //    {
        //        status = "В процессе";
        //    }

        //    FilialRepository _filialRepository = new FilialRepository(_connection);


        //    int filialId = _filialRepository.GetFilialFromInventory(inventoryIds[0]);

        //    //Подсчет времени аренды в минутах
        //    int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

        //    //Проверка правильности заполнения 
        //    if (totalMinutes == 0) { MessageBox.Show("Введено некорректное время."); return; }
        //    if (total <= 0) { MessageBox.Show("Указана некорректная сумма."); return; }
        //    if (inventoryIds.Count == 0) { MessageBox.Show("Не выбран ни один инвентарь."); return; }
        //    if (dtpEnd.Value == dtpStart.Value) { MessageBox.Show("Время начала и время конца аренды совпадают"); return; }
        //    if (clientId == 0) { MessageBox.Show("Не выбран клиент."); return; }
        //    if (filialId == 0) { MessageBox.Show("Филиал не выбран."); return; }
        //    if (cbDeposit.SelectedValue == null) { MessageBox.Show("Залог не выбран."); return; }

        //    try
        //    {
        //        Models.Rent rent = new Models.Rent()
        //        {
        //            FilialId = filialId,
        //            ClientId = clientId,
        //            TimeStart = dtpStart.Value,
        //            TimeEnd = dtpEnd.Value,
        //            Total = total,
        //            Status = status,
        //            UserId = _user.Id,
        //            DepositId = (int)cbDeposit.SelectedValue,
        //        };

        //        _rentRepository.Add(rent);
        //        int rentId = _rentRepository.GetRentId(rent);

        //        foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
        //        {
        //            int inventoryId = (int)inventoryPanel.Tag;

        //            var cbPrice = inventoryPanel.Controls
        //                .OfType<System.Windows.Forms.ComboBox>()
        //                .FirstOrDefault(cb => cb.Name == "cbPrice");

        //            if (cbPrice?.SelectedValue == null)
        //            {
        //                MessageBox.Show($"Не выбран тариф для инвентаря с ID {inventoryId}.");
        //                continue;
        //            }

        //            int priceId = (int)cbPrice.SelectedValue;

        //            _rentRepository.AddRentHasInventory(rentId, inventoryId, priceId);
        //        }

        //        MessageBox.Show("Аренда добавлена!");
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ошибка: {ex.Message}");
        //        return;
        //    }
        //}

        private void ApplySelectedPrices()
        {
            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                if (inventoryPanel.Tag is int inventoryId &&
                    _selectedPrices.TryGetValue(inventoryId, out int selectedPriceId))
                {
                    var cbPrice = inventoryPanel.Controls
                        .OfType<ComboBox>()
                        .FirstOrDefault(cb => cb.Name == "cbPrice");

                    if (cbPrice != null)
                    {
                        cbPrice.BeginInvoke((MethodInvoker)(() =>
                        {
                            cbPrice.SelectedValue = selectedPriceId;
                        }));
                    }
                }
            }
        }

        private void RentEditForm_Shown(object sender, EventArgs e)
        {
            ApplySelectedPrices();

            oldInventoryIds = getInventoryId();

            Count();
        }
        private List<int> getInventoryId()
        {
            var list = new List<int>();

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                int inventoryId = (int)inventoryPanel.Tag;

                list.Add(inventoryId);
            }
            return list;
        }

        //
        // Добавление оплаты, запись в бд
        //
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (numPaymentAmount.Value == 0) { MessageBox.Show("Введите сумму оплаты."); return; }
            if (cbPaymentType.SelectedItem.ToString() == "") { MessageBox.Show("Выберите тип оплаты."); return; }

            try
            {
                Payment payment = new Payment()
                {
                    PaymentAmount = numPaymentAmount.Value,
                    Type = (string)cbPaymentType.SelectedItem,
                    RentId = _rentIdFromMainForm,
                    Created_At = DateTime.Now,
                };

                _paymentRepository.Add(payment);
                AddPaymentCard(payment);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}"); return;
            }


        }

        private void btnCreateRent_Click_1(object sender, EventArgs e)
        {
            //
            // Получаем список новых id инвентарей
            //

            var newInventoryId = getInventoryId();

            if (flpSelectedInventory.Controls.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одного инвентаря."); return;
            }

            //
            // Апдейтим данные самой аренды
            //
            string status = "";
            if (dtpStart.Value > DateTime.Now)
            {
                status = "Забронирована";
            }
            if (dtpStart.Value <= DateTime.Now)
            {
                status = "В процессе";
            }

            FilialRepository _filialRepository = new FilialRepository(_connection);

            int filialId = _filialRepository.GetFilialFromInventory(inventoryIds.Last());

            //Подсчет времени аренды в минутах
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            //Проверка правильности заполнения 
            if (totalMinutes == 0) { MessageBox.Show("Введено некорректное время."); return; }
            if (total <= 0) { MessageBox.Show("Указана некорректная сумма."); return; }
            if (inventoryIds.Count == 0) { MessageBox.Show("Не выбран ни один инвентарь."); return; }
            if (dtpEnd.Value == dtpStart.Value) { MessageBox.Show("Время начала и время конца аренды совпадают"); return; }
            if (clientId == 0) { MessageBox.Show("Не выбран клиент."); return; }
            if (filialId == 0) { MessageBox.Show("Филиал не выбран."); return; }
            if (cbDeposit.SelectedValue == null) { MessageBox.Show("Залог не выбран."); return; }

            try
            {
                Models.Rent rent = new Models.Rent()
                {
                    RentId = _rentIdFromMainForm,
                    FilialId = filialId,
                    ClientId = clientId,
                    TimeStart = dtpStart.Value,
                    TimeEnd = dtpEnd.Value,
                    Total = total,
                    Status = status,
                    UserId = _user.Id,
                    DepositId = (int)cbDeposit.SelectedValue,
                };

                //Вносим изменения в аренду
                _rentRepository.Update(rent);

                //Получение списка инвентаря на удаление из Rent_Has_Inventory
                List<int> idToRemove = oldInventoryIds.Except(newInventoryId).ToList();
                //Получение списка инвентаря на добавление в Rent_Has_Inventory
                List<int> idToAdd = newInventoryId.Except(oldInventoryIds).ToList();

                //Удаление старых привязанных единиц инвентаря
                foreach (var id in idToRemove)
                {
                    _rentRepository.DeleteRentHasInventory(_rentIdFromMainForm, id);
                }

                //Добавление новых единиц инвентаря
                foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
                {
                    int inventoryId = (int)inventoryPanel.Tag;

                    var cbPrice = inventoryPanel.Controls.OfType<ComboBox>().FirstOrDefault(cb => cb.Name == "cbPrice");

                    foreach (var id in idToAdd)
                    {
                        if (inventoryId == id)
                        {
                            if (cbPrice?.SelectedValue == null)
                            {
                                MessageBox.Show($"Не выбран тариф для инвентаря с ID {inventoryId}.");
                                continue;
                            }

                            int priceId = (int)cbPrice.SelectedValue;

                            _rentRepository.AddRentHasInventory(_rentIdFromMainForm, id, priceId);
                        }
                    }

                    // Проверяем, что этот inventoryId уже был в базе
                    if (!_selectedPrices.ContainsKey(inventoryId))
                        continue;

                    if (cbPrice?.SelectedValue == null)
                        continue;

                    int currentPriceId = (int)cbPrice.SelectedValue;
                    int originalPriceId = _selectedPrices[inventoryId];

                    if (currentPriceId != originalPriceId)
                    {
                        // Цена изменилась, обновляем в базе
                        _rentRepository.UpdateRеntHasInventory(_rentIdFromMainForm, inventoryId, currentPriceId);
                    }
                }

                MessageBox.Show("Аренда обновлена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
        }

        private void AddPaymentCard(Payment payment)
        {
            Panel paymentPanel = new Panel()
            {
                Tag = payment.Id,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(360, 60)
            };

            //Ярлык

            Label lblPaymentAmount = new Label()
            {
                Text = $"Сумма: {payment.PaymentAmount}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(5, 5),
                AutoSize = true
            };

            Label lblPaymenttype = new Label()
            {
                Text = $"Тип: {payment.Type}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(150, 5),
                AutoSize = true
            };

            Label lblCreatedAt = new Label()
            {
                Text = $"Добавлено: {payment.Created_At}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(5, 30),
                AutoSize = true
            };

            Button btnRemove = new Button()
            {
                Text = "❌",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Location = new Point(305, 5),
            };

            // Подписка на событие нажатия по удалению оплаты
            btnRemove.Click += (sender, e) =>
            {
                //Удаление из БД

                if (paymentPanel.Tag is int paymentId)
                {
                    if (_paymentRepository.Delete(paymentId))
                    {
                        flpPayments.Controls.Remove(paymentPanel);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить оплату из базы данных.");
                    }
                }

            };

            //Добавляем элементы в панель
            paymentPanel.Controls.Add(lblPaymentAmount);
            paymentPanel.Controls.Add(lblPaymenttype);
            paymentPanel.Controls.Add(lblCreatedAt);
            paymentPanel.Controls.Add(btnRemove);

            flpPayments.Controls.Add(paymentPanel);
        }

        //закрытие аренды с сохранением и подсчетом
        private void btnCloseRent_Click(object sender, EventArgs e)
        {
            //Меняем статус аренды на "закрыта"
            _rentRepository.ChangeRentStatus(_rentIdFromMainForm, "Закрыта");

            //Меняем статусы привязанных инвентарей на "Свободен"
            InventoryRepository inventoryRepository = new InventoryRepository(_connection);
            var inventoryIds = inventoryRepository.GetInventoryIdsForRent(_rentIdFromMainForm);

            foreach (var inventoryId in inventoryIds)
            {
                inventoryRepository.ChangeInventoryStatus(inventoryId, "Свободен");
            }

            total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                var cbPrice = inventoryPanel.Controls
                    .OfType<ComboBox>()
                    .FirstOrDefault(cb => cb.Name == "cbPrice");

                if (cbPrice?.SelectedValue is int inventoryPriceId &&
                    inventoryPanel.Tag is int inventoryId)
                {
                    var selectedPrice = _inventoryPriceRepository.Get(inventoryPriceId);

                    if (selectedPrice != null)
                    {
                        int priceTotal;

                        if (selectedPrice.TimeName.ToLower().Contains("свыше часа"))
                            priceTotal = (int)(selectedPrice.Price * totalMinutes);
                        else
                            priceTotal = (int)selectedPrice.Price;

                        inventoryRepository.ChangeRentsCountAndTotal(inventoryId, priceTotal, 1);

                        total += priceTotal;
                    }
                }
            }


            MessageBox.Show("Аренда закрыта.");
            this.Close();
        }

        private void btnResumeRent_Click(object sender, EventArgs e)
        {
            //Меняем статус аренды на "В процессе
            _rentRepository.ChangeRentStatus(_rentIdFromMainForm, "В процессе");

            //Меняем статусы привязанных инвентарей на "В аренде
            InventoryRepository inventoryRepository = new InventoryRepository(_connection);
            var inventoryIds = inventoryRepository.GetInventoryIdsForRent(_rentIdFromMainForm);

            foreach (var inventoryId in inventoryIds)
            {
                inventoryRepository.ChangeInventoryStatus(inventoryId, "В аренде");
            }

            //Уменьшаем Inventory_Rents_Count и Inventory_Total на теже значения, на которые прибавили 
            total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                var cbPrice = inventoryPanel.Controls
                    .OfType<ComboBox>()
                    .FirstOrDefault(cb => cb.Name == "cbPrice");

                if (cbPrice?.SelectedValue is int inventoryPriceId &&
                    inventoryPanel.Tag is int inventoryId)
                {
                    var selectedPrice = _inventoryPriceRepository.Get(inventoryPriceId);

                    if (selectedPrice != null)
                    {
                        int priceTotal;

                        if (selectedPrice.TimeName.ToLower().Contains("свыше часа"))
                            priceTotal = (int)(selectedPrice.Price * totalMinutes);
                        else
                            priceTotal = (int)selectedPrice.Price;

                        inventoryRepository.ChangeRentsCountAndTotal(inventoryId, -priceTotal, -1);

                        total += priceTotal;
                    }
                }
            }

            MessageBox.Show("Аренда возобновлена.");
            this.Close();
        }
    }
}
