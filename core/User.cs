namespace Banking
{
    public class User
    {
        // Fields & properties
        private string username;
        private string password;

        // Constructors
        public User()
        {
            username = string.Empty;
            password = string.Empty;
        }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        // Destructors
        ~User()
        {
        }

        // Methods

    }
}