using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Safor.Services;
using Safor.Services.Models;

namespace Safor.App.Contracts.UI
{
    public class CustomerUI
    {
        public Customer CustomerMenu()
        {
            Customer customer = new Customer();
            Console.WriteLine("Scegli l'operazione: ");
            Console.WriteLine("Premi N per creare un nuovo cliente");
            Console.WriteLine("Premi C per cercare un ordine");
            Console.WriteLine("Premi E per uscire");
            ConsoleKeyInfo key = Console.ReadKey();

            do
            {
                switch (key.Key)
                {
                    case ConsoleKey.N:
                        customer = CreateCustomer();
                        break;
                    case ConsoleKey.C:
                        customer = GetCustomerMenu();
                        break;
                    case ConsoleKey.E:
                        break;
                    default:
                        Console.WriteLine("Premere un pulsante disponibile");
                        break;
                }
            } while (key.Key != ConsoleKey.E);

            return customer;
        }


        public Customer CreateCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Inserisci il nome del cliente: ");
            customer.CustomerName = Console.ReadLine();
            Console.WriteLine("Inserisci la partita IVA: ");
            customer.CustomerVATNumber = Console.ReadLine();
            return customer;
        }

        public Customer GetCustomerMenu()
        {
            Customer customer = new Customer();
            Console.WriteLine("Scegli l'operazione: ");
            Console.WriteLine("Premi N per cercare un cliente per nome");
            Console.WriteLine("Premi P per cercare un cliente per partita IVA");
            Console.WriteLine("Premi E per uscire");
            ConsoleKeyInfo key = Console.ReadKey();

            do
            {
                switch (key.Key)
                {
                    case ConsoleKey.N:
                        customer = GetCustomerByName();
                        break;
                    case ConsoleKey.P:
                        customer = GetCustomerByPIVA();
                        break;
                    case ConsoleKey.E:
                        break;
                    default:
                        Console.WriteLine("Premere un pulsante disponibile");
                        break;
                }
            } while (key.Key != ConsoleKey.E);

            return customer;

        }

        private Customer GetCustomerByPIVA()
        {
            CustomerManager customerManager = new CustomerManager();
            Console.WriteLine("Inserisci tutto o una parte della Partita IVA");
            string search = Console.ReadLine();
            return customerManager.GetCustomerByPIVA(search);

        }

        private Customer GetCustomerByName()
        {
            CustomerManager customerManager = new CustomerManager();
            Console.WriteLine("Inserisci tutto o una parte delnome");
            string search = Console.ReadLine();
            return customerManager.GetCustomerByName(search);
        }
    }
}
