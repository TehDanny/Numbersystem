using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbersystem
{
    class StoreCounter
    {
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        private Customer currentCustomer;

        public Customer CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; }
        }
        public bool Available { get; set; }
        public static int NextCustomerNumber = 1;

        public StoreCounter()
        {
            this.Available = true;
        }
    }
}
