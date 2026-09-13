namespace LedgerConsole
{
// ============================================================
// AssetAccount.cs — Learning Notes (Inheritance & Override)
// ============================================================
// • INHERITANCE: ": Account" means AssetAccount IS-A Account — it
//   automatically gets AccountId, Balance, and the base methods.
//
// • CONSTRUCTOR CHAINING (": base(...)"): Passes values up to
//   Account's constructor to handle validation and setup, instead
//   of duplicating that logic here.
//
// • OVERRIDE: Explicitly restates the debit/credit behavior for
//   THIS account type, even though it matches the base class default.
//   This makes the accounting rule visible here, not just inherited
//   silently — a debit increases an asset, a credit decreases it.
//
// • base.PostDebit(...) / base.PostCredit(...): Calls the parent
//   class's original implementation instead of rewriting it, since
//   the logic is identical — avoids duplicating validation code.
// ============================================================
    public class AssetAccount : Account
    {
        public AssetAccount(string accountId, decimal openingBalance = 0m)
            : base(accountId, openingBalance) { }

        // Debits INCREASE an asset — this matches the base class default,
        // but we override explicitly so the behavior is documented here too.
        public override void PostDebit(decimal amount)
        {
            base.PostDebit(amount); // reuse base validation + increase logic
        }

        public override void PostCredit(decimal amount)
        {
            base.PostCredit(amount); // credits decrease assets — base default is correct
        }
    }
}