namespace PizzaTime.Entities
{
    using System;

    /// <summary>
    /// Represents money storage.
    /// </summary>
    public struct Wallet
    {
        // Constructors
        public Wallet(decimal startMoney)
        {
            if (startMoney < 0) throw new ArgumentException("Money value must be positive", nameof(startMoney));

            this.Balance = startMoney;
        }

        // Properties
        public decimal Balance { get; private set; }

        // Methods

        /// <summary>
        /// Puts specified money amount to wallet.
        /// </summary>
        /// <param name="money">Amount of money to put.</param>
        public bool Put(decimal money)
        {
            if (money < 0) throw new ArgumentException("Money value must be positive", nameof(money));

            this.Balance += money;

            return true;
        }

        /// <summary>
        /// Withdraws specified money amount from wallet.
        /// </summary>
        /// <param name="money">Amount of money to withdraw.</param>
        public bool Withdraw(decimal money)
        {
            if (money < 0) throw new ArgumentException("Money value must be positive", nameof(money));

            decimal newBalance = this.Balance - money;

            if (newBalance >= 0)
            {
                this.Balance = newBalance;
                return true;
            }
            
            return false;
        }

        public bool Transfer(Wallet anotherWallet, decimal money)
        {
            if (this.Withdraw(money))
            {
                anotherWallet.Put(money);
                return true;
            }

            return false;
        }
    }
}
