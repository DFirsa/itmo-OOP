using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;

namespace Lab1
{
    public class RationalSet
    {
        public readonly List<Rational> set;

        private Rational max;
        private Rational min;

        public RationalSet()
        {
            set = new List<Rational>();
        }

        public void Add(Rational rational)
        {
            if (set.Count == 0)
            {
                max = rational;
                min = rational;
            }
            else
            {
                if (rational < min) min = rational;
                if (rational > max) max = rational;
            }
            set.Add(rational);
        }

        public Rational GetMax()
        {
            if (set.Count == 0) throw new InvalidOperationException();
            else return max;
        }

        public Rational GetMin()
        {
            if (set.Count == 0) throw new InvalidOperationException();
            else return min;
        }

        public int CountMoreThen(Rational val)
        {
            int counter = 0;

            foreach (var rat in set)
                if (rat > val)
                    counter++;

            return counter;
        }

        public int CountLessThen(Rational val)
        {
            int counter = 0;

            foreach (var rat in set)
                if (rat < val)
                    counter++;

            return counter;
        }

        public static RationalSet Load(string path)
        {
            RationalSet set = new RationalSet();
            
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = line.Split('/');

                    if (lines.Length != 2) continue;

                    int num, denum;
                    if (!Int32.TryParse(lines[0].Trim(), out num) ||
                        !Int32.TryParse(lines[1].Trim(), out denum)) continue;

                    try
                    {
                        set.Add(new Rational(num, denum));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid fraction format: num = {num} , denum = {denum}");
                    }
                }
            }

            return set;
        }
    }
}