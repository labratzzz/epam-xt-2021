namespace PizzaTime.Entities
{
    using System;

    /// <summary>
    /// Represents pizza (unexpected, isn't it?). 
    /// Since pizza not appears magically - someone needs to cook it.
    /// That's why class contains info about average cooking time.
    /// </summary>
    public class Pizza : Product
    {
        // Constructors

        /// <summary>
        /// Creates an instance of pizza. 
        /// Average cooking time is limited by 60 minutes.
        /// </summary>
        public Pizza(string name, decimal price, TimeSpan averageTimeToCook) : base(name, price)
        {
            if (averageTimeToCook > TimeSpan.FromMinutes(60)) throw new ArgumentException("Average time to cook must not be longer than 60 minutes", nameof(averageTimeToCook));

            this.AverageTimeToCook = averageTimeToCook;
        }

        // Properties
        public TimeSpan AverageTimeToCook { get; protected set; }
    }
}
