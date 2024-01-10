using Banko;

namespace BankomatTest;


public class AccountTest
{
    Bankomat _bankomat;
    Card _card;
    Account _account;

    public AccountTest()
    {
        _account = new Account();
        _bankomat = new Bankomat();
        _card = new Card(_account);
    }


    //[Theory]
    //[InlineData(5000)]
    //[InlineData(2500)]
    //public void withdrawMoneyIsTrue(int cash)
    //{
    //    int startCash = _account.getBalance();
    //    _bankomat.insertCard(_card);
    //    _bankomat.enterPin("0123");
    //    int withDrawnCash = _bankomat.withdraw(cash);
    //    Console.WriteLine($"You withdrew {withDrawnCash} and you have a total of {_account.getBalance()} left.");
    //    Assert.True(_account.getBalance() == startCash - withDrawnCash);
    //}
}


