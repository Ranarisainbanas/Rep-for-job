using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Models
{
    public class Place
    {
        public int Id { get; set; } //Id места проведения события
        public string Name { get; set; }    //Название места - область проведения мероприятия (например: озеро Байкал, Новосибирская область, Золотое кольцо, Шерегеш, Горный Алтай, Кузнецкий Алатау и т.п)
    }
}
