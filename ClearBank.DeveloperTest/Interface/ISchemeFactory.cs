using ClearBank.DeveloperTest.Domain;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interface;

public interface ISchemeFactory
{
    Scheme GetPaymentScheme(PaymentScheme paymentScheme);
}
