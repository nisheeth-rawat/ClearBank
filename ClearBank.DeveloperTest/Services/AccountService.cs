using ClearBank.DeveloperTest.Interface;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services;

public class AccountService : IAccountService
{
    private readonly IDataStore _dataStore;
    private Account _account;

    public AccountService(IDataStoreFactory dataStoreFactory)
    {
        _dataStore = dataStoreFactory.GetDataStore();
    }
    
    public Account GetAccount(string accountNumber)
    {
        _account = _dataStore.GetAccount(accountNumber);
        
        return _account;
    }

    public void DebitAndUpdate(decimal debitAmount)
    {
        _account.Debit(debitAmount);

        _dataStore.UpdateAccount(_account);
    }
}
