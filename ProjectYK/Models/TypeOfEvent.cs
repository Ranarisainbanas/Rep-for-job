using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Models
{
    public class TypeOfEvent
    {
        public int Id { get; set; } //Id типа события
        public string Type_Text { get; set; }    //Тип события (вид деятельности)
        public string Description { get; set; }    //Описание
    }
}
