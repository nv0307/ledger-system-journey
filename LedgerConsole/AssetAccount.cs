namespace LedgerConsole
{
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