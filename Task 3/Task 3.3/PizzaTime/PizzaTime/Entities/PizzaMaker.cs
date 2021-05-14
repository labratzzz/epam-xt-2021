namespace PizzaTime.Entities
{
    using System;
    using PizzaTime.Enums;
    using PizzaTime.Interfaces;

    /// <summary>
    /// Represents pizzeria pizza maker that cooks pizza.
    /// </summary>
    public class PizzaMaker : Human, IOrderProcessor
    {
        public PizzaMaker(string firstname, string lastname) : base(firstname, lastname) { }

        public void ProcessOrder(Order order)
        {
            foreach (var position in order.Positions)
            {
                if (position.Product is Pizza pizza)
                {
                    pizza.IsReady = true;
                    position.TimeTakenToGetReady = pizza.AverageTimeToCook * position.Amount * new Random().NextDouble();
                }
                else
                {
                    position.TimeTakenToGetReady = TimeSpan.FromSeconds(30);
                }
            }

            order.CurrentStatus = OrderStatus.Done;
        }
    }
}
