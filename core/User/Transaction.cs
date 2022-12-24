using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class Transaction : IExportable
    {
        private DateTime date = DateTime.MinValue;
        private Double amount;
        private String beneficiary = String.Empty;
        private String type = String.Empty;
        internal DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
        internal Double Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }
        internal String Beneficiary
        {
            get { return this.beneficiary; }
            set { this.beneficiary = value; }
        }
        internal String Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public Transaction()
        {
        }

        public Transaction(Double amount, String beneficiary, String type)
        {
            this.date = DateTime.Now;
            this.amount = amount;
            this.beneficiary = beneficiary;
            this.type = type;
        }
        ~Transaction()
        {
        }

        void IExportable.ExportInformation()
        {
            Console.WriteLine($"  Date: {this.Date.ToString()}");
            Console.WriteLine($"  Amount: {this.Amount}");
            Console.WriteLine($"  Beneficiary: {this.Beneficiary}");
            Console.WriteLine($"  Type: {this.Type}");
        }
    }
}
