using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    public class RationalSet
    {
        private List<Rational> set;

        private Rational max;
        private Rational min;

        private bool isEmpty;

        public RationalSet()
        {
            set = new List<Rational>();
            isEmpty = true;
        }

        public void Add(Rational rational)
        {
            set.Add(rational);
            if (isEmpty)
            {
                isEmpty = false;
                max = rational;
                min = rational;
            }
            else
            {
                if (rational < min) min = rational;
                if (rational > max) max = rational;
            }
        }

        public Rational GetMax()
        {
            if (isEmpty) throw new NullReferenceException();
            else return max;
        }

        public Rational GetMin()
        {
            if (isEmpty) throw new NullReferenceException();
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

        public void Load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = line.Split('/');
                    lines[0].Replace(" ", "");
                    lines[1].Replace(" ", "");

                    if (lines.Length != 2) continue;

                    int num, denum;
                    try
                    {
                        num = Int32.Parse(lines[0]);
                        denum = Int32.Parse(lines[1]);
                    }
                    catch (FormatException)
                    {
                        continue;
                    }

                    if (denum == 0)
                    {
                        Console.WriteLine("Invalid fraction format: num = " + num + ", denum = " + denum);
                        continue;
                    }

                    Add(new Rational(num, denum));
                }
            }
        }

        public List<Rational> GetCollection()
        {
            return set;
        }
    }
}