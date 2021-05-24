namespace PizzaTime.Entities
{
    using System;

    public abstract class Human
    {
        // Fields
        private string firstname;

        private string lastname;

        // Constructors
        protected Human(string firstname, string lastname)
        {
            this.Fisrtname = firstname;
            this.Lastname = lastname;
            this.Wallet = new Wallet();
        }

        // Properties
        public string Fisrtname 
        {
            get => this.firstname; 
            set => this.firstname = 
                string.IsNullOrEmpty(value) 
                ? throw new ArgumentException("Name must have at least one character", nameof(value))
                : value;
        }

        public string Lastname
        {
            get => this.lastname;
            set => this.lastname =
                string.IsNullOrEmpty(value)
                ? throw new ArgumentException("Name must have at least one character", nameof(value))
                : value;
        }

        public Wallet Wallet { get; set; }
    }
}
