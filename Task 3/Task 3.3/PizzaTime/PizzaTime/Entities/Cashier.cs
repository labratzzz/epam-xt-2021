namespace PizzaTime.Entities
{
    using PizzaTime.Delegates;
    using PizzaTime.EventArgs;
    using PizzaTime.Interfaces;

    /// <summary>
    /// Represents pizzeria cashier that works in pizzeria's building and accept orders in it.
    /// </summary>
    public class Cashier : Human, IOrderAcceptor
    {
        // Constructors
        public Cashier(string firstname, string lastname) : base(firstname, lastname) { }

        // Events
        public event OrderAcceptedEventHandler OnOrderAccepted;

        public bool Accept(Customer customer, Order order)
        {
            if (customer.Wallet.Withdraw(order.Total))
            {
                order.OnOrderStatusChanged += customer.OnOrderStatusChanged;

                OrderAcceptedEventArgs e = new OrderAcceptedEventArgs(order);
                this.OnOrderAccepted?.Invoke(this, e);

                return true;
            }

            return false;
        }
    }
}
