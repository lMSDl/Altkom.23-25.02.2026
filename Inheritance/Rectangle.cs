namespace Inheritance
{
    internal class Rectangle : Shape2D
    {
        public Rectangle(int width, int height) : base("prostokąt", width, height)
        {
        }

        public override double GetArea()
        {
            return Height * Width;
        }
    }
}
