using AutoFixture;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Types;

public class AccountTests
{
    private readonly Fixture _fixture;
    public AccountTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void DebitAccountBalanceByDebitAmount()
    {
        // Arrange
        const decimal debitAmount = 100;
        var account = _fixture.Create<Account>();
        account.Balance = 1000;

        var expectedBalance = 900;
        
        // Act
        account.Debit(debitAmount);
        var actualBalance = account.Balance;
        
        //Assert
        Assert.Equal(expectedBalance, actualBalance);
    }
}
