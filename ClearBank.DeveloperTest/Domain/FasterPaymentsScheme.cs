using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Domain;

public class FasterPaymentsScheme: Scheme
{
    public override bool Validate(MakePaymentRequest paymentRequest, Account account)
    {
        return CheckPaymentAccess(account) && CheckAccountBalance(paymentRequest, account);
    }
    
    public override bool CheckPaymentAccess(Account account)
    {
        return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments);
    }
    
    private bool CheckAccountBalance(MakePaymentRequest paymentRequest, Account account)
    {
        return account.Balance >= paymentRequest.Amount;
    }
}
