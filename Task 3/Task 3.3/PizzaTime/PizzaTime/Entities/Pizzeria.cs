namespace PizzaTime.Entities
{
    using System.Collections.Generic;
    using PizzaTime.EventArgs;
    using PizzaTime.Interfaces;

    public class Pizzeria
    {
        // Constructors
        public Pizzeria(string name, IEnumerable<Human> employees)
        {
            this.Name = name;
            this.Employees = new List<Human>(employees);
            this.Account = new Wallet();

            foreach (var employee in this.Employees)
            {
                if (employee is IOrderAcceptor acceptor)
                {
                    acceptor.OnOrderAccepted += this.OnOrderAccepted;
                }
            } 
        }

        // Properties
        public string Name { get; set; }

        public IList<Human> Employees { get; private set; }

        public Wallet Account { get; set; }

        // Methods
        public void OnOrderAccepted(object sender, OrderAcceptedEventArgs e)
        {
            this.Account.Put(e.AcceptedOrder.Total);

            e.AcceptedOrder.CurrentStatus = Enums.OrderStatus.InProgress;

            foreach (var employee in this.Employees)
            {
                if (employee is IOrderProcessor processor)
                {
                    processor.ProcessOrder(e.AcceptedOrder);
                }
            }
        }
    }
}
