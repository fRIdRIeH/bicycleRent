using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User() { }

        //Для получения
        public User(int id, string surname, string name, string patronymic, string telephone, string address, string role, string login, string password)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Telephone = telephone;
            Address = address;
            Role = role;
            Login = login;
            Password = password;
        }

        //Для добавления
        public User(string surname, string name, string patronymic, string telephone, string address, string role, string login, string password)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Telephone = telephone;
            Address = address;
            Role = role;
            Login = login;
            Password = password;
        }

        //Авторизация
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public User(int id, string surname, string name, string patronymic, string telephone, string address, string role)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Telephone = telephone;
            Address = address;
            Role = role;
        }
    }
}
