using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

enum Status
{
    LoggedOut,
    LoggedIn
}

namespace Banking
{
    static public partial class Bank
    {
        static private String name = "The World Bank";
        static private List<User> users = new List<User>();
        static private Int32 currentUser = -1; // Index in users list

        static public String GetName()
        {
            return name;
        }
        static public List<User> GetUsers()
        {
            return users;
        }
        static internal Status GetStatus()
        {
            if (currentUser == -1)
                return Status.LoggedOut;
            return Status.LoggedIn;
        }
        static internal void SetCurrentUser(Int32 index)
        {
            currentUser = index;
        }
        static internal User GetCurrentUser()
        {
            return GetUsers()[currentUser];
        }
    }
}
