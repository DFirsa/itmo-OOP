using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    public class RationalSet
    {
        private List<Rational> set;

        public RationalSet()
        {
            set = new List<Rational>();
        }

        public void add(Rational rational)
        {
            set.Add(rational);
        }

        public Rational getMax()
        {
            Rational max = set[0];

            for (int i = 0; i < set.Count; i++)
            {
                if (set[i] > max)
                {
                    max = set[i];
                }
            }

            return max;
        }

        public Rational getMin()
        {
            Rational min = set[0];

            for (int i = 0; i < set.Count; i++)
            {
                if (set[i] < min)
                {
                    min = set[i];
                }
            }

            return min;
        }

        public int countMoreThen(Rational val)
        {
            int counter = 0;

            for (int i = 0; i < set.Count; i++)
            {
                if (set[i] > val)
                {
                    counter++;
                }
            }

            return counter;
        }

        public int countLessThen(Rational val)
        {
            int counter = 0;

            for (int i = 0; i < set.Count; i++)
            {
                if (set[i] < val)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void load(string path)
        {
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                string[] line;
                while ((line = reader.ReadLine().Split('/')) != null)
                {
                    add(new Rational(Int32.Parse(line[0]), Int32.Parse(line[1])));
                }
            }
        }

    }
}