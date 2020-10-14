using System;

namespace Lab5Apps
{
    public class Line : Shape
    {
        private double _x1, _y1;
        private double _x2, _y2;

        public Coordinate StartPoint => new Coordinate(_x1, _y1);
        public Coordinate EndPoint => new Coordinate(_x2, _y2);

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
        
        public Line(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _y1 = y1;
            _x2 = x2;
            _y2 = y2;
        }


        public override string ToString()
        {
            return $"Line through ({_x1}, {_y1}) & ({_x2}, {_y2})";
        }

        public override void Area()
        {
            Console.WriteLine($"The Line through ({_x1}, {_y1}) & ({_x2}, {_y2}) area is: 0!");
        }

        public override void MoveShape(Coordinate newCenter)
        {
            var oldLocalCenterPoint = LocalCoordinatePoint;
            _x1 = (int) (newCenter.X - oldLocalCenterPoint.X);
            _y1 = (int) (newCenter.Y - oldLocalCenterPoint.Y);
            _x2 = (int) (newCenter.X + oldLocalCenterPoint.X);
            _y2 = (int) (newCenter.Y + oldLocalCenterPoint.Y);
        }
    }
}