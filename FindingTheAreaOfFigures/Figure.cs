using System;
using System.Collections.Generic;

namespace FindingTheAreaOfFigures
{
    public class Figure
    {
        public double radius;
        public double side1;
        public double side2;
        public double side3;

        public Figure(double radiusCurcle)
        {
            radius = radiusCurcle;
        }

        public Figure(double sideTriangle1, double sideTriangle2, double sideTriangle3)
        {
            side1 = sideTriangle1;
            side2 = sideTriangle2;
            side3 = sideTriangle3;
        }

        public double GetAreaCurcle()
        {
            try
            {
                if (radius <= 0)
                {
                    throw new Exception("Некорректное значение радиуса окружности");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return 0;
            }
            double area = Math.Round(Math.PI * radius * radius, 2);
            return area;

        }

        public double GetAreaTriangle()
        {
            try
            {
                if (!CheckTriangle(side1, side2, side3))
                {
                    throw new Exception("Некорректные значения сторон треугольника");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                return 0;
            }
            if (CheckRightTriangle(side1, side2, side3))
            {
                double area;
                List<double> parties = new List<double>() { side1, side2, side3 };
                parties.Sort();
                area = parties[0] * parties[1] / 2;
                return Math.Round(area, 2);
            }
            else
            {
                double semiPerimeter = (side1 + side2 + side3) / 2;
                double area = Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
                return Math.Round(area, 2);
            }

        }

        private bool CheckTriangle(double side1, double side2, double side3)
        {
            List<double> parties = new List<double>() { side1, side2, side3 };
            parties.Sort();
            if (!(parties[2] - parties[1] < parties[0] && parties[2] + parties[1] > parties[0]))
            {
                return false;
            }
            else if (!(parties[2] - parties[0] < parties[1] && parties[2] + parties[0] > parties[1]))
            {
                return false;
            }
            else if (!(parties[1] - parties[0] < parties[2] && parties[1] + parties[0] > parties[2]))
            {
                return false;
            }
            return true;
        }

        private bool CheckRightTriangle(double side1, double side2, double side3)
        {
            List<double> parties = new List<double>() { side1, side2, side3 };
            parties.Sort();
            if (parties[2] * parties[2] == parties[1] * parties[1] + parties[0] * parties[0])
            {
                return true;
            }
            return false;
        }
    }
}
