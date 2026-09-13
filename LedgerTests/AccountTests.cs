using LedgerConsole;
using Xunit;

namespace LedgerTests
{
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