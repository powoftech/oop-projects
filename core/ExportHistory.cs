using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
	internal class ExportHistory
	{
		private DateTime dDateTransaction;
		private double dBalance;
		private double dAmount;
		private string dTransactionType;
		private int iType;
		public double balance
		{
			get { return this.dBalance; }
			set { this.dBalance = value; }
		}
		public DateTime dateTransaction
		{
			get { return this.dDateTransaction; }
			set { this.dDateTransaction = value; }
		}
		public double amount
		{
			get { return this.dAmount; }
			set { this.dAmount = value; }
		}
		public string transactionType
		{
			get { return this.dTransactionType; }
			set { this.dTransactionType = value; }
		}
		public int type
		{
			get { return this.iType; }
			set { this.iType = value; }
		}

		public ExportHistory() { }
		public ExportHistory(DateTime dateTransaction) { this.dDateTransaction = dateTransaction; }
		public ExportHistory(DateTime dateTransaction, double amount) : this(dateTransaction) { this.dAmount = amount; }
		public ExportHistory(DateTime dateTransaction, double amount, string transactionType) : this(dateTransaction, amount) { this.dTransactionType = transactionType; }
		public ExportHistory(DateTime dateTransaction, double amount, string transactionType, double balance) : this(dateTransaction, amount, transactionType) { this.dBalance = balance; }
		public ExportHistory(DateTime dateTransaction, double amount, string transactionType, double balance, int type) : this(dateTransaction, amount, transactionType, balance) { this.iType = type; }
		~ExportHistory() { }


	}
}
