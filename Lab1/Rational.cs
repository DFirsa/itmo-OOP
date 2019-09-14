using System;
using System.Collections.Generic;

namespace Lab1
{
    public class Rational
    {
        private int num;
        private int denum;

        public Rational(int num, int denum)
        {
            this.num = num;
            this.denum = denum;
        }

        public void Show()
        {
            Console.Write(num + "/" + denum + " ");
        }

        private static List<long> ToSameDenum(Rational firstVal, Rational secondVal)
        {
            long first = firstVal.num;
            long second = secondVal.num;

            if (firstVal.denum != secondVal.denum)
            {
                first *= secondVal.denum;
                second *= firstVal.denum;
            }
            
            List<long> result = new List<long>();
            result.Add(first);
            result.Add(second);

            return result;
        }

        public static bool operator >(Rational firstVal, Rational secondVal)
        {
            return ToSameDenum(firstVal,secondVal)[0] > ToSameDenum(firstVal, secondVal)[1];
        }

        public static bool operator <(Rational firstVal, Rational secondVal)
        {
            return ToSameDenum(firstVal,secondVal)[0] < ToSameDenum(firstVal, secondVal)[1];
        }

        public static Rational operator +(Rational firstVal, Rational secondVal)
        {
            int firstNum = firstVal.num * secondVal.denum;
            int secondNum = secondVal.num * firstVal.denum;

            int num = firstNum + secondNum;
            int denum = firstVal.denum * secondVal.denum;
            
            Rational result = new Rational(num, denum);
            result.FractionReduction();

            return result;
        }

        public void FractionReduction()
        {
            int devider = Math.Min(num, denum);

            while (devider > 1)
            {
                if ((num % devider == 0) && (denum % devider == 0))
                {
                    num /= devider;
                    denum /= devider;
                    break;
                }
                else devider--;
            }
        }
    }
}