namespace Banking
{
    public class User
    {

        private string username;
        private string password;
        private bool enabled;

        private User()
        {
        }
        private User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


    }
}