namespace PizzaTime
{
    using System;
    using PizzaTime.Entities;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Human[] employees = new Human[]
                {
                    new Cashier("Kate", "Mossman"),
                    new PizzaMaker("Greg", "Cooper")
                };

            Pizzeria johnDoe = new Pizzeria("JohnDoe", employees);

            Customer alex = new Customer("Alex",   "Breen") { Wallet = new Wallet(800m) };
            Customer diane = new Customer("Diane", "Royce") { Wallet = new Wallet(3200m) };

            Pizza[] pizzaList = new Pizza[]
            {
                new Pizza("Pepperoni",           450, TimeSpan.FromMinutes(15)),
                new Pizza("Four cheeses",        450, TimeSpan.FromMinutes(30)),
                new Pizza("Chicken Bacon Ranch", 600, TimeSpan.FromMinutes(12)),
                new Pizza("Chicken BBQ",         500, TimeSpan.FromMinutes(17)),
                new Pizza("Texas Heat",          550, TimeSpan.FromMinutes(20))
            };

            ColdDrink[] coldDrinksList = new ColdDrink[]
            {
                new ColdDrink("Pepsi-Cola",   45),
                new ColdDrink("Coca-Cola",    45),
                new ColdDrink("7-UP",         45),
                new ColdDrink("Mountain Dew", 45)
            };

            Order order1 = new Order(new OrderPosition[] 
                { 
                    new OrderPosition(coldDrinksList[0], 2),
                    new OrderPosition(pizzaList[1], 1)
                });

            Order order2 = new Order(new OrderPosition[]
            {
                    new OrderPosition(coldDrinksList[0], 2),
                    new OrderPosition(coldDrinksList[2], 1),
                    new OrderPosition(coldDrinksList[3], 1),
                    new OrderPosition(pizzaList[1], 1),
                    new OrderPosition(pizzaList[3], 2),
                    new OrderPosition(pizzaList[2], 3),
            });

            Order order3 = new Order(new OrderPosition[]
            {
                    new OrderPosition(coldDrinksList[0], 2),
                    new OrderPosition(pizzaList[1], 1)
            });

            alex.MakeOrder(johnDoe, order1);
            Console.WriteLine(order1.ToString());

            Program.CheckPizzeria(johnDoe);
            Console.WriteLine();

            diane.MakeOrder(johnDoe, order2);
            Console.WriteLine(order2.ToString());

            Program.CheckPizzeria(johnDoe);
            Console.WriteLine();

            diane.MakeOrder(johnDoe, order3);
            Console.WriteLine(order3.ToString());

            Program.CheckPizzeria(johnDoe);
        }

        public static void CheckPizzeria(Pizzeria pizzeria) => Console.WriteLine("{0} pizzeria's balance now is {1} rub.", pizzeria.Name, pizzeria.Account.Balance);
    }
}
