using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
	internal static class MainBank
	{
		private static string sBankName;
		private static List<User> uUser;

		public static void transfer()
		{
			int opt = 0;
			string id;
			Console.WriteLine("Your ID: ");
			id = Console.ReadLine();
			Console.WriteLine("1. Name");
			Console.WriteLine("2. ID");
			Console.WriteLine("3. ATM");
			Console.WriteLine("Your choose: ");
			opt = int.Parse(Console.ReadLine());
			if (opt == 1)
			{
				string name;
				Console.WriteLine("Who do you want to transfer money: ");
				name = Console.ReadLine();
				double amount;
				Console.WriteLine("Amount: ");
				amount = double.Parse(Console.ReadLine());
				foreach (var user in uUser)
				{
					if (user.ID == id)
					{
						user.AccountBalance -= amount;
						ExportHistory history = new ExportHistory();
						history.transactionType = "Transfer to " + name;
						history.amount = amount;
						history.balance = user.AccountBalance;
						history.dateTransaction = DateTime.Now;
						history.type = 1;
						user.transaction.Add(history);
					}
					if (user.Name == name)
					{
						user.AccountBalance += amount;
						ExportHistory history = new ExportHistory();
						history.transactionType = "Transferred from " + id;
						history.amount = amount;
						history.balance = user.AccountBalance;
						history.dateTransaction = DateTime.Now;
						history.type = 1;
						user.transaction.Add(history);

					}
				}
			}
			else if (opt == 2)
			{
				string name;
				Console.WriteLine("ID that you want to transfer money: ");
				name = Console.ReadLine();
				double amount;
				Console.WriteLine("Amount: ");
				amount = double.Parse(Console.ReadLine());
				foreach (var user in uUser)
				{
					if (user.ID == id)
					{
						user.AccountBalance -= amount;
						ExportHistory history = new ExportHistory();
						history.transactionType = "Transfer to " + name;
						history.amount = amount;
						history.balance = user.AccountBalance;
						history.dateTransaction = DateTime.Now;
						history.type = 2;
						user.transaction.Add(history);
					}
					if (user.ID == name)
					{
						user.AccountBalance += amount;
						ExportHistory history = new ExportHistory();
						history.transactionType = "Transferred from " + id;
						history.amount = amount;
						history.balance = user.AccountBalance;
						history.dateTransaction = DateTime.Now;
						history.type = 2;
						user.transaction.Add(history);

					}
				}
			}

		}
	}
}
