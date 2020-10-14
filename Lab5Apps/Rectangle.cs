using System;

namespace Lab5Apps
{
    public class Rectangle : Shape
    {
        // below is left upper
        private double _x1, _y1;

        // below is right bottom corners
        private double _x2, _y2;

        public Coordinate LeftUpper => new Coordinate(_x1, _y1);
        public Coordinate RightBottom => new Coordinate(_x2, _y2);

        // property with getter calculate center point from shape
        private Coordinate LocalCoordinatePoint
        {
            get
            {
                var x = (_x2 - _x1) / 2.0;
                var y = (_y2 - _y1) / 2.0;
                return new Coordinate(x, y);
            }
        }

        public Rectangle(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }

        public override string ToString()
        {
            return $"Rectangle from ({_x1}, {_y1}) to ({_x2}, {_y2})";
        }

        // arrow function for simplify code
        private double Length => _x2 - _x1;

        // arrow function for simplify code
        private double Width => _y1 - _y2;

        public override void Area()
        {
            var area = Length * Width;
            Console.WriteLine($"The Rectangle from ({_x1}, {_y1}) to ({_x2}, {_y2}) area is: {area}!");
        }

        public override void MoveShape(Coordinate newCenter)
        {
            var oldLocalCenterPoint = LocalCoordinatePoint;
            _x1 = (int) (newCenter.X - oldLocalCenterPoint.X);
            _y1 = (int) (newCenter.Y - oldLocalCenterPoint.Y);
            _x2 = (int) (newCenter.X + oldLocalCenterPoint.X);
            _y2 = (int) (newCenter.Y + oldLocalCenterPoint.Y);
        }

        public void Diagonal()
        {
            // d = √(l² + w²).
            var diagonal = Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
            Console.WriteLine($"The Rectangle from ({_x1}, {_y1}) to ({_x2}, {_y2}) diagonal length is {diagonal}!");
        }
    }
}