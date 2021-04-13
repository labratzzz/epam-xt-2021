namespace CustomPaint
{
    using System;

    public class Rectangle : Figure 
    {
        // Constructors
        public Rectangle(double positionX, double positionY, double sideA, double sideB) : 
            this(new Point(positionX, positionY), new LineSegment(sideA), new LineSegment(sideB)) { }

        public Rectangle(double positionX, double positionY, LineSegment sideA, LineSegment sideB) : 
            this(new Point(positionX, positionY), sideA, sideB) { }
        
        public Rectangle(Point position, LineSegment sideA, LineSegment sideB)
        {
            if (sideA.Length <= 0 || sideB.Length <= 0) throw new ArgumentException("Sides must be positive numbers");

            this.Type = "Rectangle";
            this.Position = position;
            this.SideA = sideA;
            this.SideB = sideB;
            this.Area = CalculateArea(sideA.Length, sideB.Length);
            this.Perimeter = CalculatePerimeter(sideA.Length, sideB.Length);
        }

        // Properties
        public Point Position { get; protected set; }

        public LineSegment SideA { get; protected set; }

        public LineSegment SideB { get; protected set; }

        public double Perimeter { get; protected set; }

        public double Area { get; protected set; }
 
        // Methods
        public override string ToString()
        {
            return base.ToString() + string.Format(
                "Side A: {1:n2}{0}Side B: {2:n2}{0}Perimeter: {3:n2}{0}Area: {4:n2}{0}",
                Environment.NewLine,
                this.SideA.Length,
                this.SideB.Length,
                this.Perimeter,
                this.Area);
        }

        protected static double CalculateArea(double sideA, double sideB) => sideA * sideB;

        protected static double CalculatePerimeter(double sideA, double sideB) => (sideA + sideB) * 2;
    }
}