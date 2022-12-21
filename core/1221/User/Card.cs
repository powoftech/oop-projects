using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking;

namespace Banking
{
    public class Card
    {
        private DateTime creationDate = DateTime.MinValue;
        private DateTime expirationDate = DateTime.MinValue;
        private String cardNumber = String.Empty; // 16 digits
        private SubBank subBank = null;

        internal DateTime CreationDate
        {
            get { return this.creationDate; }
            set { this.creationDate = value; }
        }
        internal DateTime ExpirationDate
        {
            get { return this.expirationDate; }
            set { this.expirationDate = value; }
        }
        internal String CardNumber
        {
            get { return this.cardNumber; }
            set { this.cardNumber = value; }
        }
        internal SubBank SubBank
        {
            get { return this.subBank; }
            set { this.subBank = value; }
        }
        internal Card()
        {
        }
        internal Card(DateTime creationDate)
        {
            this.creationDate = creationDate;
            this.expirationDate = creationDate.AddYears(5);
        }
        internal Card(DateTime creationDate, SubBank subBank) : this(creationDate)
        {
            this.subBank = subBank;
        }
        ~Card()
        {
        }
        private Int32 RandomNumberGenerator(Int32 length)
        {
            Random random = new Random();
            Int32 begin = (Int32)Math.Pow(10, length - 1);
            Int32 end = (Int32)Math.Pow(10, length);
            return random.Next(begin, end);

        }
        internal void Implement(String userID)
        {
            if (this.subBank != null)
            {
                this.cardNumber = "4" + userID.Substring(0, userID.Length - 3) + RandomNumberGenerator(8).ToString() + SubBank.GetID();
                this.creationDate = DateTime.Now;
                this.expirationDate = CreationDate.AddYears(5);

            }
        }
        internal void ExportInformation()
        {
            Console.WriteLine("Card information: ");
            Console.WriteLine("Sub bank: ", this.subBank.GetName());
            Console.WriteLine("Card number: ", this.cardNumber);
            Console.WriteLine("Creation date: ", this.creationDate.ToString("MM/yyyy"));
            Console.WriteLine("Expiration date: ", this.expirationDate.ToString("MM/yyyy"));
        }
    }
}