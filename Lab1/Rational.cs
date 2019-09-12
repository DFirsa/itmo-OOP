using System;

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

        public void Check()
        {
            Console.WriteLine(num + "/" + denum);
        }

        public static bool operator >(Rational firstVal, Rational secondVal)
        {
            long first = firstVal.num;
            long second = secondVal.num;

            if (firstVal.denum != secondVal.denum)
            {
                first *= secondVal.denum;
                second *= firstVal.denum;
            }

            return first > second;
        }

        public static bool operator <(Rational firstVal, Rational secondVal)
        {
            return !(firstVal > secondVal);
        }

        public static Rational operator +(Rational firstVal, Rational secondVal)
        {
            int firstNum = firstVal.num * secondVal.denum;
            int secondNum = secondVal.num * firstVal.denum;

            int num = firstNum + secondNum;
            int denum = firstVal.denum * secondVal.denum;

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

            return new Rational(num, denum);
        }
    }
}