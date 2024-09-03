using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Person
    {
        public Person(int shopId, string surname, string name, string patronymic, DateTime getWorkDate)
        {
            _shopId = shopId;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            GetWorkDate = getWorkDate;
            FullName = $"{surname} {name.First()}.{patronymic.First()}.";
        }

        private int _shopId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get; set; }
        public DateTime GetWorkDate { get; set; }


    }
}
