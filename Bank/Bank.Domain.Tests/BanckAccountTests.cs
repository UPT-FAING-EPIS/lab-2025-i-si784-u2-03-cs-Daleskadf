using Bank.Domain;
using NUnit.Framework;

namespace Bank.Domain.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
                [Test]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }
        [Test]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(BankAccount.DebitAmountExceedsBalanceMessage, e.Message);
            }
        }
        [Test]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 100.00;
            double creditAmount = 50.55;
            double expectedBalance = 150.55;
            BankAccount account = new BankAccount("Ms. Jane Doe", beginningBalance);
            account.Credit(creditAmount);
            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance, 0.001, "Account not credited correctly");
        }
        [Test]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 100.00;
            double creditAmount = -50.00;
            BankAccount account = new BankAccount("Ms. Jane Doe", beginningBalance);
            var ex = Assert.Throws<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
            StringAssert.Contains(BankAccount.CreditAmountLessThanZeroMessage, ex.Message);
        }
    }
}