namespace Banking
{
    public class User
    {
        // Fields & properties
        private string sID;
        private string sName;
        private string sPassword;
        private DateOnly daBirthday;
        private double dAccountBalance;
        private List<ExportHistory> ehTransaction;

        public string ID
        {
            get { return this.sID; }
            set { this.sID = value; }
        }

        public string Name
        {
            get { return this.sName; }
            set { this.sName = value; }
        }

        public double AccountBalance
        {
            get { return this.dAccountBalance; }
            set { this.dAccountBalance = value; }
        }
        public DateOnly DaBirthday
        {
            get { return this.daBirthday; }
            set { this.daBirthday = value; }
        }
        public string Password
        {
            get { return this.sPassword; }
            set { this.sPassword = value; }
        }
        public List<ExportHistory> transaction
        {
            get { return this.ehTransaction; }
            set { this.ehTransaction = value; }
        }
        // Constructors
        public User()
        {
        }

        public User(string id) { this.sID = id; }
        public User(string id, string name) : this(id) { this.sName = name; }
        public User(string id, string name, string password) : this(id, name) { this.sPassword = password; }
        public User(string id, string name, string password, DateOnly birthday) : this(id, name, password) { this.daBirthday = birthday; }
        public User(string id, string name, string password, DateOnly birthday, double accountbalance) : this(id, name, password, birthday) { this.dAccountBalance = accountbalance; }
        public User(string id, string name, string password, DateOnly birthday, double accountbalance, List<ExportHistory> transaction) : this(id, name, password, birthday, accountbalance) { this.ehTransaction = transaction; }

        // Destructors
        ~User()
        {

        }

        // Methods
        void DisplayAccountBalance()
        {
            Console.WriteLine($"Account Balance of {this.sName}: {this.dAccountBalance} USD");
        }

        void Deposit()
        {
            Console.WriteLine("The amount you want to deposit in the bank: ");
            double tmp;
            tmp = double.Parse(Console.ReadLine());
            this.AccountBalance += tmp;
            ExportHistory history = new ExportHistory();
            history.transactionType = "Deposit";
            history.amount = tmp;
            history.balance = this.dAccountBalance;
            history.dateTransaction = DateTime.Now;
            history.type = 0;
            this.ehTransaction.Add(history);
        }

        void Withdraw()
        {
            Console.WriteLine("The amount you want to withdraw in the bank: ");
            double tmp;
            tmp = double.Parse(Console.ReadLine());
            if (tmp > this.AccountBalance)
            {
                Console.WriteLine("Your balance is not enough!!!");
            }
            else
            {
                this.AccountBalance -= tmp;
                ExportHistory history = new ExportHistory();
                history.transactionType = "Withdraw";
                history.amount = tmp;
                history.balance = this.dAccountBalance;
                history.dateTransaction = DateTime.Now;
                history.type = 0;
                this.ehTransaction.Add(history);
            }  
        }
        
        void ExportHistory()
        {
            foreach(var history in this.ehTransaction)
            {
                Console.WriteLine($"Transaction Type: {history.transactionType}");
                Console.WriteLine($"Amount to {history.transactionType}: {history.amount} USD");
                Console.WriteLine($"Your Balance: {history.balance}");
                Console.WriteLine($"Transaction Time: {history.dateTransaction}");
            }
        }
    }
}