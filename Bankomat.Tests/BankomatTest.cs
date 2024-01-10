using Banko;
using FluentAssertions;
namespace BankomatTest;


public class BankomatTest
{
    Bankomat _bankomat;
    Card _card;
    Account _account;

    public BankomatTest()
    {
        _account = new Account();
        _bankomat = new Bankomat();
        _card = new Card(_account);
    }

    //[Fact]
    //public void insertNewCard_CheckIfInserted_ReturnTrue()
    //{
    //    _bankomat.insertCard(_card);
    //    Assert.True(_bankomat.cardInserted);
    //}

    //[Fact]
    //public void insertNewCard_CheckIfInserted_ReturnFalse()
    //{
    //    Assert.False(_bankomat.cardInserted);
    //}

    //[Theory]
    //[InlineData("0123", true)]
    //[InlineData("1235", false)]
    //public void verifyIfPinIsCorrect(string code, bool expected)
    //{
    //    _bankomat.insertCard(_card);
    //    Assert.True(expected == _bankomat.enterPin(code));
    //}

    //[Fact]
    //public void noCardInsertedAfterEjectCard()
    //{
    //    _bankomat.insertCard(_card);
    //    _bankomat.ejectCard();
    //    Assert.False(_bankomat.cardInserted);
    //}

    [Fact]
    public void bankomatInsertCard()
    {
        _bankomat.insertCard(_card);
        _bankomat.cardInserted.Should().BeTrue();  // Assert.True(_bankomat.cardInserted);

        var pinVerification = _bankomat.enterPin("1235");
        pinVerification.Should().BeFalse();  // Assert.False(_bankomat.enterPin("0123"));
        pinVerification = _bankomat.enterPin("0123");
        pinVerification.Should().BeTrue("Fel pin, försök igen");  // Assert.True(_bankomat.enterPin("0123"));

        int startCash = _account.getBalance();
        int withDrawnCash = _bankomat.withdraw(5000);
        Console.WriteLine($"You withdrew {withDrawnCash} and you have a total of {_account.getBalance()} left.");
        _account.getBalance().Should().Be(startCash - withDrawnCash);

        _bankomat.ejectCard();
        _bankomat.cardInserted.Should().BeFalse(); // Assert.False(_bankomat.cardInserted);

        _bankomat.insertCard(_card);
        _bankomat.enterPin("0123"); // Har testats ovan

        withDrawnCash = _bankomat.withdraw(7000);
        withDrawnCash.Should().Be(0);   // Assert.True(withDrawnCash == 0);

        withDrawnCash = _bankomat.withdraw(6000);
        withDrawnCash.Should().Be(6000);      // Assert.True(withDrawnCash == 6000);
    }

}
