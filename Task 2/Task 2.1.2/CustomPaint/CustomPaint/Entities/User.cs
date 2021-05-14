namespace CustomPaint.Entities
{
    using System.Collections.Generic;
    
    public class User
    {
        // Constructors
        public User(string name)
        {
            this.Name = name;
            this.Storage = new List<Figure>();
        }

        // Properties
        public string Name { get; }

        public List<Figure> Storage { get; set; }

        // Methods
        public override string ToString()
        {
            return string.Format("{0} [Figures: {1}]", this.Name, this.Storage.Count);
        }
    }
}
