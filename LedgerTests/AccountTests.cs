using LedgerConsole;
using Xunit;

namespace LedgerTests
{
// ============================================================
// AccountTests.cs — Learning Notes (Testing Polymorphic Behavior)
// ============================================================
// • FIRST TWO TESTS: Confirm each account type's math independently
//   — straightforward AAA (Arrange, Act, Assert) checks, same pattern
//   as TransactionTests.
//
// • THIRD TEST IS THE KEY ONE: Both objects are declared as the
//   BASE type ("Account asset = new AssetAccount(...)"), not the
//   derived type. Yet calling .PostDebit(100m) on each produces
//   DIFFERENT results.
//
// • WHY THAT PROVES POLYMORPHISM: The compiler only sees "Account"
//   on both variables — it has no idea which override will run at
//   compile time. The actual runtime type of the object (Asset vs.
//   Liability) decides which PostDebit logic executes. This is
//   the practical payoff of "virtual" + "override" from Account.cs.
//
// • IF THIS TEST PASSES: It's proof the engine correctly applies
//   different accounting treatments through one shared interface,
//   rather than needing if/else checks scattered through the code.
// ============================================================
    public class AccountTests
    {
        [Fact]
        public void PostDebit_IncreasesBalance_ForAssetAccount()
        {
            // Arrange
            var asset = new AssetAccount("CASH-001", openingBalance: 500m);

            // Act
            asset.PostDebit(100m);

            // Assert
            Assert.Equal(600m, asset.Balance);
        }

        [Fact]
        public void PostDebit_DecreasesBalance_ForLiabilityAccount()
        {
            // Arrange
            var liability = new LiabilityAccount("LOAN-001", openingBalance: 500m);

            // Act
            liability.PostDebit(100m);

            // Assert
            Assert.Equal(400m, liability.Balance);
        }

        [Fact]
        public void IdenticalDebit_ProducesOppositeOutcomes_AcrossAccountTypes()
        {
            // Arrange
            Account asset = new AssetAccount("CASH-002", openingBalance: 500m);
            Account liability = new LiabilityAccount("LOAN-002", openingBalance: 500m);

            // Act — same $100 debit, posted through the base class reference
            asset.PostDebit(100m);
            liability.PostDebit(100m);

            // Assert — polymorphism in action: same method call, different math
            Assert.Equal(600m, asset.Balance);
            Assert.Equal(400m, liability.Balance);
        }
    }
}