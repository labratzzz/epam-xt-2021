namespace PizzaTime.Interfaces
{
    using PizzaTime.Entities;

    public interface ICustomer
    {
        /// <summary>
        /// Makes order in the specified pizzeria.
        /// </summary>
        bool MakeOrder(Pizzeria pizzeria, Order order);
    }
}
