namespace Lab5Apps
{
    public class MinMaxCoordinate
    {
        public double XLeft;
        public double YLeft;
        public double XRight;
        public double YRight;
        public bool InitFirst;

        public MinMaxCoordinate()
        {
            InitFirst = true;
        }

        public void SetNewAttr(double xLeft, double yLeft, double xRight, double yRight)
        {
            InitFirst = false;
            XLeft = xLeft;
            YLeft = yLeft;
            XRight = xRight;
            YRight = yRight;
        }

        public override string ToString()
        {
            return $"The smallest frame to cover all points is: [({XLeft}, {YLeft}) ; ({XRight}, {YRight})]";
        }
    }
}