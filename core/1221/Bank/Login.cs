using System;
using System.Globalization;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Banking
{
    static public partial class Bank
    {
        static public void Login()
        {
            Console.Clear();
            if (Bank.GetStatus() == Status.LoggedIn)
            {
                Console.WriteLine("There is a user is logged in!");

                ConsoleKey response;
                do
                {
                    System.Console.Write("Are you sure you want to log out? [y/n] ");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();
                } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                if (response == ConsoleKey.Y)
                {
                    Bank.Logout();
                }
                else if (response == ConsoleKey.N)
                {
                    Console.WriteLine("Login cancelled!");
                    return;
                }
            }

            User user = new User();
            Boolean continuing;

            do
            {
                continuing = false;
                StringBuilder passwordBuilder = new StringBuilder();
                Boolean reading = true;

                System.Console.Write("Enter email: ");
                user.SetEmail(Console.ReadLine()!);
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
                user.SetPassword(passwordBuilder.ToString());

                if (Bank.GetUsers().Contains(user))
                {
                    Bank.currentUser = Bank.GetUsers().IndexOf(user);
                    Console.WriteLine("Login successfully!");
                }
                else
                {
                    Console.WriteLine("The email address or password is incorrect!");
                    user.SetEmail(String.Empty);
                    user.SetPassword(String.Empty);

                    ConsoleKey response;
                    do
                    {
                        System.Console.Write("Do you want to continue? [y/n] ");
                        response = Console.ReadKey(false).Key;
                        if (response != ConsoleKey.Enter)
                            Console.WriteLine();
                    } while (response != ConsoleKey.Y && response != ConsoleKey.N);
                    if (response == ConsoleKey.N)
                        Console.WriteLine("Login cancelled!");
                    else
                        continuing = true;
                }
            } while (continuing);

        }
    }
}