using ClearBank.DeveloperTest.Interface;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Service;

public class AccountServiceTests
{
    [Fact]
    void DebitAndUpdateSucceedsWhenDebitedWithDebitAmount()
    {
        // Arrange
        var account = new Account();

        var accountDataStore = new Mock<IDataStore>();
        accountDataStore
            .Setup(store => store.GetAccount(It.IsAny<string>()))
            .Returns(account);

        var dataStoreFactory = new Mock<IDataStoreFactory>();

        dataStoreFactory
            .Setup(x => x.GetDataStore())
            .Returns(accountDataStore.Object);

        var accountService = new AccountService(dataStoreFactory.Object);

        // Act
        accountService.GetAccount("123");
        accountService.DebitAndUpdate(100);

        // Assert
        dataStoreFactory.Verify(x => x.GetDataStore(), Times.Once());
        accountDataStore.Verify(x => x.UpdateAccount(It.IsAny<Account>()), Times.Once());
    }
}
