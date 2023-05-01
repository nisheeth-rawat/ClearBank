using AutoFixture;
using ClearBank.DeveloperTest.Interface;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Service;

public class PaymentServiceTests
{
    private readonly Fixture _fixture;
    public PaymentServiceTests()
    {
        _fixture = new Fixture();
    }
    
    [Fact]
    void MakePaymentRequestWithInvalidAccountNumberReturnsFalsePaymentResult()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();

        var accountService = new Mock<IAccountService>();
        accountService
            .Setup(service => service.GetAccount(It.IsAny<string>()));

        var validatePaymentService = new Mock<IValidatePaymentService>();
        validatePaymentService
            .Setup(service => service.ValidatePaymentRequest(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
            .Returns(false);
        
        var paymentService = new PaymentService(accountService.Object, validatePaymentService.Object);
        
        var expected = new MakePaymentResult() { Success = false };

        // Act
        var actual = paymentService.MakePayment(paymentRequest);

        // Assert
        Assert.Equal(expected.Success, actual.Success);
    }
    
    [Fact]
    void MakePaymentRequestWithValidAccountReturnsTruePaymentResult()
    {
        // Arrange
        var paymentRequest = _fixture.Create<MakePaymentRequest>();

        var accountService = new Mock<IAccountService>();
        accountService
            .Setup(service => service.GetAccount(It.IsAny<string>()));
        accountService
            .Setup(service => service.DebitAndUpdate(It.IsAny<decimal>()));

        var validatePaymentService = new Mock<IValidatePaymentService>();
        validatePaymentService
            .Setup(service => service.ValidatePaymentRequest(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()))
            .Returns(true);
        
        var paymentService = new PaymentService(accountService.Object, validatePaymentService.Object);
        
        var expected = new MakePaymentResult() { Success = true };

        // Act
        var actual = paymentService.MakePayment(paymentRequest);

        // Assert
        Assert.Equal(expected.Success, actual.Success);
    }
}
