namespace CustomPaint.Entities
{
    public class Square : Rectangle
    {
        public Square(double positionX, double positionY, double side) :
            this(new Point(positionX, positionY), new LineSegment(side)) { }

        public Square(double positionX, double positionY, LineSegment side) :
            this(new Point(positionX, positionY), side) { }

        public Square(Point position, LineSegment side) : base(position, side, side) 
        {
            this.Type = "Square";
        }
    }
}