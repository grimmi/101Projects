using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

/*
 * Shape Area and Perimeter Classes - Create an abstract class called Shape and then inherit from it other shapes like diamond, rectangle, circle, triangle etc. Then have each class override the area and perimeter functionality to handle each shape type.
 * Erste Version: 01.09.2013
 */

namespace shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Square(2);
            s.print();
            Shape c = new Circle(3);
            c.print();
            Shape t = new Triangle(3, 4, 5);
            t.print();
            Shape r = new Rectangle(3, 5);
            r.print();
            Console.ReadKey();
        }
    }

    abstract class Shape
    {
        public List<double> sides { get; set; }
         
        public abstract double getArea();
        public abstract double getCircumference();
        public abstract void setSides(double[] newSides);

        public Shape()
        {
            this.sides = new List<double>();
        }

        public void print()
        {
            Console.WriteLine("This is a {0} with the following sides:", this.GetType().ToString());
            foreach (double s in sides)
            {
                Console.WriteLine("{0}", s);
            }
            Console.WriteLine("Resulting Area: {0}", this.getArea());
            Console.WriteLine("Resulting Circumference: {0}", this.getCircumference());
            Console.WriteLine("-------------------------");
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(double a = 0.0, double b = 0.0)
        {
            double[] t = { a, b };
            this.setSides(t);
        }

        public override void setSides(double[] newSides)
        {
            if (newSides.Length == 2)
            {
                this.sides = new List<double>();
                this.sides.Add(newSides.First());
                this.sides.Add(newSides[1]);
            }
            else
            {
                throw new InvalidAmountOfSidesException(2,newSides.Length);
            }
        }

        public override double getArea()
        {
            return this.sides[0] * this.sides[1];
        }

        public override double getCircumference()
        {
            return (this.sides[0] * 2) + (this.sides[1] * 2);
        }
    }

    class Square : Shape
    {
        public Square(double side = 0.0)
        {
            double[] t = { side };
            this.setSides(t);
        }

        public override void setSides(double[] newSides)
        {
            if (newSides.Length == 1)
            {
                this.sides = new List<double>();
                this.sides.Add(newSides.First());
            }
            else
            {
                throw new InvalidAmountOfSidesException(1,newSides.Length);
            }
        }

        public override double getArea()
        {
            return Math.Pow(sides.First(), 2);
        }

        public override double getCircumference()
        {
            return sides.First() * 4;
        }
    }

    class Circle : Shape
    {
        public Circle(double side = 0.0)
        {
            double[] t = { side };
            this.setSides(t);
        }

        public override void setSides(double[] newSides)
        {
            if (newSides.Length == 1)
            {
                this.sides = new List<double>();
                this.sides.Add(newSides.First());
            }
            else
            {
                throw new InvalidAmountOfSidesException(1, newSides.Length);
            }
        }

        public override double getArea()
        {
            return Math.PI * Math.Pow(getRadius(), 2);
        }

        public override double getCircumference()
        {
            return sides.First();
        }

        // circumference of a circle: 2 * PI * r => r = (C / (2 * PI))
        private double getRadius()
        {
            return (sides.First() / (2 * Math.PI));
        }
    }

    class Triangle : Shape
    {
        public Triangle(double a = 0.0, double b = 0.0, double c = 0.0)
        {
            double[] t = { a, b, c };
            this.setSides(t);
        }

        public override void setSides(double[] newSides)
        {
            if (newSides.Length == 3)
            {
                this.sides = new List<double>();
                foreach (double d in newSides)
                {
                    this.sides.Add(d);
                }
            }
            else
            {
                throw new InvalidAmountOfSidesException(3, newSides.Length);
            }
        }

        public override double getArea()
        {
            double semi = getSemiPerimeter();
            return Math.Sqrt(semi * (semi - sides[0]) * (semi - sides[1]) * (semi - sides[2]));
        }

        public override double getCircumference()
        {
            return sides.Sum();
        }

        private double getSemiPerimeter()
        {
            return (sides[0] + sides[1] + sides[2]) / 2;
        }
    }

    class InvalidAmountOfSidesException : Exception
    {
        public InvalidAmountOfSidesException(int valid, int supplied)
        {
            this.Data["validSides"] = valid;
            this.Data["suppliedSides"] = supplied;
            Debug.WriteLine("Invalid amount of sides! Valid: {0} - Supplied: {1}", valid, supplied);
            Debug.WriteLine("Data:");
            foreach (DictionaryEntry de in this.Data)
            {
                Debug.WriteLine("Key: {0}, Value: {1}",de.Key.ToString(),de.Value.ToString());
            }
        }
    }
}
