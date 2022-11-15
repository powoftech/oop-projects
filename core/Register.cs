namespace Banking
{
    public class Register       
    {
        private string username;
        private string password;
        private string email;
        private bool enabled;

        private Register()
        {
        }
        private Register(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


    }
}