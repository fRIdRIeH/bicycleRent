-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Май 20 2025 г., 01:23
-- Версия сервера: 10.8.4-MariaDB
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `bicycleRentFQW`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Client`
--

CREATE TABLE `Client` (
  `Client_Id` int(11) NOT NULL,
  `Client_Surname` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Client_Name` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Client_Patronymic` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Client_Telephone` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Client_Address` varchar(127) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Client_Features` varchar(127) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Client_Visit_Count` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Client`
--

INSERT INTO `Client` (`Client_Id`, `Client_Surname`, `Client_Name`, `Client_Patronymic`, `Client_Telephone`, `Client_Address`, `Client_Features`, `Client_Visit_Count`) VALUES
(1, 'Ворончихин', 'Николай', 'Батькович', '89991111111', 'деревня блин', 'Коля)', 0),
(2, 'Панин', 'Василий', 'Батькович', '89992222222', 'г. Ижевск', 'Вася)', 0),
(4, 'Макаров', 'Александр', 'Александрович', '89993333333', 'г. Ижевск - г. Москва', 'Санёчек)', 0),
(5, 'Ворончихин', 'Николай', 'Батькович', '89991111111', 'деревня блин', 'Коля)', 0),
(6, 'Панин', 'Василий', 'Батькович', '89992222222', 'г. Ижевск', 'Вася)', 0),
(7, 'Макаров', 'Александр', 'Александрович', '89993333333', 'г. Ижевск - г. Москва', 'Санечек)', 0),
(8, 'Смирнова', 'Елена', 'Петровна', '89994444444', 'г. Казань', 'Лена)', 0),
(9, 'Иванов', 'Иван', 'Иванович', '89995555555', 'г. Самара', 'Ваня)', 0),
(10, 'Кузнецова', 'Мария', 'Сергеевна', '89996666666', 'г. Уфа', 'Маша)', 0),
(11, 'Сидоров', 'Дмитрий', 'Олегович', '89997777777', 'г. Пермь', 'Димон)', 0),
(12, 'Петров', 'Сергей', 'Анатольевич', '89998880001', 'г. Екатеринбург', 'Серёга)', 0),
(13, 'Лебедева', 'Ольга', 'Викторовна', '89998880002', 'г. Новосибирск', 'Оля)', 0),
(14, 'Киселёв', 'Артём', 'Ильич', '89998880003', 'г. Красноярск', 'Тёма)', 0),
(15, 'Громова', 'Дарья', 'Александровна', '89998880004', 'г. Тюмень', 'Даша)', 0),
(16, 'Морозов', 'Павел', 'Сергеевич', '89998880005', 'г. Нижний Новгород', 'Паша)', 0),
(17, 'Федорова', 'Анна', 'Максимовна', '89998880006', 'г. Волгоград', 'Анюта)', 0),
(18, 'Зайцев', 'Роман', 'Алексеевич', '89998880007', 'г. Омск', 'Рома)', 0),
(19, 'Соколова', 'Екатерина', 'Романовна', '89998880008', 'г. Челябинск', 'Катя)', 0),
(20, 'Васильев', 'Егор', 'Юрьевич', '89998880009', 'г. Ульяновск', 'Ёжик)', 0),
(21, 'Тимофеева', 'Инна', 'Львовна', '89998880010', 'г. Саратов', 'Иннуська)', 0),
(22, 'цукцукцу', 'кцукцук', 'кцукцук', '89991234567', 'кцукцук', 'кцукцук', 0),
(23, 'ыыыыыыы', 'ыыыыыыы', 'ыыыыыыы', '453234534543', 'ыыыыыыы', 'ыыыыыыы', 0),
(222224, 'ооооооо', 'ооооооо', 'ооооооо', '34534534534', 'ооооооо', 'ооооооо', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Deposit`
--

CREATE TABLE `Deposit` (
  `Deposit_Id` int(11) NOT NULL,
  `Deposit_Name` varchar(11) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Deposit`
--

INSERT INTO `Deposit` (`Deposit_Id`, `Deposit_Name`) VALUES
(1, 'ВУ'),
(2, 'Паспорт'),
(3, 'ПУ'),
(4, 'ДЗ'),
(5, 'GOYDA');

-- --------------------------------------------------------

--
-- Структура таблицы `Filial`
--

CREATE TABLE `Filial` (
  `Filial_Id` int(11) NOT NULL,
  `Filial_Name` varchar(31) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Filial_Address` varchar(127) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Filial_Total` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Filial`
--

INSERT INTO `Filial` (`Filial_Id`, `Filial_Name`, `Filial_Address`, `Filial_Total`) VALUES
(1, 'Набережная', 'Ул. Милиционная', 0);

-- --------------------------------------------------------

--
-- Структура таблицы `Inventory`
--

CREATE TABLE `Inventory` (
  `Inventory_Id` int(11) NOT NULL,
  `Inventory_Name` varchar(34) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Inventory_Type_Id` int(11) NOT NULL,
  `Inventory_Number` int(11) NOT NULL,
  `Inventory_Rents_Count` int(11) NOT NULL DEFAULT 0,
  `Inventory_Total` int(11) NOT NULL DEFAULT 0,
  `Status` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT 'Свободен',
  `Filial_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Inventory`
--

INSERT INTO `Inventory` (`Inventory_Id`, `Inventory_Name`, `Inventory_Type_Id`, `Inventory_Number`, `Inventory_Rents_Count`, `Inventory_Total`, `Status`, `Filial_Id`) VALUES
(1, 'Forward', 1, 1, 1, 500, 'Свободен', 1),
(2, 'Forward', 2, 2, 0, 0, 'Свободен', 1),
(3, 'Stels', 2, 3, 0, 0, 'Свободен', 1),
(4, 'Stels', 2, 4, 0, 0, 'Свободен', 1),
(5, 'Gt', 2, 5, 0, 0, 'Свободен', 1),
(6, 'Forward черный', 2, 6, 1, 300, 'Свободен', 1),
(7, 'Forward черный', 2, 7, 1, 190, 'Свободен', 1),
(8, 'Kugoo m2', 2, 8, 1, 500, 'Свободен', 1),
(9, 'Kugoo m2 PRO', 2, 9, 0, 0, 'Свободен', 1),
(11, 'Xiaomi Mijia m365', 2, 10, 0, 0, 'Свободен', 1),
(13, 'GT белый', 1, 11, 0, 0, 'Свободен', 1),
(14, 'GT белый', 1, 12, 0, 0, 'Свободен', 1),
(15, 'GT Fatbike черный', 1, 13, 0, 0, 'Свободен', 1),
(16, 'GT Fatbike черный', 1, 14, 0, 0, 'Свободен', 1);

-- --------------------------------------------------------

--
-- Структура таблицы `Inventory_Price`
--

CREATE TABLE `Inventory_Price` (
  `Inventory_Price_Id` int(11) NOT NULL,
  `Price_Id` int(11) NOT NULL,
  `Time_Id` int(11) NOT NULL,
  `Inventory_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Inventory_Price`
--

INSERT INTO `Inventory_Price` (`Inventory_Price_Id`, `Price_Id`, `Time_Id`, `Inventory_Id`) VALUES
(1, 1, 1, 1),
(2, 2, 2, 1),
(3, 3, 3, 1),
(4, 4, 4, 1),
(5, 5, 5, 1),
(6, 1, 1, 2),
(7, 2, 2, 2),
(8, 3, 3, 2),
(9, 4, 4, 2),
(10, 5, 5, 2),
(11, 1, 1, 3),
(12, 2, 2, 3),
(13, 3, 3, 3),
(14, 4, 4, 3),
(15, 5, 5, 3),
(16, 1, 1, 4),
(17, 2, 2, 4),
(18, 3, 3, 4),
(19, 4, 4, 4),
(20, 5, 5, 4),
(21, 1, 1, 5),
(22, 2, 2, 5),
(23, 3, 3, 5),
(24, 4, 4, 5),
(25, 5, 5, 5),
(26, 1, 1, 6),
(27, 2, 2, 6),
(28, 3, 3, 6),
(29, 4, 4, 6),
(30, 5, 5, 6),
(31, 1, 1, 7),
(32, 2, 2, 7),
(33, 3, 3, 7),
(34, 4, 4, 7),
(36, 5, 5, 7),
(37, 6, 6, 1),
(38, 6, 1, 8),
(39, 6, 1, 9),
(40, 7, 7, 11),
(41, 6, 1, 11),
(42, 4, 2, 11),
(43, 8, 5, 11),
(44, 9, 4, 11);

-- --------------------------------------------------------

--
-- Структура таблицы `Inventory_Type`
--

CREATE TABLE `Inventory_Type` (
  `Inventory_Type_Id` int(11) NOT NULL,
  `Inventory_Type_Name` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Inventory_Type`
--

INSERT INTO `Inventory_Type` (`Inventory_Type_Id`, `Inventory_Type_Name`) VALUES
(1, 'Горный'),
(2, 'Электросамокат'),
(3, 'Веломобиль'),
(4, 'Электроскутер'),
(5, 'Прогулочный'),
(6, 'Тандем');

-- --------------------------------------------------------

--
-- Структура таблицы `Payment`
--

CREATE TABLE `Payment` (
  `Payment_Id` int(11) NOT NULL,
  `Payment_Amount` decimal(10,2) NOT NULL,
  `Type` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Rent_Id` int(11) NOT NULL,
  `Created_At` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `Price`
--

CREATE TABLE `Price` (
  `Price_Id` int(11) NOT NULL,
  `Amount` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Price`
--

INSERT INTO `Price` (`Price_Id`, `Amount`) VALUES
(1, '190.00'),
(2, '300.00'),
(3, '6.00'),
(4, '800.00'),
(5, '1000.00'),
(6, '500.00'),
(7, '250.00'),
(8, '2000.00'),
(9, '1500.00');

-- --------------------------------------------------------

--
-- Структура таблицы `Rent`
--

CREATE TABLE `Rent` (
  `Rent_Id` int(11) NOT NULL,
  `Filial_Id` int(11) NOT NULL,
  `Client_Id` int(11) NOT NULL,
  `Time_Start` datetime NOT NULL,
  `Time_End` datetime NOT NULL,
  `Total` int(11) NOT NULL,
  `Status` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Id` int(11) NOT NULL,
  `Deposit_Id` int(11) NOT NULL,
  `Created_At` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Rent`
--

INSERT INTO `Rent` (`Rent_Id`, `Filial_Id`, `Client_Id`, `Time_Start`, `Time_End`, `Total`, `Status`, `User_Id`, `Deposit_Id`, `Created_At`) VALUES
(35, 1, 1, '2025-05-09 18:19:03', '2025-05-09 19:19:03', 300, 'Закрыта', 1, 1, '2025-05-09 17:19:16'),
(38, 1, 1, '2025-05-10 22:00:21', '2025-05-10 23:00:21', 490, 'Закрыта', 1, 1, '2025-05-10 21:00:42'),
(39, 1, 1, '2025-05-10 22:02:56', '2025-05-10 23:02:56', 490, 'Закрыта', 1, 1, '2025-05-10 21:03:09'),
(40, 1, 1, '2025-05-11 19:57:39', '2025-05-11 21:57:39', 500, 'Закрыта', 1, 1, '2025-05-11 18:57:50');

-- --------------------------------------------------------

--
-- Структура таблицы `Rent_has_Inventory`
--

CREATE TABLE `Rent_has_Inventory` (
  `Id` int(11) NOT NULL,
  `Rent_Rent_Id` int(11) NOT NULL,
  `Inventory_Inventory_Id` int(11) NOT NULL,
  `Selected_Price_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Rent_has_Inventory`
--

INSERT INTO `Rent_has_Inventory` (`Id`, `Rent_Rent_Id`, `Inventory_Inventory_Id`, `Selected_Price_Id`) VALUES
(15, 35, 6, 27),
(23, 38, 7, 32),
(24, 38, 6, 26),
(25, 39, 7, 31),
(26, 39, 6, 27),
(27, 40, 1, 37);

-- --------------------------------------------------------

--
-- Структура таблицы `Time`
--

CREATE TABLE `Time` (
  `Time_Id` int(11) NOT NULL,
  `Time_Label` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `Time`
--

INSERT INTO `Time` (`Time_Id`, `Time_Label`) VALUES
(1, '30 минут'),
(2, '1 час'),
(3, 'свыше часа'),
(4, 'день/ночь'),
(5, 'сутки'),
(6, '2ч спец.'),
(7, '15 минут');

-- --------------------------------------------------------

--
-- Структура таблицы `User`
--

CREATE TABLE `User` (
  `User_Id` int(11) NOT NULL,
  `User_Surname` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Name` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Patronymic` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Telephone` varchar(12) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Address` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Role` varchar(127) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Login` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL,
  `User_Password` varchar(17) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `User`
--

INSERT INTO `User` (`User_Id`, `User_Surname`, `User_Name`, `User_Patronymic`, `User_Telephone`, `User_Address`, `User_Role`, `User_Login`, `User_Password`) VALUES
(1, 'Admin', 'Admin', 'Admin', '89124665480', 'г. Ижевск', 'Администратор', '1', '1'),
(2, 'Валиуллин', 'Владислав', 'Анатольевич', '89124665480', 'г. Ижевск', 'Менеджер', '2', '2');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Client`
--
ALTER TABLE `Client`
  ADD PRIMARY KEY (`Client_Id`);

--
-- Индексы таблицы `Deposit`
--
ALTER TABLE `Deposit`
  ADD PRIMARY KEY (`Deposit_Id`);

--
-- Индексы таблицы `Filial`
--
ALTER TABLE `Filial`
  ADD PRIMARY KEY (`Filial_Id`);

--
-- Индексы таблицы `Inventory`
--
ALTER TABLE `Inventory`
  ADD PRIMARY KEY (`Inventory_Id`),
  ADD KEY `Inventory_Type_Id` (`Inventory_Type_Id`),
  ADD KEY `fk_inventory_filial` (`Filial_Id`);

--
-- Индексы таблицы `Inventory_Price`
--
ALTER TABLE `Inventory_Price`
  ADD PRIMARY KEY (`Inventory_Price_Id`),
  ADD KEY `Price_Id` (`Price_Id`),
  ADD KEY `Time_Id` (`Time_Id`),
  ADD KEY `fk_Inventory_Price_Inventory1_idx` (`Inventory_Id`);

--
-- Индексы таблицы `Inventory_Type`
--
ALTER TABLE `Inventory_Type`
  ADD PRIMARY KEY (`Inventory_Type_Id`);

--
-- Индексы таблицы `Payment`
--
ALTER TABLE `Payment`
  ADD PRIMARY KEY (`Payment_Id`),
  ADD KEY `Rent_Id` (`Rent_Id`);

--
-- Индексы таблицы `Price`
--
ALTER TABLE `Price`
  ADD PRIMARY KEY (`Price_Id`);

--
-- Индексы таблицы `Rent`
--
ALTER TABLE `Rent`
  ADD PRIMARY KEY (`Rent_Id`),
  ADD KEY `Filial_Id` (`Filial_Id`),
  ADD KEY `Client_Id` (`Client_Id`),
  ADD KEY `User_Id` (`User_Id`),
  ADD KEY `Deposit_Id` (`Deposit_Id`);

--
-- Индексы таблицы `Rent_has_Inventory`
--
ALTER TABLE `Rent_has_Inventory`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_Rent_has_Inventory_Inventory1_idx` (`Inventory_Inventory_Id`),
  ADD KEY `fk_Rent_has_Inventory_Rent1_idx` (`Rent_Rent_Id`);

--
-- Индексы таблицы `Time`
--
ALTER TABLE `Time`
  ADD PRIMARY KEY (`Time_Id`);

--
-- Индексы таблицы `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`User_Id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Client`
--
ALTER TABLE `Client`
  MODIFY `Client_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=222225;

--
-- AUTO_INCREMENT для таблицы `Deposit`
--
ALTER TABLE `Deposit`
  MODIFY `Deposit_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `Filial`
--
ALTER TABLE `Filial`
  MODIFY `Filial_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `Inventory`
--
ALTER TABLE `Inventory`
  MODIFY `Inventory_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT для таблицы `Inventory_Price`
--
ALTER TABLE `Inventory_Price`
  MODIFY `Inventory_Price_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- AUTO_INCREMENT для таблицы `Inventory_Type`
--
ALTER TABLE `Inventory_Type`
  MODIFY `Inventory_Type_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `Payment`
--
ALTER TABLE `Payment`
  MODIFY `Payment_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `Price`
--
ALTER TABLE `Price`
  MODIFY `Price_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `Rent`
--
ALTER TABLE `Rent`
  MODIFY `Rent_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT для таблицы `Rent_has_Inventory`
--
ALTER TABLE `Rent_has_Inventory`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT для таблицы `Time`
--
ALTER TABLE `Time`
  MODIFY `Time_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `User`
--
ALTER TABLE `User`
  MODIFY `User_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Inventory`
--
ALTER TABLE `Inventory`
  ADD CONSTRAINT `fk_inventory_filial` FOREIGN KEY (`Filial_Id`) REFERENCES `Filial` (`Filial_Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`Inventory_Type_Id`) REFERENCES `Inventory_Type` (`Inventory_Type_Id`);

--
-- Ограничения внешнего ключа таблицы `Inventory_Price`
--
ALTER TABLE `Inventory_Price`
  ADD CONSTRAINT `fk_Inventory_Price_Inventory1` FOREIGN KEY (`Inventory_Id`) REFERENCES `Inventory` (`Inventory_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `inventory_price_ibfk_2` FOREIGN KEY (`Price_Id`) REFERENCES `Price` (`Price_Id`),
  ADD CONSTRAINT `inventory_price_ibfk_3` FOREIGN KEY (`Time_Id`) REFERENCES `Time` (`Time_Id`);

--
-- Ограничения внешнего ключа таблицы `Payment`
--
ALTER TABLE `Payment`
  ADD CONSTRAINT `payment_ibfk_1` FOREIGN KEY (`Rent_Id`) REFERENCES `Rent` (`Rent_Id`);

--
-- Ограничения внешнего ключа таблицы `Rent`
--
ALTER TABLE `Rent`
  ADD CONSTRAINT `rent_ibfk_1` FOREIGN KEY (`Filial_Id`) REFERENCES `Filial` (`Filial_Id`),
  ADD CONSTRAINT `rent_ibfk_2` FOREIGN KEY (`Client_Id`) REFERENCES `Client` (`Client_Id`),
  ADD CONSTRAINT `rent_ibfk_4` FOREIGN KEY (`User_Id`) REFERENCES `User` (`User_Id`),
  ADD CONSTRAINT `rent_ibfk_5` FOREIGN KEY (`Deposit_Id`) REFERENCES `Deposit` (`Deposit_Id`);

--
-- Ограничения внешнего ключа таблицы `Rent_has_Inventory`
--
ALTER TABLE `Rent_has_Inventory`
  ADD CONSTRAINT `fk_Rent_has_Inventory_Inventory1` FOREIGN KEY (`Inventory_Inventory_Id`) REFERENCES `Inventory` (`Inventory_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Rent_has_Inventory_Rent1` FOREIGN KEY (`Rent_Rent_Id`) REFERENCES `Rent` (`Rent_Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
