using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RationalSet set = new RationalSet();
            set.Load("..\\..\\Fractions.txt");

            try
            {
                Console.Write("Max: ");
                Console.WriteLine(set.GetMax().ToString());
                Console.Write("Min: ");
                Console.WriteLine(set.GetMin().ToString());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("SET IS EMPTY");
            }

            Rational rat = new Rational(1,2);

            Console.WriteLine($"Count fractions more then {rat.ToString()} : {set.CountMoreThen(rat)}");
            Console.WriteLine($"Count fractions less then {rat.ToString()} : {set.CountLessThen(rat)}");
            
            Polynomial pol = new Polynomial(set);
            Console.WriteLine("Polynomial:\n" + pol.ToString());
            Console.WriteLine("sum");
            Console.WriteLine("Polynomial:\n" + (pol + pol).ToString());
        }
    }
}