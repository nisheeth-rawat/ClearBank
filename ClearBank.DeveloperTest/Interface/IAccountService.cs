using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Interface;

public interface IAccountService
{
    Account GetAccount(string accountNumber);
    void DebitAndUpdate(decimal debitAmount);
}
