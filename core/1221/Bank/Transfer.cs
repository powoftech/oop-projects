namespace Banking
{
    static public partial class Bank
    {
        static public void Transfer()
        {
            if (Bank.GetStatus() == Status.LoggedOut)
            {
                Console.WriteLine("You are not logged in.\nPlease log in and try again.");
                Console.WriteLine("\nTransfer cancelled!");
                return;
            }

            Transaction newTransaction = new Transaction();
            Boolean showMenu = true;
            Boolean conflicted = false;
            Int32 beneficiaryIndex = Int32.MinValue;

            while (showMenu)
            {
                Console.Clear();
                Console.WriteLine("Transfer solution:");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. ID");
                Console.WriteLine("3. Card number");
                Console.WriteLine("4. EXIT");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        string beneficiaryName = String.Empty;
                        do
                        {
                            Console.Write("Enter beneficiary's name: ");
                            beneficiaryName = Console.ReadLine()!;
                            conflicted = false;

                            if (!RegexUtilities.IsValidName(beneficiaryName))
                            {
                                Console.WriteLine("This name was not in correct format!\nRetry...");
                                beneficiaryName = String.Empty;
                                conflicted = true;
                            }
                            else if (beneficiaryName == Bank.GetCurrentUser().GetName())
                            {
                                Console.WriteLine("Cannot transfer to yourselves!\nRetry...");
                                beneficiaryName = String.Empty;
                                conflicted = true;
                            }
                        } while (conflicted);

                        foreach (var user in Bank.GetUsers().Select((value, index) => (value, index)))
                        {
                            if (beneficiaryName == user.value.GetName())
                            {
                                beneficiaryIndex = user.index;
                                newTransaction.Beneficiary = beneficiaryName;
                            }
                        }
                        if (beneficiaryIndex == Int32.MinValue)
                        {
                            Console.WriteLine("This name has not been registered!\nTry again...");
                            showMenu = true;
                            Console.ReadKey(false);
                        }
                        else
                        {
                            showMenu = false;
                        }
                        break;

                    case "2":
                        string beneficiaryID = String.Empty;
                        do
                        {
                            Console.Write("Enter beneficiary's ID: ");
                            beneficiaryID = Console.ReadLine()!;
                            conflicted = false;

                            if (beneficiaryID == Bank.GetCurrentUser().GetID())
                            {
                                Console.WriteLine("Cannot transfer to yourselves!\nRetry...");
                                beneficiaryID = String.Empty;
                                conflicted = true;
                                Console.ReadKey(false);
                            }
                        } while (conflicted);

                        foreach (var user in Bank.GetUsers().Select((value, index) => (value, index)))
                        {
                            if (beneficiaryID == user.value.GetID())
                            {
                                beneficiaryIndex = user.index;
                                newTransaction.Beneficiary = beneficiaryID;
                            }
                        }
                        if (beneficiaryIndex == Int32.MinValue)
                        {
                            Console.WriteLine("This ID was not in correct format or has not been registered!\nTry again...");
                            showMenu = true;
                            Console.ReadKey(false);
                        }
                        else
                        {
                            showMenu = false;
                        }
                        break;

                    case "3":
                        string beneficiaryCardNumber = String.Empty;
                        Console.Write("Enter beneficiary's card number: ");
                        beneficiaryCardNumber = Console.ReadLine()!;

                        foreach (var user in Bank.GetUsers().Select((value, index) => (value, index)))
                        {
                            user.value.GetCards().ForEach(delegate (Card card)
                            {
                                if (card.CardNumber == beneficiaryCardNumber)
                                {
                                    beneficiaryIndex = user.index;
                                    newTransaction.Beneficiary = beneficiaryCardNumber;
                                }
                            });
                        }
                        if (beneficiaryIndex == Int32.MinValue)
                        {
                            Console.WriteLine("This card number was not in correct format or has not been registered!\nTry again...");
                            showMenu = true;
                            Console.ReadKey(false);
                        }
                        else
                        {
                            showMenu = false;
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nTransfer cancelled!");
                        showMenu = false;
                        return;

                    default:
                        Console.WriteLine("\nInvalid input!\nTry again...");
                        showMenu = true;
                        Console.ReadKey(false);

                        break;
                }

            }

            Double transferAmount = Double.MinValue;
            do
            {
                Console.Write("Enter the amount: ");
                String amountString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(amountString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    transferAmount = Double.Parse(amountString);
                    if (transferAmount > Bank.GetCurrentUser().GetBalance())
                    {
                        Console.WriteLine("The balance is not sufficient for this process.");
                        Console.WriteLine("Retry...");
                        transferAmount = Double.MinValue;
                    }
                    else
                        newTransaction.Amount = -transferAmount;
                }
            } while (transferAmount == Double.MinValue);

            newTransaction.Date = DateTime.Now;
            newTransaction.Type = "Transfer";
            Bank.GetCurrentUser().AddTransaction(newTransaction);
            Bank.GetUsers()[beneficiaryIndex].AddBalance(transferAmount);
            Console.WriteLine("\nTransfer successfully!");
        }
    }
}