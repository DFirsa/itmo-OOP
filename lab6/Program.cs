using System;
using System.Collections.Generic;

namespace lab6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ClientDirector clientCreator = new ClientDirector();
            ClientBuilder builder = new ClientBuilder();
            clientCreator.Builder = builder;
            
            clientCreator.CreateMinInfoClient("Pupa", "Ivanov");
            Client Pupa = builder.GetClient();
            
            clientCreator.CreateFullInfoClient("Lupa", "Petrov", "Eindhoven, unknown street, some kind of house", 123456);
            Client Lupa = builder.GetClient();
            
            TimeSpan t = new TimeSpan(0, 0, 0, 0);
            List<double> sumInfo = new List<double>(){0, 1000, 10000};
            List<int> percentInfo = new List<int>(){1, 3, 7};
            
            Bank TinkOn = new Bank(t, 10000, 30000, 10, sumInfo, percentInfo, 5);
            TinkOn.addClient(Pupa);
            TinkOn.addClient(Lupa);
            
            TinkOn.CreateDeposit(Lupa, 15000);
            TinkOn.CreateCreditAccount(Pupa);
            
            Console.WriteLine("== start ==");
            Console.WriteLine($"Pupa: {Pupa.account.ToString()} \nLupa: {Lupa.account.ToString()}");
            
            Pupa.account.transfer(3000, Lupa.account);
            Console.WriteLine("== transfer Pupa -> Lupa ==");
            Console.WriteLine($"Pupa: {Pupa.account.ToString()} \nLupa: {Lupa.account.ToString()}");
            
            Lupa.account.transfer(9000, Pupa.account);
            Console.WriteLine("== transfer Lupa -> Pupa ==");
            Console.WriteLine($"Pupa: {Pupa.account.ToString()} \nLupa: {Lupa.account.ToString()}");
        }
    }
}