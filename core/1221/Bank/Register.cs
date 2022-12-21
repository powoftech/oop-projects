using System;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Banking
{
    static public partial class Bank
    {
        static public void Register()
        {
            Console.Clear();
            User newUser = new User();

            // Email address
            do
            {
                Console.Write("Enter email: ");
                newUser.SetEmail(Console.ReadLine()!);

                if (!RegexUtilities.IsValidEmail(newUser.GetEmail()!))
                {
                    Console.WriteLine("This email address was not in correct format!\nRetry...");
                    newUser.SetEmail(String.Empty);
                }
                else Bank.GetUsers().ForEach(delegate (User user)
                {
                    if (user.GetEmail() == newUser.GetEmail())
                    {
                        Console.WriteLine("This email address is currently being used!\nRetry...");
                        newUser.SetEmail(String.Empty);
                    }
                });
            } while (newUser.GetEmail() == String.Empty);

            // Name
            do
            {
                Console.Write("Enter the name: ");
                newUser.SetName(Console.ReadLine()!);
                if (!RegexUtilities.IsValidName(newUser.GetName()!))
                {
                    Console.WriteLine("This name was not in correct format!\nRetry...");
                    newUser.SetName(String.Empty);
                }
                else Bank.GetUsers().ForEach(delegate (User user)
                {
                    if (user.GetName() == newUser.GetName())
                    {
                        Console.WriteLine("This name is currently being used!\nRetry...");
                        newUser.SetName(String.Empty);
                    }
                });
            } while (newUser.GetName() == String.Empty);

            // Date of birth
            String dateString = String.Empty;
            DateOnly dateResult = DateOnly.MinValue;
            var formats = new[] { "MM/dd/yyyy" };
            do
            {
                Console.Write("Enter date of birth (MM/dd/yyyy): ");
                dateString = Console.ReadLine()!;
                if (!DateOnly.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateResult))
                {
                    Console.WriteLine("This date of birth was not in correct format! \nRetry...");
                    dateResult = DateOnly.MinValue;
                }
            } while (dateResult == DateOnly.MinValue);
            newUser.SetDateOfBirth(dateResult);

            // Password
            StringBuilder passwordBuilder = new StringBuilder();
            Boolean reading = true;
            Console.Write("Enter password: ");
            while (reading)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                char passwordChar = consoleKeyInfo.KeyChar;

                if (passwordChar == '\r')
                    reading = false;
                else
                    passwordBuilder.Append(passwordChar.ToString());
            }
            Console.WriteLine(passwordBuilder.ToString());
            newUser.SetPassword(passwordBuilder.ToString());

            // Balance
            do
            {
                Console.Write("Enter the balance: ");
                String balanceString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(balanceString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    newUser.SetBalance(Double.Parse(balanceString));
                }
            } while (newUser.GetBalance() == Double.MinValue);

            // Permission
            ConsoleKey response;
            do
            {
                Console.Write("Are you the administrator? [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            if (response == ConsoleKey.Y)
            {
                newUser.SetAdministrator();
            }

            // ID
            newUser.SetID((Bank.GetUsers().Count + 1).ToString().PadLeft(4, '0'));

            // Registration date
            newUser.SetRegistrationDate(DateTime.Now);

            GetUsers().Add(newUser);

            Console.WriteLine("Registered successfully!");
        }
    }


}