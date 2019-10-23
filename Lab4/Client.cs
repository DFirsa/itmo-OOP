using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Client
    {
        private Serves serves = new Serves();

        void show(List<string> lines, string title)
        {
            Console.WriteLine($" ==== {title.ToUpper()} ==== ");
            foreach (var line in lines) Console.WriteLine(line);
        }

        void show(List<Products> lines, string title)
        {
            Console.WriteLine($" ==== {title.ToLower()} ==== ");
            Console.WriteLine("[name / count]");
            foreach (var line in lines) Console.WriteLine($"{line.Product} : {line.Count}");
        }

        public void addStores()
        {
            serves.createStore("7Я");
            serves.createStore("Пятёрочка");
            serves.createStore("Spar");
            serves.createStore("Магнит");
            serves.createStore("Окей");
        }
    }
}