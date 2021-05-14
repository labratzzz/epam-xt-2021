namespace CustomPaint.Entities
{
    using System;

    /// <summary>
    /// Structure that represents line segment.
    /// </summary>
    public struct LineSegment
    {
        // Constructors
        public LineSegment(double length)
        {
            this.Length = length;
        }

        public LineSegment(Point start, Point end)
        {
            this.Length = CalculateLength(start, end);
        }

        // Properties
        public double Length { get; set; }

        // Methods
        public override string ToString() => string.Format("Length = {0:n2}", this.Length);
        
        private static double CalculateLength(Point point1, Point point2) => Math.Sqrt(Math.Pow(Math.Abs(point2.X - point1.X), 2) + Math.Pow(Math.Abs(point2.Y - point1.Y), 2));
    }
}