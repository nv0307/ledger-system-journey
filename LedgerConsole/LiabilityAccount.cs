using System;

namespace LedgerConsole
{
   public class LiabilityAccount : Account
{
    public LiabilityAccount(string accountId, decimal openingBalance = 0m)
        : base(accountId, openingBalance) { }

    public override void PostDebit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Debit amount must be positive.", nameof(amount));

        Balance -= amount; // debits DECREASE a liability
    }

    public override void PostCredit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Credit amount must be positive.", nameof(amount));

        Balance += amount; // credits INCREASE a liability
    }
}
}