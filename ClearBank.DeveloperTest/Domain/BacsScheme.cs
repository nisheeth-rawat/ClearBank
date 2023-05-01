using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Domain;

public class BacsScheme : Scheme
{
    public override bool Validate(MakePaymentRequest paymentRequest, Account account)
    {
        return CheckPaymentAccess(account);
    }
    
    public override bool CheckPaymentAccess(Account account)
    {
        return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs);
    }
}
