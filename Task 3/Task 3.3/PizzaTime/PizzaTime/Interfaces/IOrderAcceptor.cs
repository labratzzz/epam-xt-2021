namespace PizzaTime.Interfaces
{
    using PizzaTime.Delegates;
    using PizzaTime.Entities;

    public interface IOrderAcceptor
    {
        event OrderAcceptedEventHandler OnOrderAccepted;
        
        /// <summary>
        /// Accepts order from customer and returns result of creating it from given positions.
        /// </summary>
        bool Accept(Customer customer, Order order);
    }
}
