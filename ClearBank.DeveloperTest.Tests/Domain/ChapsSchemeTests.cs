using AutoFixture;
using ClearBank.DeveloperTest.Domain;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Domain;

public class ChapsSchemeTests
{
    private readonly Fixture _fixture;

    public ChapsSchemeTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesNotAllowedAndStatusIsNotSet()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.None;
        account.Status = AccountStatus.None;
        
        var chapsScheme = new ChapsScheme();

        const bool expected = false;

        // Act
        var actual = chapsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesIsAllowedAndStatusIsNotSet()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
        account.Status = AccountStatus.None;

        var chapsScheme = new ChapsScheme();

        const bool expected = false;

        // Act
        var actual = chapsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesIsNotAllowedAndStatusIsLive()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.None;
        account.Status = AccountStatus.Live;

        var chapsScheme = new ChapsScheme();

        const bool expected = false;

        // Act
        var actual = chapsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnTrueWhenPaymentSchemesIsAllowedAndStatusIsLive()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps;
        account.Status = AccountStatus.Live;

        var chapsScheme = new ChapsScheme();

        const bool expected = true;

        // Act
        var actual = chapsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
}
