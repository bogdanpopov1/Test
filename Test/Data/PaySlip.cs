using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data
{
    public class PaySlip
    {
        public PaySlip(Person person, double commission, double revenue, int experience)
        {
            Person = person;
            Commission = commission;
            Revenue = revenue;
            Experience = experience;
        }

        public Person Person { get; set; }
        public double Commission { get; set; }
        public double Revenue { get; set; }
        public int Experience { get; set; }
    }
}
