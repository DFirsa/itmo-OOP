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

        public void Add(Rational rational)
        {
            set.Add(rational);
        }

        public Rational GetMax()
        {
            Rational max = set[0];

            for (int i = 0; i < set.Count; i++)
                if (set[i] > max)
                    max = set[i];

            return max;
        }

        public Rational GetMin()
        {
            Rational min = set[0];

            foreach (var val in set)
                if (val < min)
                    min = val;

            return min;
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
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = line.Split('/');
                    Add(new Rational(Int32.Parse(lines[0]), Int32.Parse(lines[1])));
                }
            }
        }

        public List<Rational> GetCollection()
        {
            return set;
        }
    }
}