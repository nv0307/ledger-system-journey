using System;

namespace LedgerConsole
{
    public abstract class Account
    {
        public string AccountId { get; private set; }
        public decimal Balance { get; protected set; }

        protected Account(string accountId, decimal openingBalance = 0m)
        {
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("AccountId cannot be null or empty.", nameof(accountId));

            AccountId = accountId;
            Balance = openingBalance;
        }

        // virtual = derived classes CAN override this, but don't have to
        public virtual void PostDebit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Debit amount must be positive.", nameof(amount));

            Balance += amount; // default behavior — subclasses will override
        }

        public virtual void PostCredit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Credit amount must be positive.", nameof(amount));

            Balance -= amount;
        }

        public override string ToString() => $"{AccountId}: {Balance:C}";
    }
}