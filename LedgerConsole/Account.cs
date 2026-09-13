using System;

namespace LedgerConsole
{
// ============================================================
// Account.cs — Learning Notes (Abstraction & Polymorphism in C#)
// ============================================================
// • ABSTRACT CLASS: Cannot be instantiated directly (no "new Account()").
//   It only exists to be inherited from — it defines a shared shape,
//   not a real, standalone object.
//
// • PROTECTED SET: Balance can be read by anyone (public get), but
//   only this class AND its subclasses can change it (protected set).
//   Stricter than public, looser than private — the right level for
//   data that subclasses legitimately need to modify.
//
// • VIRTUAL METHODS (PostDebit, PostCredit): Provide a DEFAULT
//   implementation, but explicitly allow subclasses to replace it
//   with "override". Without "virtual" here, subclasses couldn't
//   change this behavior at all.
//
// • WHY THIS MATTERS: Different account types (asset vs. liability)
//   need fundamentally different math for the same operation. This
//   class defines the common contract; subclasses define the specifics.
// ============================================================
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