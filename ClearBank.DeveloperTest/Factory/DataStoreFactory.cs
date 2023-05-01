using System.Configuration;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interface;

namespace ClearBank.DeveloperTest.Factory;

public class DataStoreFactory : IDataStoreFactory
{
    private readonly string _dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

    public IDataStore GetDataStore()
    {
        return _dataStoreType == "Backup"
            ? new BackupAccountDataStore()
            : new AccountDataStore();
    }
}
