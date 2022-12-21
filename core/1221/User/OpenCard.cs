namespace Banking
{
    public partial class User : IEquatable<User>
    {
        internal void OpenCard()
        {
            Card newCard = new Card();

            Boolean showMenu = true;

            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose a sub bank:");
                Console.WriteLine("1.  " + BofA.GetInstance().GetName());
                Console.WriteLine("  a. Get bank information");
                Console.WriteLine("2. " + ICBC.GetInstance().GetName());
                Console.WriteLine("  b. Get bank information");
                Console.WriteLine("3. " + SMBC.GetInstance().GetName());
                Console.WriteLine("  c. Get bank information");
                Console.WriteLine("4. " + BARC.GetInstance().GetName());
                Console.WriteLine("  d. Get bank information");
                Console.WriteLine("5. EXIT");
                Console.Write("\n\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        newCard.SubBank = (BofA)BofA.GetInstance();
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
                        (BofA.GetInstance() as IExportable).ExportInformation();
                        showMenu = true;
                        Console.ReadKey();
                        break;

                    case "b":
                    case "B":
                        (ICBC.GetInstance() as IExportable).ExportInformation();
                        showMenu = true;
                        Console.ReadKey();
                        break;

                    case "c":
                    case "C":
                        (SMBC.GetInstance() as IExportable).ExportInformation();
                        showMenu = true;
                        Console.ReadKey();
                        break;

                    case "d":
                    case "D":
                        (BARC.GetInstance() as IExportable).ExportInformation();
                        showMenu = true;
                        Console.ReadKey();
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
            (newCard as IExportable).ExportInformation();
            if (newCard.CardNumber != String.Empty)
            {
                this.cards.Add(newCard);
                Console.WriteLine("Applied successfully!");
            }


        }
    }
}