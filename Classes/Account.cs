using System;

namespace DIO.Bank
{
    public class Account
    {
        private AccountType AccountType {get;set;}
        
        private string Name {get; set;}

        private double Credit {get;set;}

        private double Balance {get;set;}


        public Account (AccountType accountType, double balance, double credit, string name)
        {
            this.AccountType = accountType;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw(double WithdrawValue)
        {
            if (this.Balance - WithdrawValue < (this.Credit * -1))
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }

            this.Balance -= WithdrawValue;
            Console.WriteLine("{0} current account balance is: {1} ", this.Name, this.Balance);
            return true;
        }

        public void Deposit(double DepositValue)
        {
            this.Balance += DepositValue;
            Console.WriteLine("{0} current account balance is: {1}",this.Name, this.Balance);
        }

        public void Transfer (double TransferValue, Account TargetAccount)
        {
            if (this.Withdraw(TransferValue))
            {
                TargetAccount.Deposit(TransferValue);
            }
        }

        public override string ToString()
        {
            string Return = " ";
            Return += "Account Type " + this.AccountType + " | ";
            Return += "Name " + this.Name + " | ";
            Return += "Balance " + this.Balance + " | ";
            Return += "Credit " + this.Credit;
            return Return;
        }

    }
}