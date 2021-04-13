namespace CustomPaint
{
    /// <summary>
    /// Structure that represents two-dimensional point.
    /// </summary>
    public struct Point 
    {
        // Constructors
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        // Properties
        public double X { get; set; }

        public double Y { get; set; }

        // Methods
        public override string ToString() => string.Format("X = {0:n2} | Y = {1:n2}", this.X, this.Y);
    }
}