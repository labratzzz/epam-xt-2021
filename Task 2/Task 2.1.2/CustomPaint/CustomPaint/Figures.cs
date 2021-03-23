using System;

namespace CustomPaint
{
    /// <summary>
    /// Structure that represents two-dimensional point.
    /// </summary>
    struct Point 
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }

        public override string ToString() => string.Format("X = {0:n2} | Y = {1:n2}", X, Y);
    }

    /// <summary>
    /// Structure that represents line segment.
    /// </summary>
    struct LineSegment
    {
        public LineSegment(double length)
        {
            Length = length;
        }
        public LineSegment(Point start, Point end)
        {
            Length = CalculateLength(start, end);
        }
        public double Length { get; set; }

        private static double CalculateLength(Point point_1, Point point_2) => Math.Sqrt(Math.Pow(Math.Abs(point_2.X - point_1.X), 2) + Math.Pow(Math.Abs(point_2.Y - point_1.Y), 2));

        public override string ToString() => string.Format("Length = {0:n2}", Length);
    }

    abstract class Figure
    {
        private static int LastId;
        public int Id { get; private set; }
        public string Type { get; protected set; }

        static Figure()
        {
            LastId = default;
        }
        protected Figure()
        {
            Id = ++LastId;
        }

        public override string ToString() => string.Format("{1} with ID = {2}{0}", Environment.NewLine, Type, Id);
    }

    class Circle : Figure
    {
        public Point Center { get; protected set; }
        public double Radius { get; protected set; }
        public double Circumference { get; protected set; }

        public Circle(double center_x, double center_y, double radius) : this(new Point(center_x, center_y), radius) { }
        public Circle(Point center, double radius)
        {
            if (radius <= 0) throw new ArgumentException("Radius must be positive number", nameof(radius));
            Type = "Circle";
            Center = center;
            Radius = radius;
            Circumference = CalculateCircumference(radius);
        }

        protected static double CalculateCircumference(double radius) => 2 * Math.PI * radius;

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Center: {1}{0}Radius: {2:n2}{0}Circumference: {3:n2}{0}", Environment.NewLine, Center, Radius, Circumference);
        }
    }

    class Round : Circle
    {
        public double Area { get; protected set; }

        public Round(double center_x, double center_y, double radius) : this(new Point(center_x, center_y), radius) { }
        public Round(Point center, double radius) : base(center, radius)
        {
            Type = "Round";
            Area = CalculateArea(radius);
        }

        protected static double CalculateArea(double radius) => Math.PI * Math.Pow(radius, 2);

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Area: {1:n2}{0}", Environment.NewLine, Area);
        }
    }

    class Ring : Round
    {
        public double InnerRadius { get; private set; }
        public double InnerCircumference { get; private set; }

        public Ring(double center_x, double center_y, double inner_radius, double outer_radius) : this(new Point(center_x, center_y), inner_radius, outer_radius) { }
        public Ring(Point center, double inner_radius, double outer_radius) : base(center, outer_radius)
        {
            if (inner_radius <= 0) throw new ArgumentException("Inner radius must be positive number", nameof(inner_radius));
            if (inner_radius >= outer_radius) throw new ArgumentException("Inner radius must be less than outer radius", nameof(inner_radius));
            Type = "Ring";
            InnerRadius = inner_radius;
            InnerCircumference = CalculateCircumference(inner_radius);
            Area -= CalculateArea(inner_radius);
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Inner Radius: {1:n2}{0}Inner Circumference: {2:n2}{0}", Environment.NewLine, InnerRadius, InnerCircumference);
        }
    }

    class Rectangle : Figure 
    {
        public Point Position { get; protected set; }
        public LineSegment SideA { get; protected set; }
        public LineSegment SideB { get; protected set; }
        public double Perimeter { get; protected set; }
        public double Area { get; protected set; }

        public Rectangle(double position_x, double position_y, double side_a, double side_b) : 
            this(new Point(position_x, position_y), new LineSegment(side_a), new LineSegment(side_b)) { }
        public Rectangle(double position_x, double position_y, LineSegment side_a, LineSegment side_b) : this(new Point(position_x, position_y), side_a, side_b) { }
        public Rectangle(Point position, LineSegment side_a, LineSegment side_b)
        {
            if (side_a.Length <= 0 || side_b.Length <= 0) throw new ArgumentException("Sides must be positive numbers");
            Type = "Rectangle";
            Position = position;
            SideA = side_a;
            SideB = side_b;
            Area = CalculateArea(side_a.Length, side_b.Length);
            Perimeter = CalculatePerimeter(side_a.Length, side_b.Length);
        }

        protected static double CalculateArea(double side_a, double side_b) => side_a * side_b;
        protected static double CalculatePerimeter(double side_a, double side_b) => (side_a + side_b) * 2;

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Side A: {1:n2}{0}Side B: {2:n2}{0}Perimeter: {3:n2}{0}Area: {4:n2}{0}", Environment.NewLine, SideA.Length, SideB.Length, Perimeter, Area);
        }
    }

    class Square : Rectangle
    {
        public Square(double position_x, double position_y, double side) : this(new Point(position_x, position_y), new LineSegment(side)) { }
        public Square(double position_x, double position_y, LineSegment side) : this(new Point(position_x, position_y), side) { }
        public Square(Point position, LineSegment side) : base(position, side, side) 
        {
            Type = "Square";
        }
    }

    class Triangle : Figure
    {
        public Point VerticleA { get; protected set; }
        public Point VerticleB { get; protected set; }
        public Point VerticleC { get; protected set; }
        public LineSegment SideAB { get; protected set; }
        public LineSegment SideBC { get; protected set; }
        public LineSegment SideAC { get; protected set; }
        public double Perimeter { get; protected set; }
        public double Area { get; protected set; }

        public Triangle(double verticle_a_x, double verticle_a_y, double verticle_b_x, double verticle_b_y, double verticle_c_x, double verticle_c_y) :
        this(new Point(verticle_a_x, verticle_a_y), new Point(verticle_b_x, verticle_b_y), new Point(verticle_c_x, verticle_c_y)) { }
        public Triangle(Point verticle_a, Point verticle_b, Point verticle_c)
        {
            Type = "Triangle";
            VerticleA = verticle_a;
            VerticleB = verticle_b;
            VerticleC = verticle_c;
            SideAB = new LineSegment(verticle_a, verticle_b);
            SideBC = new LineSegment(verticle_b, verticle_c);
            SideAC = new LineSegment(verticle_a, verticle_c);
            Perimeter = SideAB.Length + SideBC.Length + SideAC.Length;
            Area = CalculateArea(Perimeter, SideAB, SideBC, SideAC);
        }

        private static double CalculateArea(double perimeter, LineSegment AB, LineSegment BC, LineSegment AC)
        {
            double half_perimeter = perimeter / 2;
            return Math.Sqrt(half_perimeter * (half_perimeter - AB.Length) * (half_perimeter - BC.Length) * (half_perimeter - AC.Length));
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format("Verticle A: {1}{0}Verticle B: {2}{0}Verticle C: {3}{0}Side AB: {4}{0}Side BC: {5}{0}Side AC: {6}{0}Perimeter: {7:n2}{0}Area: {8:n2}{0}", 
                Environment.NewLine,
                VerticleA,
                VerticleB,
                VerticleC,
                SideAB,
                SideBC,
                SideAC,
                Perimeter,
                Area);
        }
    }
}