using System;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace Banking
{
    public class Program
    {
        static void Main(String[] args)
        {
            Bank.GetUsers().Add(new User("0000", "Administrator", "01/01/2003", 123400000, "admin@gmail.com", "Admin", Permission.Administrator));
            Bank.GetUsers().Add(new User("0001", "Phuong Dang", "04/10/2003", 3000000, "phuong@gmail.com", "Phuong", Permission.Default));
            Bank.GetUsers().Add(new User("0002", "Tai Ong", "01/01/2003", 4000000, "tai@gmail.com", "Phuong", Permission.Default));

            Boolean showMenu = true;

            while (showMenu)
            {
                Console.Clear();

                Console.WriteLine("============ The World Bank ============");
                Console.WriteLine("(R) Register account");
                Console.WriteLine("(S) Savings account calculator");


                if (Bank.GetStatus() == Status.LoggedOut)
                {
                    Console.WriteLine("(L) Login");

                }
                if (Bank.GetStatus() == Status.LoggedIn)
                {
                    Console.WriteLine("(L) Logout");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Transfer");
                    Console.WriteLine("4. Open credit card");
                    Console.WriteLine("5. Export transaction history");
                    Console.WriteLine("6. Export user information");

                    if (Bank.GetCurrentUser().GetPermission() == Permission.Administrator)
                    {
                        Console.WriteLine("*Administrator features: ");
                        Console.WriteLine("(A) Export all users' information");
                    }
                }
                Console.WriteLine("(E) Exit application");
                Console.WriteLine("========================================");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "R":
                    case "r":
                        Bank.Register();
                        break;

                    case "S":
                    case "s":
                        Bank.SavingsAccount();
                        break;

                    case "L":
                    case "l":
                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.Logout();
                        else
                            Bank.Login();
                        break;

                    case "1":
                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.GetCurrentUser().Deposit();
                        else
                            goto default;
                        break;

                    case "2":
                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.GetCurrentUser().Withdraw();
                        else
                            goto default;
                        break;

                    case "3":

                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.Transfer();
                        else
                            goto default;
                        break;

                    case "4":
                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.GetCurrentUser().OpenCard();
                        else
                            goto default;
                        break;

                    case "5":
                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.GetCurrentUser().ExportTransactionHistory();
                        else
                            goto default;
                        break;

                    case "6":
                        if (Bank.GetStatus() == Status.LoggedIn)
                            Bank.GetCurrentUser().ExportInformation();
                        else
                            goto default;
                        break;

                    case "A":
                    case "a":
                        if (Bank.GetStatus() == Status.LoggedIn || Bank.GetCurrentUser().GetPermission() == Permission.Administrator)
                        {
                            Int32 index = 0;
                            Bank.GetUsers().ForEach(delegate (User user)
                            {
                                Console.WriteLine($"User #{++index}:");
                                user.ExportInformation();
                            });
                        }
                        else
                            goto default;
                        break;

                    case "E":
                    case "e":
                        showMenu = false;
                        Console.WriteLine("Exiting...");

                        break;

                    default:
                        Console.WriteLine("Invalid input!\nTry again...");
                        break;

                }
                Console.Write("\nPress any key to continue...");
                Console.ReadKey(false);


            }
        }
    }
}