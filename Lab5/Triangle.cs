using System;

namespace Lab5
{
    [Serializable]
    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(){}
        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        
        public override string ToString()
        {
            return $"point A: {A.ToString()} \npoint B: {B.ToString()} \npoint C: {C.ToString()}";
        }
    }
}