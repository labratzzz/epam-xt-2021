namespace PizzaTime.EventArgs
{
    using PizzaTime.Entities;

    public class OrderAcceptedEventArgs
    {
        public OrderAcceptedEventArgs(Order acceptedOrder)
        {
            this.AcceptedOrder = acceptedOrder;
        }

        public Order AcceptedOrder { get; } 
    }
}