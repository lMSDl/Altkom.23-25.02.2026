using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    internal class Circle : Shape2D
    {
        private int _radius;
        public Circle(int radius) : base("koło", 2*radius, 2*radius)
        {
        }

        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}
