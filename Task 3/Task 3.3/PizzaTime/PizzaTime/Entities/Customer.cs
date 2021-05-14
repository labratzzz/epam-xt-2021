namespace PizzaTime.Entities
{
    using System;
    using System.Linq;
    using PizzaTime.Enums;
    using PizzaTime.EventArgs;
    using PizzaTime.Interfaces;

    public class Customer : Human, ICustomer
    {
        public Customer(string firstname, string lastname) : base(firstname, lastname) { }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool MakeOrder(Pizzeria pizzeria, Order order)
        {
            Console.WriteLine("{0} {1} making order #{2} in pizzeria {3}...", this.Fisrtname, this.Lastname, order.Number, pizzeria.Name);
            Console.WriteLine("{0} {1}'s wallet balance: {2} rub.", this.Fisrtname, this.Lastname, this.Wallet.Balance);
            IOrderAcceptor acceptor = pizzeria.Employees.FirstOrDefault(e => e is IOrderAcceptor) as IOrderAcceptor;

            if (!acceptor.Accept(this, order))
            {
                Console.WriteLine("Order #{0} is declined. Insufficient funds.", order.Number);
            }

            return false;
        }

        /// <summary>
        /// Event Handler that listens order progress.
        /// </summary>
        public virtual void OnOrderStatusChanged(object sender, OrderStatusChangedEventArgs e)
        {
            switch (e.NewOrderStatus)
            {
                default:
                    break;
                case OrderStatus.Accepted:
                    Console.WriteLine("Order #{0} is accepted.", (sender as Order).Number);
                    break;
                case OrderStatus.InProgress:
                    Console.WriteLine("Order #{0} now is in progress.", (sender as Order).Number);
                    break;
                case OrderStatus.Done:
                    Console.WriteLine("Order #{0} is done and customer {1} {2} can take it.", (sender as Order).Number, this.Fisrtname, this.Lastname);
                    break;
            }

            if (e.NewOrderStatus == OrderStatus.Done)
            {
                (sender as Order).OnOrderStatusChanged -= this.OnOrderStatusChanged;
            }
        }
    }
}
