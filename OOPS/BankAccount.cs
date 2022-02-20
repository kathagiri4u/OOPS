using System.Net.Mime;
using System;
using System.Collections.Generic;
namespace OopsSln
{
    public class BankAccount
    {
        public string Number {get;}
        public string Owner {get;set;}

        private static int accountNumberSeed=1234567890;
        public decimal Balance {
            get{
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
        }}

        private static List<Transaction> allTransactions = new List<Transaction>();

        public virtual void PerformMonthEndTransactions(){}

        public BankAccount(string name , decimal initialBalance)
        {
            this.Owner = name;
            
            this.Number=accountNumberSeed.ToString();
            accountNumberSeed++;

            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");

        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of Deposit Must be Positive");
            }
            var deposit = new Transaction(amount,date,note);
            allTransactions.Add(deposit);
        }

        public void MakeWithDrawl(decimal amount, DateTime date, string note )
        {
            if(amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of Withdrawl must be positive");
            }
            if(Balance-amount <0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance =0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");

            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }


    }
}