namespace PizzaTime.Interfaces
{
    using PizzaTime.Entities;

    public interface IOrderProcessor
    {
        /// <summary>
        /// Processes order for customer.
        /// </summary>
        void ProcessOrder(Order order);
    }
}
