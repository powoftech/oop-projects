namespace Banking
{
    public partial class User : IEquatable<User>
    {
        internal void OpenCard()
        {
            Card newCard = new Card();

            bool showMenu = true;

            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose an sub bank:");
                Console.WriteLine("1.  ", BofA.GetInstance().GetName());
                Console.WriteLine("  a. Get information");
                Console.WriteLine("2. ", ICBC.GetInstance().GetName());
                Console.WriteLine("  b. Get information");
                Console.WriteLine("3. ", SMBC.GetInstance().GetName());
                Console.WriteLine("  c. Get information");
                Console.WriteLine("4. ", BARC.GetInstance().GetName());
                Console.WriteLine("  d. Get information");
                Console.WriteLine("5. EXIT");
                Console.Write("\n\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        newCard.SubBank = BofA.GetInstance();
                        showMenu = false;
                        break;

                    case "2":
                        newCard.SubBank = ICBC.GetInstance();
                        showMenu = false;
                        break;

                    case "3":
                        newCard.SubBank = SMBC.GetInstance();
                        showMenu = false;
                        break;

                    case "4":
                        newCard.SubBank = BARC.GetInstance();
                        showMenu = false;
                        break;
                        
                    case "a":
                    case "A":
                        BofA.GetInstance().ExportInformation();
                        showMenu = true;
                        break;

                    case "b":
                    case "B":
                        ICBC.GetInstance().ExportInformation();
                        showMenu = true;
                        break;

                    case "c":
                    case "C":
                        SMBC.GetInstance().ExportInformation();
                        showMenu = true;
                        break;

                    case "d":
                    case "D":
                        BARC.GetInstance().ExportInformation();
                        showMenu = true;
                        break;

                    case "5":
                        Console.WriteLine("Process cancelled!");
                        showMenu = false;
                        return;
                        
                    default:
                        showMenu = true;
                        break;
                }
            }
            newCard.Implement(this.id);
            newCard.ExportInformation();
            if (newCard.CardNumber != String.Empty)
            {
                this.cards.Add(newCard);
                Console.WriteLine("Applied successfully!");
            }


        }
    }
}