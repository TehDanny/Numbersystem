using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Numbersystem
{
    class Program
    {
        private List<StoreCounter> storeCounterList;
        private List<Customer> customerList;

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            storeCounterList = new List<StoreCounter>()
            {
                new StoreCounter() {Number = 1 },
                new StoreCounter() {Number = 2 },
                new StoreCounter() {Number = 3 }
            };
            customerList = new List<Customer>();

            Thread FirstCounterThread = new Thread(() => SimulateCounter(storeCounterList[0]));
            FirstCounterThread.Start();

            Thread SecondCounterThread = new Thread(() => SimulateCounter(storeCounterList[1]));
            SecondCounterThread.Start();

            Thread ThirdCounterThread = new Thread(() => SimulateCounter(storeCounterList[2]));
            ThirdCounterThread.Start();

            Thread NewCustomersThread = new Thread(new ThreadStart(AddNewCustomers));
            NewCustomersThread.Start();
        }

        private void SimulateCounter(StoreCounter currentCounter)
        {
            Customer nextCustomer;
            while (true)
            {
                if (currentCounter.Available == true)
                {
                    nextCustomer = CheckForNextCustomer();
                    if (nextCustomer != null)
                    {
                        StoreCounter.NextCustomerNumber++;
                        currentCounter.CurrentCustomer = nextCustomer;
                        Console.WriteLine("Kasse {0} ekspederer nu kunde med kundenummer {1}.", currentCounter.Number, currentCounter.CurrentCustomer.Number);
                        Thread.Sleep(currentCounter.CurrentCustomer.CounterTime);
                        customerList.Remove(currentCounter.CurrentCustomer);
                        Console.WriteLine("Kasse {0} er nu ledig med kundenummer {1}.", currentCounter.Number, StoreCounter.NextCustomerNumber);
                    }
                }
                Thread.Sleep(100); // waiting for new customers
            }
        }

        private Customer CheckForNextCustomer()
        {
            Customer nextCustomer;
            foreach (var customer in customerList)
            {
                if (customer.Number == StoreCounter.NextCustomerNumber)
                {
                    nextCustomer = customer;
                    return nextCustomer;
                }
            }
            nextCustomer = null;
            return nextCustomer;
        }

        private void AddNewCustomers()
        {
            while (true)
            {
                Customer customer = new Customer();
                customerList.Add(customer);
                Console.WriteLine("En ny kunde trækker nummer {0}.", customer.Number);
                int timeUntilNextCustomer = new Random().Next(500, 3000);
                Thread.Sleep(timeUntilNextCustomer);
            }
        }
    }
}
