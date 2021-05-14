namespace PizzaTime.Entities
{
    using System;

    public class OrderPosition
    {
        public OrderPosition(Product product, int amount)
        {
            if (product is null) throw new ArgumentException("Product can't be null", nameof(product));
            if (amount <= 0) throw new ArgumentException("Amount must be greater than zero", nameof(amount));

            this.Product = product;
            this.Amount = amount;
        }

        public Product Product { get; private set; }

        public int Amount { get; private set; }

        public TimeSpan TimeTakenToGetReady { get; set; }

        public override string ToString()
        {
            return this.Product.ToString() + string.Format("\tAmount:{0}\tTotal price:{1,5} rub.", this.Amount, this.Product.Price * this.Amount);
        }
    }
}
