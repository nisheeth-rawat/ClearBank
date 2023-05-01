using System;
using ClearBank.DeveloperTest.Domain;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Factory;

public class SchemeFactory
{
    public Scheme GetPaymentScheme(PaymentScheme paymentScheme)
    {
        return paymentScheme switch
        {
            PaymentScheme.Bacs => new BacsScheme(),
            PaymentScheme.FasterPayments => new FasterPaymentsScheme(),
            PaymentScheme.Chaps => new ChapsScheme(),
            _ => throw new ArgumentOutOfRangeException(nameof(paymentScheme), paymentScheme, "Invalid Payment Scheme")
        };
    }
}
