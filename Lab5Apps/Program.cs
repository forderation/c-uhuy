using System;
using System.Collections.Generic;

namespace Lab5Apps

{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">>> Part 1 -- List shapes <<<");
            var shapes = new List<Shape>()
            {
                new Rectangle(1, 4, 6, 1),
                new Circle(new Coordinate(5, 4), 2),
                new Rectangle(2, 8, 5, 1),
                new Line(2, 1, 8, 4),
                new Rectangle(7, 5, 12, 3),
                new Circle(new Coordinate(4, 0), 3),
            };
            shapes.ForEach(Console.WriteLine);

            Console.WriteLine(">>> Part 2 -- Use shapes <<<");
            foreach (var shape in shapes)
            {
                shape.Area();
                switch (shape)
                {
                    case Circle circle:
                        circle.Circumference();
                        break;
                    case Rectangle rectangle:
                        rectangle.Diagonal();
                        break;
                }
            }

            Console.WriteLine(">>> Part 3 -- \"Produce\" shapes <<<");
            string[] shapeTypes = {"r", "c", "l"};

            for (var i = 0; i < 2; i++)
            {
                Console.WriteLine($"Shapes {i + 2}:");
                foreach (var shapeType in shapeTypes)
                {
                    Shape factoryResult;
                    // handle possibility error if shapeType is not define same as on switch factory method
                    try
                    {
                        factoryResult = Shape.PickUp(shapeType);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine(error);
                        continue;
                    }

                    Console.WriteLine(factoryResult);
                }
            }

            Console.WriteLine(">>> Part 4 -- Deconstruct shapes <<<");
            var shapesToMove = new List<Shape>()
            {
                new Rectangle(-3, 9, 3, 7),
                new Circle(new Coordinate(0, 8), 3),
                new Line(-0.5, 7.5, 0.5, 8.5)
            };
            // assumes movedShapes all item move with new Center(15, 7)
            var newCenterPoint = new Coordinate(15, 7);
            // before moved
            Console.WriteLine("Shapes 2:");
            shapesToMove.ForEach(Console.WriteLine);
            // after moved
            shapesToMove.ForEach(shape => shape.MoveShape(newCenterPoint));
            Console.WriteLine("Shapes 3:");
            shapesToMove.ForEach(Console.WriteLine);

            Console.WriteLine(">>> Part 5 -- Cover points <<<");
            // Circle point make me confuse (:
            var experimentCoverPoints = new List<Shape>()
            {
                new Rectangle(1, 4, 6, 1),
                new Circle(new Coordinate(5, 4), 2),
                new Line(2, 1, 8, 4),
            };

            var minMaxCoord = new MinMaxCoordinate();
            foreach (var shape in experimentCoverPoints)
            {
                switch (shape)
                {
                    case Circle circle:
                        FilterCoord(minMaxCoord, circle.Center, circle.Center);
                        break;
                    case Rectangle rectangle:
                        FilterCoord(minMaxCoord, rectangle.LeftUpper, rectangle.RightBottom);
                        break;
                    case Line line:
                        FilterCoord(minMaxCoord, line.StartPoint, line.EndPoint);
                        break;
                }
            }

            Console.WriteLine(minMaxCoord);
        }

        private static void FilterCoord(MinMaxCoordinate minMaxCoord, Coordinate coordLeft, Coordinate coordRight)
        {
            Console.WriteLine("Method FilterCoord");
            if (minMaxCoord.InitFirst)
            {
                Console.WriteLine("Execute AttrNull");
                minMaxCoord.SetNewAttr(coordLeft.X, coordLeft.Y, coordRight.X, coordRight.Y);
                return;
            }

            minMaxCoord.XLeft = Math.Min(minMaxCoord.XLeft, coordLeft.X);
            minMaxCoord.YLeft = Math.Min(minMaxCoord.YLeft, coordLeft.Y);
            minMaxCoord.XRight = Math.Max(minMaxCoord.XRight, coordRight.X);
            minMaxCoord.YRight = Math.Max(minMaxCoord.YRight, coordRight.Y);
        }
    }
}