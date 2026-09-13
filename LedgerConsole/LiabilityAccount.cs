using System;

namespace LedgerConsole
{
// ============================================================
// LiabilityAccount.cs — Learning Notes (Inheritance & Override)
// ============================================================
// • SAME INHERITANCE PATTERN as AssetAccount — but the accounting
//   rule flips: a debit DECREASES a liability, a credit INCREASES it.
//
// • FULL OVERRIDE (no base.PostDebit call): Unlike AssetAccount,
//   this class can't reuse the base class math, since the direction
//   of the balance change is opposite. It re-validates and applies
//   its own logic directly.
//
// • WHY PROTECTED SET MATTERS HERE: This class modifies Balance
//   directly (Balance -= amount / += amount) — only possible because
//   Account declared the setter as "protected", not "private".
//
// • THE CORE LESSON: Same method name, same method signature
//   (PostDebit), completely different math — depending on which
//   subclass is actually running. That's polymorphism.
// ============================================================
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