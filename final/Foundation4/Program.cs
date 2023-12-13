using System;

class Program
{
    static void Main()
    {
        BankAccount savingsAccount = new SavingsAccount("SAV-123456");
        BankAccount checkingAccount = new CheckingAccount("CHEK-789012");

        savingsAccount.Deposit(500);
        checkingAccount.Deposit(1000);

        savingsAccount.Withdraw(100);
        checkingAccount.Withdraw(200);

        DisplayAccountDetails(savingsAccount);
        DisplayAccountDetails(checkingAccount);
    }

    static void DisplayAccountDetails(BankAccount account)
    {
        Console.WriteLine("Hi Erick!");
        account.DisplayBalance();
        Console.WriteLine();
    }
}
class BankAccount
{
    protected string accountNumber;
    protected decimal balance;

    public BankAccount(string accountNumber)
    {
        this.accountNumber = accountNumber;
        balance = 0;
    }

    public virtual void Deposit(decimal amount)
    {
        balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public virtual void DisplayBalance()
    {
        Console.WriteLine($"Account Number: {accountNumber} \nBalance: ${balance}");
        Console.WriteLine("Account Type: Undefined");
    }
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountNumber)
        : base(accountNumber)
    {
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
    }

    public override void DisplayBalance()
    {
        Console.WriteLine($"Account Number: {accountNumber} \nBalance: ${balance}");
        Console.WriteLine("Account: Savings Account");
    }
}

class CheckingAccount : BankAccount
{
    public CheckingAccount(string accountNumber)
        : base(accountNumber)
    {
    }

    public override void Withdraw(decimal amount)
    {
        base.Withdraw(amount);
    }

    public override void DisplayBalance()
    {
        Console.WriteLine($"Account Number: {accountNumber} \nBalance: ${balance}");
        Console.WriteLine("Account: Checking Account");
    }
}


