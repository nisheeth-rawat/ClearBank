using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interface;

public interface IValidatePaymentService
{
    bool ValidatePaymentRequest(MakePaymentRequest paymentRequest, Account account);
}
