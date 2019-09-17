using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab1
{
    public struct Pair
    {
        public long first;
        public long second;

        public Pair(long first, long second)
        {
            this.first = first;
            this.second = second;
        }
    }
    public class Rational
    {
        private int num;
        private int denum;

        public Rational(int num, int denum)
        {
            if (denum != 0)
            {
                this.num = num;
                this.denum = denum;   
            }
            else throw new FormatException();
        }

        public override string ToString()
        {
            return $"{num}/{denum} ";
        }

        private static Pair ToSameDenum(Rational firstVal, Rational secondVal)
        {
            long first = firstVal.num;
            long second = secondVal.num;

            if (firstVal.denum != secondVal.denum)
            {
                first *= secondVal.denum;
                second *= firstVal.denum;
            }

            return new Pair(first, second);
        }

        public static bool operator >(Rational firstVal, Rational secondVal)
        {
            Pair nums = ToSameDenum(firstVal, secondVal);
            return nums.first > nums.second;
        }

        public static bool operator <(Rational firstVal, Rational secondVal)
        {
            Pair nums = ToSameDenum(firstVal, secondVal);
            return nums.first < nums.second;
        }

        public static Rational operator +(Rational firstVal, Rational secondVal)
        {
            int firstNum = firstVal.num * secondVal.denum;
            int secondNum = secondVal.num * firstVal.denum;

            int num = firstNum + secondNum;
            int denum = firstVal.denum * secondVal.denum;
            
            return new Rational(num, denum).FractionReduction();
        }

        public Rational FractionReduction()
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

            return this;
        }
    }
}