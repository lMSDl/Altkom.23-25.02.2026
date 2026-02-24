namespace Inheritance
{
    internal class Square : Shape2D
    {
        private int _size;

        public Square(int size) : base("kwadrat", size, size)
        {
                _size = size;
        }

        public override double GetArea()
        {
            return _size * _size;
        }
    }
}
