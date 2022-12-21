using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace Banking
{
    static public partial class Bank
    {
        static public void Logout()
        {
            if (Bank.GetStatus() == Status.Logout)
            {
                Console.WriteLine("You already logged out.\n");
            }
            else
            {
                SetCurrentUser(-1);
                Console.WriteLine("Logout successfully.\n");
            }
        }
    }
}