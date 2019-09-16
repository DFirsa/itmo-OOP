using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Polynomial
    {
        private RationalSet coefs;

        public Polynomial(RationalSet coefsList)
        {
            coefs = coefsList;
        }

        public static Polynomial operator +(Polynomial firstPol, Polynomial secondPol)
        {
            RationalSet resultCoefs = new RationalSet();

            for (int i = 0; i < Math.Min(firstPol.coefs.set.Count, secondPol.coefs.set.Count); i++)
                resultCoefs.Add(firstPol.coefs.set[i] + secondPol.coefs.set[i]);

            if (firstPol.coefs.set.Count < secondPol.coefs.set.Count)
                for (int i = firstPol.coefs.set.Count; i < secondPol.coefs.set.Count; i++)
                    resultCoefs.Add(secondPol.coefs.set[i]);
            else
                for (int i = secondPol.coefs.set.Count; i < firstPol.coefs.set.Count; i++)
                    resultCoefs.Add(firstPol.coefs.set[i]);

            return new Polynomial(resultCoefs);
        }

        public RationalSet GetCoefsSet()
        {
            return coefs;
        }

        public override string ToString()
        {
            string polynomial = "";
            foreach (var rat in coefs.set)
                polynomial += rat.ToString();

            return polynomial;
        }
    }
}