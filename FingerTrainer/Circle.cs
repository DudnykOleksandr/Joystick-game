using System;

namespace FingerTrainer
{
    public class Circle
    {
        public Circle()
        {
        }

        // Constructor to create a circle with a given radius
        public Circle(double radius, int x, int y)
        {
            Radius = radius;
            X = x;
            Y = y;
        }

        public double Radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Method to calculate and return the area of the circle
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Method to calculate and return the circumference of the circle
        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        public bool IsPointInside(double x, double y)
        {
            double distanceSquared = (x - X) * (x - X) + (y - Y) * (y - Y);
            return distanceSquared <= Radius * Radius;
        }
    }
}
