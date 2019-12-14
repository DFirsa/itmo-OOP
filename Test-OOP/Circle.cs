using System;
using System.Runtime.CompilerServices;

namespace OOP_Test
{

    public struct Vector
    {
        public readonly double x;
        public readonly double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x}; {y}";
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x+ v2.x, v1.y+v2.y);
        }
    }
    
    public class Circle
    {
        private Vector centre; //vector from (0;0) to centre of circle
        private double radius;

        public Circle(Vector centreVector, double radius)
        {
            centre = centreVector;
            this.radius = radius;
        }

        public Circle(double x, double y, double radius)
        {
            centre = new Vector(x,y);
            this.radius = radius;
        }

        public override string ToString()
        {
            return $"({centre.ToString()})";
        }

        public void move(Vector vector)
        {
            centre = centre + vector;
        }

        public double getPer()
        {
            return Math.PI * 2 * radius;
        }

        public double getArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public void showInfo()
        {
            Console.WriteLine(getInfo());
        }

        public string getInfo()
        {
            string centre = $"Centre: {ToString()}";
            string rad = $"Radius: {radius}";
            return centre + "\n" + rad;
        }
    }
}