using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    static public partial class Bank
    {
        static public void SavingsAccount()
        {
            Console.Clear();
            Double depositAmount = Double.MinValue;
            Double term = Double.MinValue;
            Double interestRates = Double.MinValue;
            Double estimatedInterest = Double.MinValue;
            String doubleString = String.Empty;

            do
            {
                Console.Write("Enter the deposit amount: ");
                doubleString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(doubleString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    depositAmount = Double.Parse(doubleString);
                }
            } while (depositAmount == Double.MinValue);
            do
            {
                Console.Write("Enter the term deposit (months): ");
                doubleString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(doubleString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    term = Double.Parse(doubleString);
                }
            } while (term == Double.MinValue);
            do
            {
                Console.Write("Enter the interest rates (%/year): ");
                doubleString = Console.ReadLine()!;
                if (!RegexUtilities.IsValidDouble(doubleString))
                {
                    Console.WriteLine("Retry...");
                }
                else
                {
                    interestRates = Double.Parse(doubleString);
                }
            } while (interestRates == Double.MinValue);

            estimatedInterest = depositAmount * interestRates / 100 * term / 12;

            Console.WriteLine("Estimated interest: " + estimatedInterest.ToString("N", CultureInfo.InvariantCulture));
        }
    }
}
