using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Domain;

public abstract class Scheme
{
    public abstract bool CheckPaymentAccess(Account account);
    
    public abstract bool Validate(MakePaymentRequest paymentRequest, Account account);
}
