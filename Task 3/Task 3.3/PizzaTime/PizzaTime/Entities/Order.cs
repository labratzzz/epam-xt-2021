namespace PizzaTime.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PizzaTime.Delegates;
    using PizzaTime.Enums;
    using PizzaTime.EventArgs;

    /// <summary>
    /// Represents an order that contains it's product positions.
    /// </summary>
    public class Order
    {
        // Fields
        private IList<OrderPosition> positions;

        private OrderStatus currentStatus;

        // Constructors
        public Order(IEnumerable<OrderPosition> positions)
        {
            if (positions is null) throw new ArgumentNullException(nameof(positions), "Order positions can't be null");
            if (!positions.Any()) throw new ArgumentNullException(nameof(positions), "Order positions must contain at least one product");

            this.Number = ++LastOrderNumber;
            this.currentStatus = OrderStatus.Accepted;
            this.positions = new List<OrderPosition>(positions);
        }

        // Events
        public event OrderStatusChangedEventHandler OnOrderStatusChanged;

        // Properties
        public int Number { get; }

        public IList<OrderPosition> Positions
        {
            get => new List<OrderPosition>(this.positions);
        }

        public OrderStatus CurrentStatus
        {
            get => this.currentStatus;
            set
            {
                if (this.currentStatus == value)
                {
                    return;
                }

                if (this.OnOrderStatusChanged != null)
                {
                    OrderStatusChangedEventArgs e = new OrderStatusChangedEventArgs(this.currentStatus, value);
                    this.OnOrderStatusChanged.Invoke(this, e);
                }

                this.currentStatus = value;
            }
        }

        public decimal Total
        {
            get => this.positions.Sum(p => p.Product.Price * p.Amount);
        }

        public TimeSpan TotalTimeTaken
        {
            get
            {
                TimeSpan time = new TimeSpan();
                foreach (var position in this.Positions)
                {
                    time += position.TimeTakenToGetReady;
                }

                return time;
            }
        }

        private static int LastOrderNumber { get; set; }

        // Methods
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string nl = Environment.NewLine;

            output.AppendFormat("Order #{1}. Positions:{0}", nl, this.Number);

            int line = 0;
            foreach (var position in this.positions)
            {
                output.AppendFormat("{1}. {2}{0}", nl, ++line, position.ToString());
            }

            output.AppendFormat("Total order price: {1} rub.{0}", nl, this.Total);
            output.AppendFormat("Total time taken: {1} min.{0}", nl, this.TotalTimeTaken.Minutes);

            return output.ToString();
        }
    }
}
