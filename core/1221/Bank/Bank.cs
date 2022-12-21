using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

enum Status
{
    Logout,
    Login
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
                return Status.Logout;
            return Status.Login;
        }
        static internal void SetCurrentUser(Int32 index)
        {
            currentUser = index;
        }
    }
}
