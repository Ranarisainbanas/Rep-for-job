using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Models
{
    public class Sponsor
    {
        public int ID { get; set; } //Id организатора
        public string Name { get; set; }    //Название компании
        public string Phone { get; set; }   //Телефон для свзяи с организацией
        public string Email { get; set; }   //Емейл организации
        public string Address { get; set; } //Адресс, по которому расположена компания
    }
}
