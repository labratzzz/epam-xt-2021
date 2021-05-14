namespace CustomPaint.Entities
{
    using System;

    public class Circle : Figure
    {
        // Constructors
        public Circle(double centerX, double centerY, double radius) : this(new Point(centerX, centerY), radius) { }

        public Circle(Point center, double radius)
        {
            if (radius <= 0) throw new ArgumentException("Radius must be positive number", nameof(radius));

            this.Type = "Circle";
            this.Center = center;
            this.Radius = radius;
            this.Circumference = Circle.CalculateCircumference(radius);
        }

        // Properties
        public Point Center { get; protected set; }

        public double Radius { get; protected set; }

        public double Circumference { get; protected set; }

        // Methods
        public override string ToString()
        {
            return base.ToString() +
                string.Format(
                "Center: {1}{0}Radius: {2:n2}{0}Circumference: {3:n2}{0}", 
                Environment.NewLine,
                this.Center,
                this.Radius,
                this.Circumference);
        }

        protected static double CalculateCircumference(double radius) => 2 * Math.PI * radius;
    }
}