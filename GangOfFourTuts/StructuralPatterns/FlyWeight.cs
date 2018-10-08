using System;
using System.Collections.Generic;
using System.Text;

namespace GangOfFourTuts.StructuralPatterns.FlyWeight
{
    /// <summary>
    /// The 'Flyweight' interface
    /// </summary>
    interface IShape
    {
        void Print();
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class Rectangle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Rectangle");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    class Circle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Circle");
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    class ShapeObjectFactory
    {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }

        public IShape GetShape(string ShapeName)
        {
            IShape shape = null;
            if (shapes.ContainsKey(ShapeName))
            {
                shape = shapes[ShapeName];
            }
            else
            {
                switch (ShapeName)
                {
                    case "Rectangle":
                        shape = new Rectangle();
                        shapes.Add("Rectangle", shape);
                        break;
                    case "Circle":
                        shape = new Circle();
                        shapes.Add("Circle", shape);
                        break;
                    default:
                        throw new Exception("Factory cannot create the object specified");
                }
            }
            return shape;
        }
    }    
}
