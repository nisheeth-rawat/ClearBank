using AutoFixture;
using ClearBank.DeveloperTest.Domain;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Domain;

public class FasterPaymentsSchemeTests
{
    private readonly Fixture _fixture;

    public FasterPaymentsSchemeTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesNotAllowedAndAccountBalanceLessThanPaymentRequestAmount()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        paymentRequest.Amount = 1000;
        
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.None;
        account.Balance = 100;
        
        var fasterPaymentsScheme = new FasterPaymentsScheme();

        const bool expected = false;

        // Act
        var actual = fasterPaymentsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesIsAllowedAndAccountBalanceLessThanPaymentRequestAmount()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        paymentRequest.Amount = 1000;
        
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
        account.Balance = 100;

        var fasterPaymentsScheme = new FasterPaymentsScheme();

        const bool expected = false;

        // Act
        var actual = fasterPaymentsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesIsNotAllowedAndAccountBalanceEqualsPaymentRequestAmount()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        paymentRequest.Amount = 1000;
        
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.None;
        account.Balance = 1000;

        var fasterPaymentsScheme = new FasterPaymentsScheme();

        const bool expected = false;

        // Act
        var actual = fasterPaymentsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesIsNotAllowedAndAccountBalanceGreaterThanPaymentRequestAmount()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        paymentRequest.Amount = 1000;
        
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.None;
        account.Balance = 10000;

        var fasterPaymentsScheme = new FasterPaymentsScheme();

        const bool expected = false;

        // Act
        var actual = fasterPaymentsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnTrueWhenPaymentSchemesIsAllowedAndAccountBalanceEqualsPaymentRequestAmount()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        paymentRequest.Amount = 1000;
        
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
        account.Balance = 1000;

        var fasterPaymentsScheme = new FasterPaymentsScheme();

        const bool expected = true;

        // Act
        var actual = fasterPaymentsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnTrueWhenPaymentSchemesIsAllowedAndAccountBalanceGreaterThanPaymentRequestAmount()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        paymentRequest.Amount = 1000;
        
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments;
        account.Balance = 10000;

        var fasterPaymentsScheme = new FasterPaymentsScheme();

        const bool expected = true;

        // Act
        var actual = fasterPaymentsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
}
