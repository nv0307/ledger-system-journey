using System;

namespace LedgerConsole
{
// ============================================================
// Transaction.cs — Learning Notes (OOP Concepts in C#)
// ============================================================
// • CLASS: A blueprint for creating objects. "Transaction" defines
//   what data (properties) and behavior (methods) every transaction
//   object will have.
//
// • ENCAPSULATION: Bundling data (Amount, AccountId) together with
//   the logic that protects it, so outside code can't misuse it.
//
// • PROPERTIES (get; private set;): 
//     - "get" = anyone can READ the value (e.g., transaction.Amount)
//     - "private set" = only THIS class can WRITE the value
//     - This prevents external code from tampering with data after
//       the object is created — a core OOP principle.
//
// • CONSTRUCTOR (public Transaction(...)): 
//     - Special method that runs when you create a new object
//       (e.g., new Transaction(100, "ACC-1"))
//     - Used here to validate input BEFORE the object exists, so an
//       invalid Transaction can never be created in the first place.
//
// • IMMUTABILITY: Once a Transaction is created, its values can't
//   change. This makes the object predictable and safer to pass
//   around your program.
//
// • METHODS (IsCredit, IsDebit): 
//     - Small, self-contained behaviors that belong to the object,
//       rather than scattered logic elsewhere in the codebase.
//
// • ToString() OVERRIDE: 
//     - Customizes how the object prints itself (e.g., in Console.
//       WriteLine), instead of showing the default class name.
// ============================================================
    public class Transaction
    {
        public decimal Amount { get; private set; } // High-precision decimal for financial accuracy
        public string AccountId { get; private set; } // Unique identifier for the account associated with the transaction
        public DateTime TransactionDate { get; private set; } // Timestamp for when the transaction was created

        public Transaction(decimal amount, string accountId) // Constructor initializes a new transaction with amount and account ID
        {
            if (string.IsNullOrWhiteSpace(accountId))
                throw new ArgumentException("AccountId cannot be null or empty.", nameof(accountId));

            if (amount == 0)
                throw new ArgumentException("Amount cannot be zero.", nameof(amount));

            Amount = amount;
            AccountId = accountId;
            TransactionDate = DateTime.UtcNow;
        }

        public bool IsCredit() => Amount > 0; // Determines if the transaction is a credit (positive amount)
        public bool IsDebit() => Amount < 0; // Determines if the transaction is a debit (negative amount)

        public override string ToString() => // Provides a string representation of the transaction
            $"{TransactionDate:u} | {AccountId} | {Amount:C}";
    }
}