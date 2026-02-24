using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    internal abstract class Shape1D : Shape
    {
        public int Width { get; } //właściwość tylko do odczytu, która jest inicjalizowana w konstruktorze

        //base(..) - pozwala na wywołanie konstruktora klasy bazowej z określonymi argumentami. W tym przypadku przekazujemy nazwę kształtu do konstruktora klasy Shape, który przypisuje ją do pola _name.
        public Shape1D(string name, int width) : base(name)
        {
            Width = width;
        }

        override public string ToString()
        {
            return $"{base.ToString()} (width: {Width})";
        }

    }
}
