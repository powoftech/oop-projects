using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    static public partial class Bank
    {
        static public void SavingsAccount()
        {
            Console.WriteLine("1. 3 months: 3.0%/year");
            Console.WriteLine("2. 6 months: 5.7%/year");
            Console.WriteLine("3. 12 months: 6.2%/year");
            Double amount = Double.MinValue;
            do
            {
                Console.WriteLine("Enter ")
            } while (amount == Double.MinValue);

        }
        // public void Input()
        // {
        //     User user = new User();
        //     user.Input();
        //     this.uUser = user;

        // }
        // public void EstimatedOutcome()
        // {
        //     Console.WriteLine("How much money do you want to deposit into a savings account: ");
        //     this.dAmount = double.Parse(Console.ReadLine());
        //     Console.WriteLine("How long do you want to choose: ");
        //     
        //     int opt = 0;
        //     opt = int.Parse(Console.ReadLine());
        //     if (opt == 1)
        //     {
        //         this.dAmount += this.dAmount * 3 / 100 * 90 / 365;
        //         Console.WriteLine($"Estimated Outcome: {this.dAmount}");
        //     }
        //     else if (opt == 2)
        //     {
        //         this.dAmount += this.dAmount * 5.7 / 100 * 180 / 365;
        //         Console.WriteLine($"Estimated Outcome: {this.dAmount}");
        //     }
        //     else if (opt == 3)
        //     {
        //         this.dAmount += this.dAmount * 6.2 / 100;
        //         Console.WriteLine($"Estimated Outcome: {this.dAmount}");
        //     }
    }
}
