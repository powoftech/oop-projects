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
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                String DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    String domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
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

            try
            {
                return Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
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