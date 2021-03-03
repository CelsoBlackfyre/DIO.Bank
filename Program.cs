using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Account> listAccounts = new List<Account>();
        static void Main(string[] args)
        {
            string OpUser = UserOption();

            while (OpUser.ToUpper() != "X")
            {
                switch (OpUser)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();   
                }
                OpUser = UserOption();
            }
            Console.WriteLine("Have a very safe day !");
            Console.ReadLine();
        }

        private static void Transfer()
        {
            Console.WriteLine("Type the source account: ");
            int indexSourceAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the target account: ");
            int indexTargetAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the amount to be transfered: ");
            double TransferValue = double.Parse(Console.ReadLine());

            listAccounts[indexSourceAccount].Transfer(TransferValue, listAccounts[indexTargetAccount]);
        }

        private static void Withdraw()
        {
            Console.WriteLine("Type the account number: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the withdraw amount: ");
            double WithdrawValue = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].Withdraw(WithdrawValue);
        }

        private static void Deposit()
        {
            Console.WriteLine("Type the account number: ");
            int indexAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Type the deposit amount: ");
            double DepositValue = double.Parse(Console.ReadLine());

            listAccounts[indexAccount].Deposit(DepositValue);
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert new account");
           
            Console.WriteLine("Choose 1 for Natural Person or 2 for Legal Entity: ");
            int inputAccountType = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Type the client name: ");
            string inputName = Console.ReadLine();
            
            Console.WriteLine("Type the initial balance: ");
            double inputBalance = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Type the credit: ");
            double inputCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)inputAccountType,
                balance: inputBalance,
                credit: inputCredit,
                name: inputName);

            listAccounts.Add(newAccount);
        }

        private static void ListAccounts()
        {
            Console.WriteLine("List accounts: ");

            if (listAccounts.Count == 0)
            {
                Console.WriteLine("No account registered. ");
                return;
            }

            for (int i=0; i<listAccounts.Count; i++)
            {
                Account account = listAccounts[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static string UserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to DIO Bank");
            Console.WriteLine("Choose the desired option: ");
            Console.WriteLine("1 - List Accounts");
            Console.WriteLine("2 - Insert new account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Deposit");
            Console.WriteLine("C - Clear Screen");
            Console.WriteLine("X - Quit");
            Console.WriteLine();

            string OpUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpUser;
        }
    }
}
