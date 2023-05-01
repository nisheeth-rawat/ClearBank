using AutoFixture;
using ClearBank.DeveloperTest.Domain;
using ClearBank.DeveloperTest.Types;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Domain;

public class BacsSchemeTests
{
    private readonly Fixture _fixture;

    public BacsSchemeTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesNotAllowed()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.None;

        var bacsScheme = new BacsScheme();

        const bool expected = false;

        // Act
        var actual = bacsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ValidateReturnFalseWhenPaymentSchemesIsAllowed()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        account.AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs;

        var bacsScheme = new BacsScheme();

        const bool expected = true;

        // Act
        var actual = bacsScheme.Validate(paymentRequest, account);

        // Assert
        Assert.Equal(expected, actual);
    }
}
