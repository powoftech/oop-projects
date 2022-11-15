namespace Banking
{
    public class Account
    {
        private string username;
        private string password;
        private static volatile Account account;
        private static readonly object lockObject = new object();

        private Account()
        {
            account = new Account();
        }
        private Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public static Account GetAccount()
        {
            if (account == null)
            {
                lock (lockObject)
                {
                    if (account == null)
                    {
                        account = new Account();
                    }
                }
            }
            return account;
        }
    }

}