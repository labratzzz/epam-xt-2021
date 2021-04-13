namespace CustomPaint
{
    using System;

    public class Triangle : Figure
    {
        // Constructors
        public Triangle(double verticleAx, double verticleAy, double verticleBx, double verticleBy, double verticleCx, double verticleCy) :
            this(new Point(verticleAx, verticleAy), new Point(verticleBx, verticleBy), new Point(verticleCx, verticleCy)) { }
        
        public Triangle(Point verticleA, Point verticleB, Point verticleC)
        {
            this.Type = "Triangle";
            this.VerticleA = verticleA;
            this.VerticleB = verticleB;
            this.VerticleC = verticleC;
            this.SideAB = new LineSegment(verticleA, verticleB);
            this.SideBC = new LineSegment(verticleB, verticleC);
            this.SideAC = new LineSegment(verticleA, verticleC);
            this.Perimeter = this.SideAB.Length + this.SideBC.Length + this.SideAC.Length;
            this.Area = CalculateArea(this.Perimeter, this.SideAB, this.SideBC, this.SideAC);
        }

        // Properties
        public Point VerticleA { get; protected set; }

        public Point VerticleB { get; protected set; }

        public Point VerticleC { get; protected set; }

        public LineSegment SideAB { get; protected set; }

        public LineSegment SideBC { get; protected set; }

        public LineSegment SideAC { get; protected set; }

        public double Perimeter { get; protected set; }

        public double Area { get; protected set; }

        // Methods
        public override string ToString()
        {
            return base.ToString() + string.Format(
                "Verticle A: {1}{0}Verticle B: {2}{0}Verticle C: {3}{0}Side AB: {4}{0}Side BC: {5}{0}Side AC: {6}{0}Perimeter: {7:n2}{0}Area: {8:n2}{0}", 
                Environment.NewLine,
                this.VerticleA,
                this.VerticleB,
                this.VerticleC,
                this.SideAB,
                this.SideBC,
                this.SideAC,
                this.Perimeter,
                this.Area);
        }

        private static double CalculateArea(double perimeter, LineSegment lineAB, LineSegment lineBC, LineSegment lineAC)
        {
            double halfPerimeter = perimeter / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - lineAB.Length) * (halfPerimeter - lineBC.Length) * (halfPerimeter - lineAC.Length));
        }
    }
}