using System;

namespace Lab5Apps
{
    public class Circle : Shape
    {
        private Coordinate _center;
        private double _radius;

        public Circle(Coordinate center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public Coordinate Center => _center;

        public override string ToString()
        {
            return $"Circle at ({_center.X}, {_center.Y}) with radius {_radius} ";
        }

        public override void Area()
        {
            var area = Math.Round(Math.PI * (Math.Pow(_radius, 2)), 2);
            Console.WriteLine($"The Circle at ({_center.X}, {_center.Y}) with radius {_radius} area is: {area}!");
        }

        public override void MoveShape(Coordinate newCenter)
        {
            _center = newCenter;
        }

        // The circle circumference
        public void Circumference()
        {
            // C=2π*r
            var circumference = Math.Round(2 * Math.PI * _radius, 2);
            Console.WriteLine($"The circle circumference is: {circumference}!");
        }
    }
    
}