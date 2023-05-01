using ClearBank.DeveloperTest.Interface;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services;

public class ValidatePaymentService : IValidatePaymentService
{
    private readonly ISchemeFactory _schemeFactory;

    public ValidatePaymentService(ISchemeFactory schemeFactory)
    {
        _schemeFactory = schemeFactory;
    }

    public bool ValidatePaymentRequest(MakePaymentRequest paymentRequest, Account account)
    {
        if (account == null)
        {
            return false;
        }

        var scheme = _schemeFactory.GetPaymentScheme(paymentRequest.PaymentScheme);

        return scheme.Validate(paymentRequest, account);
    }
}
