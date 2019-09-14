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
                set.GetMax().Show();
                Console.Write("\nMin: ");
                set.GetMin().Show();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("SET IS EMPTY");
            }

            Rational rat = new Rational(1,2);
            
            Console.Write("\nCount fractions more then  ");
            rat.Show();
            Console.Write(" : " + set.CountMoreThen(rat) + "\nCount fractions less then ");
            rat.Show();
            Console.WriteLine(" : " + set.CountLessThen(rat) );
            
            Polynomial pol = new Polynomial(set);
            pol.Show();
            Console.WriteLine("sum");
            (pol + pol).Show();
        }
    }
}