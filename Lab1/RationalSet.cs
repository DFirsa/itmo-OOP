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
            return max;
        }

        public Rational GetMin()
        {
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