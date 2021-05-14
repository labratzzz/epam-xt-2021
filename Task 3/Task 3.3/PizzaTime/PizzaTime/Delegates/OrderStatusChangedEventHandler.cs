namespace PizzaTime.Delegates
{
    using PizzaTime.EventArgs;

    public delegate void OrderStatusChangedEventHandler(object sender, OrderStatusChangedEventArgs e);
}
