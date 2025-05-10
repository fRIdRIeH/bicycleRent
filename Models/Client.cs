using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Features { get; set; }
        public int VisitCount { get; set; }

        public Client() { }

        public Client(int id, string surname, string name, string patronymic, string telephone, string address, string features, int visitCount)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Telephone = telephone;
            Address = address;
            Features = features;
            VisitCount = visitCount;
        }

        public string Display => $"{Surname} {Name} {Patronymic} т. {Telephone}";

    }
}
