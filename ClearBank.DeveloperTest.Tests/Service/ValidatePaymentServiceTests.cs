using AutoFixture;
using ClearBank.DeveloperTest.Domain;
using ClearBank.DeveloperTest.Interface;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Service;

public class ValidatePaymentServiceTests
{
    private readonly Fixture _fixture;

    public ValidatePaymentServiceTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    void ReturnsFalseWhenAccountIsNull()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        Account account = null;
        
        var mockScheme = new Mock<Scheme>();
        mockScheme
            .Setup(scheme => scheme.Validate(paymentRequest, account))
            .Returns(true);

        var schemeFactory = new Mock<ISchemeFactory>();
        schemeFactory
            .Setup(factory => factory.GetPaymentScheme(It.IsAny<PaymentScheme>()))
            .Returns(mockScheme.Object);

        var validatePaymentService = new ValidatePaymentService(schemeFactory.Object);

        var expected = false;

        // Act
        var actual = validatePaymentService.ValidatePaymentRequest(paymentRequest, account);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    void ReturnsFalseWhenValidationFailsForTheScheme()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        
        var mockScheme = new Mock<Scheme>();
        mockScheme
            .Setup(scheme => scheme.Validate(paymentRequest, account))
            .Returns(false);

        var schemeFactory = new Mock<ISchemeFactory>();
        schemeFactory
            .Setup(factory => factory.GetPaymentScheme(It.IsAny<PaymentScheme>()))
            .Returns(mockScheme.Object);

        var validatePaymentService = new ValidatePaymentService(schemeFactory.Object);

        const bool expected = false;

        // Act
        var actual = validatePaymentService.ValidatePaymentRequest(paymentRequest, account);
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    void ReturnsTrueWhenValidationSucceedForTheScheme()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();
        var account = _fixture.Create<Account>();
        
        var mockScheme = new Mock<Scheme>();
        mockScheme
            .Setup(scheme => scheme.Validate(paymentRequest, account))
            .Returns(true);

        var schemeFactory = new Mock<ISchemeFactory>();
        schemeFactory
            .Setup(factory => factory.GetPaymentScheme(It.IsAny<PaymentScheme>()))
            .Returns(mockScheme.Object);

        var validatePaymentService = new ValidatePaymentService(schemeFactory.Object);

        const bool expected = true;

        // Act
        var actual = validatePaymentService.ValidatePaymentRequest(paymentRequest, account);
        
        // Assert
        Assert.Equal(expected, actual);
    }
}
