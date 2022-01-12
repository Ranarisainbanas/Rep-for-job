using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYK.Models
{
    public class Event
    {
        public int Id { get; set; } //Id события
        public int Spon_Id { get; set; }  //Id организатора        
        public int Type_Id { get; set; }   //Id типа события        
        public string Name { get; set; }    //Название события
        public string Description { get; set; } //Описание события
        public int Place_Id { get; set; }   //Id места проведения события        
        public string Address { get; set; } //Точный адрес проведения мероприятия
        public DateTime Start_Time { get; set; }    //Время начала
        public DateTime Finish_Time { get; set; }   //Время завершения
        public DateTime Start_Day { get; set; } //День начала события
        public int Recurs { get; set; }    //Тип повторения: 0 - без повторения, 1 - ежедневно, 2 - еженедельно, 3 - ежемесечно
        //Если Recurs = 0 , то поля ниже тоже = 0, кроме даты завершения события - она равна дате начала
        public int Recurs_Interval { get; set; }  //Интервал между повторяющимеся событиями
        /*Интервал между повторяющимеся событиями указывает на периодичность события относительно выбраного типа вповторения,
         Например, каждые 3 дня - Recurs=1, Recurs_Interval=3;
        каждые 2 недели - Recurs=2, Recurs_Interval=2;
        каждые 4 месяца - Recurs=3, Recurs_Interval=4.*/
        public int Recurs_Day_Number { get; set; } //Тип повторения, при котором задается число месяца. Используется только при Recurs=3, иначе значение 0. Например, 13го числа каждого месяца - Recurs=3, Recurs_Interval=1, Recurs_Day_Number=13
        public int Recurs_Serial_Day { get; set; } //Тип повторения, при котором задается порядковый номер дня месяца: 1 - первый; 2 - второй; 3 - третий; 4 - четвертый; 5 - последний.
        public int Recurs_Day_of_Week { get; set; }    //Дни недели. 1 - Воскресенье, 2 - Понедельник, 4 - Вторник, 8 - Среда, 16 - Четверг, 32 - Пятница, 64 - Суббота.
        /* Recurs_Day_of_Week может использоваться для еженедльных событий (во вторник раз в 2 недели - Recurs=2, Recurs_Interval=2, Recurs_Day_of_Week= 4),
         либо для ежемесечных событий с указанием порядкового номера дня месяца.         
            Recurs_Serial_Day используется в сочетании с Recurs_Day_of_Week,
         например: каждые 2 месяца в последний четверг месяца - Recurs=3, Recurs_Interval=2, Recurs_Serial_Day=5, Recurs_Day_of_Week=16*/
        public DateTime Finish_Day { get; set; }    //Дата завершения мероприятия. Если мероприятие повторяющееся, то указывается день, после которого событие больше не произойдет. Если мероприятие разовое, то это тот же день, что и день начала

        //связи
        public Sponsor Sponsor { get; set; }
        public Type Type { get; set; }
        public Place Place { get; set; }
    }
}
