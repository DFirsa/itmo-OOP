using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RationalSet set = new RationalSet();
            set.Load("C:\\Users\\Denis\\Desktop\\lab1.txt");
            
            Console.Write("Max: ");
            set.GetMax().Show();
            Console.Write("\nMin: ");
            set.GetMin().Show();
            
            Rational rat = new Rational(1,2);
            
            Console.Write("Count fractions more then  ");
            rat.Show();
            Console.Write(" : " + set.CountMoreThen(rat) + "\nCount fractions less then ");
            rat.Show();
            Console.WriteLine(" :\n" + set.CountLessThen(rat) );
            
            Polynomial pol = new Polynomial(set);
            pol.Show();
            Console.WriteLine("sum");
            (pol + pol).Show();
        }
    }
}