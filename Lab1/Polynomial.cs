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

        public List<Rational> GetCoefsList()
        {
            return coefs.GetCollection();
        }

        public static Polynomial operator +(Polynomial firstPol, Polynomial secondPol)
        {
            RationalSet resultCoefs = new RationalSet();

            List<Rational> firstCollection = firstPol.GetCoefsList();
            List<Rational> secondCollection = secondPol.GetCoefsList();

            for (int i = 0; i < Math.Min(firstCollection.Count, secondCollection.Count); i++)
                resultCoefs.Add(firstCollection[i] + secondCollection[i]);

            if (firstCollection.Count < secondCollection.Count)
                for (int i = firstCollection.Count; i < secondCollection.Count; i++)
                    resultCoefs.Add(secondCollection[i]);
            else if (firstCollection.Count != secondCollection.Count)
                for (int i = secondCollection.Count; i < firstCollection.Count; i++)
                    resultCoefs.Add(firstCollection[i]);
            
            return new Polynomial(resultCoefs);
        }
    }
}