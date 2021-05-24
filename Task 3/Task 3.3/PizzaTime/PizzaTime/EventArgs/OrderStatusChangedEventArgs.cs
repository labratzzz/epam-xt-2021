namespace PizzaTime.EventArgs
{
    using PizzaTime.Enums;

    public class OrderStatusChangedEventArgs
    {
        // Constructors
        public OrderStatusChangedEventArgs(OrderStatus oldStatus, OrderStatus newStatus)
        {
            this.OldOrderStatus = oldStatus;
            this.NewOrderStatus = newStatus;
        }

        // Properties
        public OrderStatus OldOrderStatus { get; }

        public OrderStatus NewOrderStatus { get; }
    }
}
