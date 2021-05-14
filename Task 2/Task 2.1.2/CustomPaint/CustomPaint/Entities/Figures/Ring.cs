namespace CustomPaint.Entities
{
    using System;

    public class Ring : Round
    {
        // Constructors
        public Ring(double centerX, double centerY, double innerRadius, double outerRadius) : 
            this(new Point(centerX, centerY), innerRadius, outerRadius) { }
        
        public Ring(Point center, double innerRadius, double outerRadius) : base(center, outerRadius)
        {
            if (innerRadius <= 0) throw new ArgumentException("Inner radius must be positive number", nameof(innerRadius));
            if (innerRadius >= outerRadius) throw new ArgumentException("Inner radius must be less than outer radius", nameof(innerRadius));
            
            this.Type = "Ring";
            this.InnerRadius = innerRadius;
            this.InnerCircumference = Ring.CalculateCircumference(innerRadius);
            this.Area -= Ring.CalculateArea(innerRadius);
        }

        // Properties
        public double InnerRadius { get; private set; }

        public double InnerCircumference { get; private set; }

        // Methods
        public override string ToString()
        {
            return base.ToString() + string.Format(
                "Inner Radius: {1:n2}{0}Inner Circumference: {2:n2}{0}",
                Environment.NewLine,
                this.InnerRadius,
                this.InnerCircumference);
        }
    }
}