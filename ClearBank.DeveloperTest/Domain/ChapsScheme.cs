using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Domain;

public class ChapsScheme: Scheme
{
    public override bool Validate(MakePaymentRequest paymentRequest, Account account)
    {
        return CheckPaymentAccess(account) && CheckAccountStatus(account);
    }
    
    public override bool CheckPaymentAccess(Account account)
    {
        return account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps);
    }
    
    private static bool CheckAccountStatus(Account account)
    {
        return account.Status == AccountStatus.Live;
    }
}
