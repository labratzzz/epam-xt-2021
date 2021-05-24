namespace PizzaTime.Entities
{
    /// <summary>
    /// Represents cold drinks such as Cola, Pepsi and other. 
    /// Since cold drinks doesn't need additional processing it is ready by default.
    /// </summary>
    public class ColdDrink : Product
    {
        // Constructors
        public ColdDrink(string name, decimal price) : base(name, price)
        {
            this.IsReady = true;
        }
    }
}
