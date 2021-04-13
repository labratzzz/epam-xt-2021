namespace CustomPaint
{
    using System;

    public class Round : Circle
    {
        // Constructors
        public Round(double centerX, double centerY, double radius) : 
            this(new Point(centerX, centerY), radius) { }
        
        public Round(Point center, double radius) : base(center, radius)
        {
            this.Type = "Round";
            this.Area = Round.CalculateArea(radius);
        }

        // Properties
        public double Area { get; protected set; }

        // Methods
        public override string ToString()
        {
            return base.ToString() + string.Format(
                "Area: {1:n2}{0}",
                Environment.NewLine,
                this.Area);
        }

        protected static double CalculateArea(double radius) => Math.PI * Math.Pow(radius, 2);
    }
}