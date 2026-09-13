using System;
using LedgerConsole;
using Xunit;

namespace LedgerTests
{

// ============================================================
// TransactionTests.cs — Learning Notes (Unit Testing in C#/xUnit)
// ============================================================
// • UNIT TEST: A small, automated check that verifies one piece of
//   your code behaves correctly, on its own.
//
// • xUnit: The testing framework providing [Fact]/[Theory] and
//   Assert methods below.
//
// • [Fact]: A test with one fixed scenario.
// • [Theory] + [InlineData]: One method, run once per InlineData
//   row, with those values injected as parameters — avoids
//   duplicating near-identical [Fact] methods.
//
// • EACH TEST METHOD IS INDEPENDENT: Its own { } scope, own
//   Assert calls. Nothing "carries over" between methods.
//
// • AAA PATTERN: Arrange (set up inputs) → Act (call the code)
//   → Assert (check the result).
//
// • PICK THE ASSERT THAT MATCHES EXPECTED BEHAVIOR:
//     - Valid input, check a value  → Assert.Equal
//     - Valid input, check true/false → Assert.True / Assert.False
//     - Invalid input, should be rejected → Assert.Throws
//   Using the wrong one fails the test even if your code is correct.
//
// • HOW FAILURES WORK: Assert.Equal/True don't just "check" —
//   on mismatch they THROW an xUnit exception (e.g. EqualException).
//   You never see this because xUnit's test runner itself acts as
//   the try/catch: it catches ANY unhandled exception from a test
//   method (assertion failure, bug, whatever) and reports that test
//   as Failed. Assert.Throws is different: it's for the one case
//   where YOU deliberately catch and verify an exception is
//   expected behavior (e.g. constructor rejecting bad input).
// ============================================================
        public class TransactionTests
    {
        [Fact]
        public void Constructor_SetsAmountAndAccountId()
        {
            // Arrange
            decimal expectedAmount = 150.00m;
            string expectedAccountId = "ACC-1001";

            // Act
            var transaction = new Transaction(expectedAmount, expectedAccountId);

            // Assert
            Assert.Equal(expectedAmount, transaction.Amount);
            Assert.Equal(expectedAccountId, transaction.AccountId);
        }

        [Fact]
        public void IsCredit_ReturnsTrue_WhenAmountIsPositive()
        {
            // Arrange
            var transaction = new Transaction(200.00m, "ACC-1002");

            // Act
            bool result = transaction.IsCredit();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDebit_ReturnsTrue_WhenAmountIsNegative()
        {
            // Arrange
            var transaction = new Transaction(-75.50m, "ACC-1003");

            // Act
            bool result = transaction.IsDebit();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(0, "ACC-1004")]
        [InlineData(100, "")]
        [InlineData(100, null)]
        public void Constructor_ThrowsArgumentException_ForInvalidInput(decimal amount, string accountId)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Transaction(amount, accountId));
        }
    }
}