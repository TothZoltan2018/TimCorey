namespace MyLibrary.Shapes
{
    public interface IRectangle : IShapes
    {
        double SideA { get; set; }
        double SideB { get; set; }
        //double CalculateArea();
        //double CalculatePerimeter();
    }
}