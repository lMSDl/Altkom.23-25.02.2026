using Inheritance;

//var shape = new Shape("shape");
//shape.ToString();
//Console.WriteLine(shape);
//Shape1D shape1D = new Shape1D("line", 10);
//Console.WriteLine(shape1D);
//Shape1D shape2D = new Shape2D("rectangle", 10, 23);
//Console.WriteLine(shape2D);

Line line = new Line(10);
Shape2D shape2 = new Rectangle(10, 23);
Shape shape3 = new Square(22);

//shape3 = line;
shape2 = (Shape2D)shape3;
//Rectangle rec = (Rectangle)shape3;
Rectangle? rec = shape3 as Rectangle;
//shape2 = (Shape2D)line; //rzutowanie niejawne, ponieważ Line jest klasą pochodną Shape2D, więc można przypisać obiekt Line do zmiennej typu Shape2D bez konieczności jawnego rzutowania. Jednakże, jeśli chcielibyśmy przypisać obiekt Line do zmiennej typu Rectangle, musielibyśmy użyć jawnego rzutowania, ponieważ Line nie jest klasą pochodną Rectangle. W takim przypadku, jeśli obiekt Line nie jest faktycznie instancją Rectangle, rzutowanie zakończy się błędem w czasie wykonywania (InvalidCastException).

Console.WriteLine(line.Width);
Console.WriteLine(shape2.Width);
Console.WriteLine(shape2.Height);
//Console.WriteLine(shape3.);

ICollection<Shape1D> shapes = new List<Shape1D>
{
    new Rectangle(10, 23),
    new Square(22),
    new Line(10)
};

AddToList(shapes, new Square(33));

foreach (var shape in shapes)
{
    Console.WriteLine(shape);
}



void AddToList(ICollection<Shape1D> list, Shape1D shape)
{
    if(shape is Shape2D)
    {
        Console.WriteLine("Nie można dodać kształtu 2D do listy kształtów 1D");
        return;
    }

    list.Add(shape);
}
