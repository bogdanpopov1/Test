using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data
{
    public static class DB_Connection
    {
        public static List <Person> people = new List <Person> ()
        {
            new Person(10153, "Чупашева", "Августина", "Ивановна", new DateTime(2015, 10, 1)),
            new Person(20174, "Иванов", "Андрей", "Валерьевич", new DateTime(2017, 1, 10)),
            new Person(30191, "Кривцов", "Олег", "Павлович", new DateTime(2019, 2, 5)),
            new Person(40140, "Янаева", "Элина", "Станиславовна", new DateTime(2014, 12, 15)),
        };

        public static List<Person> GetPeople()
        {
            return people;
        }
    }
}
