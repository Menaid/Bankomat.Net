namespace Banko;


public class Account
{
    public int balance = 60000;

    public int withdraw(int amount)
    {
        if (amount > 0 && balance >= amount)
        {
            balance -= amount;
            return amount;
        }
        else
        {
            return 0;
        }
    }

    public int getBalance()
    {
        return balance;
    }

}