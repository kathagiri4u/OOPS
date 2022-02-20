using System;
namespace OopsSln
{
    public class LineOfCreditAccount : BankAccount
    {

        public LineOfCreditAccount(string name, decimal intialBalance):base(name, intialBalance)
        {}

        public override void PerformMonthEndTransactions()
        {
            if(Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithDrawl(interest, DateTime.Now, "Charge Monthly Interest");
            }
        }
    }
}