using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Banking
{
    class RegexUtilities
    {
        public static Boolean IsValidEmail(String email)
        {
            if (String.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // A valid email address pattern from Microsoft Learn (.NET)
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public static Boolean IsValidName(String name)
        {
            if (String.IsNullOrEmpty(name))
                return false;

            return Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$");
        }
        public static Boolean IsValidDouble(String doubleString)
        {
            Double balance = Double.MinValue;
            try
            {
                balance = Double.Parse(doubleString);
            }
            catch (OverflowException)
            {
                Console.WriteLine($"The input is outside the range of the Double type!");
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine($"The input does not represent a number in valid format.");
                return false;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"The input is null or empty.");
                return false;
            }
            if (balance < 0)
            {
                Console.WriteLine($"The input cannot be negative.");
                return false;
            }
            return true;
        }
    }
}