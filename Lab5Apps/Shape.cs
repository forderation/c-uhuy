using System;

namespace Lab5Apps
{
    // parent / base class for initiate for all shapes 
    public abstract class Shape
    {
        // factory method, throw error if shapeCase is doesn't match for switch
        public static Shape PickUp(string shapeCase)
        {
            switch (shapeCase)
            {
                case "l":
                    return new Line(0, 0, 1, 1);
                case "c":
                    return new Circle(new Coordinate(3, 5), 3);
                case "r":
                    return new Rectangle(1, 3, 7, 1);
            }
            throw new TypeAccessException("shape types not found");
        }

        public abstract void Area();
        public abstract void MoveShape(Coordinate newCenter);
    }
}