namespace CustomPaint.Entities
{
    using System;

    public abstract class Figure
    {
        // Fields
        private static int lastId = default;

        // Constructors
        protected Figure() => this.Id = ++lastId;

        // Properties
        public int Id { get; private set; }

        public string Type { get; protected set; }

        // Methods
        public override string ToString() => string.Format("{1} with ID = {2}{0}", Environment.NewLine, this.Type, this.Id);
    }
}