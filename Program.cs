using System;


namespace OopsSln
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Giri", 1000);
            Console.WriteLine($"Account {account.Number} was created for the owner {account.Owner} with account balane {account.Balance}");
            account.MakeWithDrawl(500, DateTime.Now, "Rent Payment");
            account.MakeDeposit(250, DateTime.Now, "Friend Paid me back");
            Console.WriteLine(account.GetAccountHistory());


            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithDrawl(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithDrawl(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithDrawl(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());
        
        }
    }
}
