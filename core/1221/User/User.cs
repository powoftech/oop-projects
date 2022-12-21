using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

enum Permission
{
    Default = 0,
    Administrator = 1
}

namespace Banking
{
    public partial class User : IEquatable<User>
    {
        // Fields
        private String id = String.Empty;
        private String name = String.Empty;
        private DateOnly dateOfBirth = DateOnly.MinValue;
        private Double balance = Double.MinValue;
        private String email = String.Empty;
        private String password = String.Empty;
        // 0 for Default user, 1 for Administrator
        private Permission permission = Permission.Default;
        private List<Transaction> transactionHistory = new List<Transaction>();
        private List<Card> cards = new List<Card>();
        private DateTime registrationDate = DateTime.MinValue;


        // Properties
        internal String GetID()
        {
            return this.id;
        }
        internal void SetID(String id)
        {
            this.id = id;
        }
        internal String GetName()
        {
            return this.name;
        }
        internal void SetName(String name)
        {
            this.name = name;
        }
        internal DateOnly GetDateOfBirth()
        {
            return this.dateOfBirth;
        }
        internal void SetDateOfBirth(DateOnly dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
        internal Double GetBalance()
        {
            return this.balance;
        }
        internal void AddBalance(Double balance)
        {
            this.balance += balance;
        }
        internal void SetBalance(Double balance)
        {
            this.balance = balance;
        }
        internal String GetEmail()
        {
            return this.email;
        }
        internal void SetEmail(String email)
        {
            this.email = email;
        }
        internal String GetPassword()
        {
            return this.password;
        }
        internal void SetPassword(String password)
        {
            this.password = password;
        }
        internal Permission GetPermission()
        {
            return this.permission;
        }
        internal void SetAdministrator()
        {
            this.permission = Permission.Administrator;
        }
        internal List<Transaction> GetTransactionHistory()
        {
            return this.transactionHistory;
        }
        internal void AddTransaction(Transaction transaction)
        {
            this.transactionHistory.Add(transaction);
        }
        internal List<Card> GetCards()
        {
            return this.cards;
        }
        internal DateTime GetRegistrationDate()
        {
            return this.registrationDate;
        }
        internal void SetRegistrationDate(DateTime registrationDate)
        {
            this.registrationDate = registrationDate;
        }

        public User()
        {

        }

        internal User(String id, String name, String dateOfBirth, Double balance, String email, String password, Int32 permission)
        {
            this.id = id;
            this.name = name;

            var formats = new[] { "MM/dd/yyyy" };
            DateOnly.TryParseExact(dateOfBirth, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out this.dateOfBirth);

            this.balance = balance;

            this.email = email;
            this.password = password;

            if (permission == 1)
            {
                this.SetAdministrator();
            }
        }
        ~User()
        {
        }

        public void Input()
        {
            //this.sName = Console.ReadLine();
            //this.sID = Console.ReadLine();
            //string tmp = Console.ReadLine();
            //this.daBirthday = Convert.ToDateTime(tmp);
            //this.dAccountBalance = double.Parse(Console.ReadLine());
        }
        public void Output()
        {
            Console.WriteLine($"ID: {this.id}");
            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Email address: {this.email}");
            Console.WriteLine($"BirthDay: {this.dateOfBirth.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Account balance: {this.balance}");
            Console.WriteLine($"Registration date: {this.registrationDate.ToString("MM/dd/yyyy")}");
            if (this.cards.Count != 0)
            {
                Console.WriteLine("Export cards' information... ");
                Int32 index = 0;
                this.cards.ForEach(delegate (Card card)
                {
                    Console.WriteLine($"Card #{++index}:");
                    card.ExportInformation();
                });
            }
            else
            {
                Console.WriteLine("This user doesn't have any card yet!");
            }
        }

        public void Deposit()
        {
            String doubleString = String.Empty;
            Double depositAmount = Double.MinValue;
            do
            {
                Console.WriteLine("\nEnter the deposit amount: ");
                doubleString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(doubleString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    depositAmount = Double.Parse(doubleString);
                }
            } while (depositAmount == Double.MinValue);

            this.balance += depositAmount;
            Transaction newTransaction = new Transaction(depositAmount, "Yourself", "Deposit");
            this.transactionHistory.Add(newTransaction);
        }

        public void Withdraw()
        {
            String doubleString = String.Empty;
            Double withdrawAmount = Double.MinValue;
            do
            {
                Console.WriteLine("\nEnter the withdraw amount: ");
                doubleString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(doubleString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    withdrawAmount = Double.Parse(doubleString);
                }
            } while (withdrawAmount == Double.MinValue);

            this.balance -= withdrawAmount;
            Transaction newTransaction = new Transaction(-withdrawAmount, "Yourself", "Withdraw");
            this.transactionHistory.Add(newTransaction);
        }
        public void ExportTransactionHistory()
        {
            Int32 index = 0;
            this.transactionHistory.ForEach(delegate (Transaction transaction)
            {
                Console.WriteLine($"Transaction #{++index}:");
                transaction.Output();
            });
        }

        public static bool operator ==(User left, User right)
        {
            return
                left.GetEmail() == right.GetEmail() &&
                left.GetPassword() == right.GetPassword();
        }
        public static bool operator !=(User left, User right)
        {
            return !(left == right);
        }
        public bool Equals(User? other)
        {
            return this.GetEmail() == other?.GetEmail() &&
            this.GetPassword() == other?.GetPassword();
        }
    }
}


// public override bool Equals(object? obj)
// {
//     return (obj is User) &&
//     this.GetEmail() == ((User)obj).GetEmail() &&
//     this.GetPassword() == ((User)obj).GetPassword();
// }
