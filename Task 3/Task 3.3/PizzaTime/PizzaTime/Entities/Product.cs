namespace PizzaTime.Entities
{
    using System;

    /// <summary>
    /// Represents a pizzeria products.
    /// </summary>
    public abstract class Product
    {
        // Fields
        private string name;

        // Constructors
        protected Product(string name, decimal price)
        {
            if (price <= 0) throw new ArgumentException("Product price must be positive number", nameof(price));

            this.Name = name;
            this.Price = price;
            this.IsReady = false;
        }

        // Properties

        /// <summary>
        /// Name of the product.
        /// </summary>
        public string Name 
        {
            get => this.name;
            protected set => this.name =
                string.IsNullOrEmpty(value)
                ? throw new ArgumentException("Name must have at least one character", nameof(value))
                : value;
        }

        /// <summary>
        /// Name of the product.
        /// </summary>
        public decimal Price { get; protected set; }

        /// <summary>
        /// This status represents the need of product to be processed before giving it to a customer.
        /// </summary>
        public bool IsReady { get; set; }

        public override string ToString()
        {
            return string.Format("Product Name: {0}\tPrice: {1,4} rub.", this.Name, this.Price);
        }
    }
}
