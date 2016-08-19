using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbersystem
{
    class Customer
    {
        public static int NextNumber = 1;
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private int counterTime;

        public int CounterTime
        {
            get { return counterTime; }
        }

        public Customer()
        {
            number = NextNumber;
            NextNumber++;
            counterTime = new Random().Next(3000, 7000);
        }
    }
}
