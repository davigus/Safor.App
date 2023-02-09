using System;
using System.Collections.Generic;
using Safor.Services;
using Safor.Services.Models;

namespace Safor.App.Contracts.UI
{
    public class OrderUI
    {
        public void GetOrderMenu()
        {
            Order order = new Order();

            Console.WriteLine("Scegli l'operazione: ");
            Console.WriteLine("Premi N per creare un nuovo ordine");
            Console.WriteLine("Premi C per cercare un ordine");
            Console.WriteLine("Premi E per uscire");

            ConsoleKeyInfo key = Console.ReadKey();

            do
            {
                switch (key.Key)
                {
                    case ConsoleKey.N:
                        order = CreateOrder();
                        break;
                    case ConsoleKey.C:
                        order = FindOrder();
                        key = RunOperationMenu();
                        break;
                    case ConsoleKey.E:
                        break;
                    default:
                        Console.WriteLine("Premere un pulsante disponibile");
                        break;
                }
            } while (key.Key != ConsoleKey.E);



        }

        private Order FindOrder()
        {
            var order = new Order();
            return order;
        }

        private ConsoleKeyInfo RunOperationMenu()
        {
            ConsoleKeyInfo key;
            List<ConsoleKey>allowedKeys = new List<ConsoleKey>();
            allowedKeys.Add(ConsoleKey.R);
            allowedKeys.Add(ConsoleKey.D);
            allowedKeys.Add(ConsoleKey.M);
            do
            {
                Console.WriteLine("Premi D per eliminare l'ordine");
                Console.WriteLine("Premi M per modificare l'ordine");
                Console.WriteLine("Premi R per tornare al menù precedente");
                key = Console.ReadKey();
            } while (allowedKeys.Contains(key.Key));
            
            return key;
        }

        private Order CreateOrder()
        {
            Order order = new Order();
            CustomerUI customerUI = new CustomerUI();
            Console.WriteLine("Inserisci i dati del nuovo ordine:");
            Console.WriteLine();
            Console.WriteLine("Inserisci il codice dell'ordine:");
            order.OrderCode = Console.ReadLine();
            Console.WriteLine("Inserisci il nome dell'ordine:");
            order.OrderName = Console.ReadLine();
            Console.WriteLine("Inserisci la data dell'ordine (vuoto = data di oggi):");
            string strDate = Console.ReadLine();
            order.OrderDate = CheckDateForMenu(strDate);
            Console.WriteLine("Inserisci la data di scadenza dell'ordine:");
            strDate = Console.ReadLine();
            order.DueDate = CheckDateForMenu(strDate);
            Console.WriteLine("Inserisci il cliente: ");
            Customer customer = customerUI.CustomerMenu();

            return order;
        }

        public DateTime CheckDateForMenu(string strDate)
        {
            DateTime date;
            string checkDate; 
            do
            {
                checkDate = Utilities.SetAndValidateDate(strDate, out date);
                if(!string.IsNullOrEmpty(checkDate))
                {
                    Console.WriteLine(checkDate);
                }
            }
            while (!string.IsNullOrEmpty(checkDate));
            return date;
        }
    }
}