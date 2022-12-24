using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking;

namespace Banking
{
    public abstract class SubBank : IExportable
    {
        protected String ISIN = String.Empty;
        protected String name = String.Empty;
        protected String abbreviation = String.Empty;
        protected String country = String.Empty;
        public String GetISIN()
        {
            return ISIN;
        }
        public String GetName()
        {
            return name;
        }
        public String GetAbbreviation()
        {
            return abbreviation;
        }
        public String GetCountry()
        {
            return country;
        }
        public String GetID()
        {
            return this.ISIN.Substring(3, 4);
        }
        void IExportable.ExportInformation()
        {
            Console.WriteLine("  Name: " + this.name);
            Console.WriteLine("  Abbreviation: " + this.abbreviation);
            Console.WriteLine("  ISIN: " + this.ISIN);
            Console.WriteLine("  Country: " + this.country);

        }
    }
    public class BofA : SubBank
    {
        private BofA()
        {
            ISIN = "US0605051046";
            name = "Bank of America";
            abbreviation = "BofA";
            country = "United States";
        }
        private static SubBank uniqueInstance = new BofA();
        public static BofA GetInstance()
        {
            return (BofA)uniqueInstance;
        }
    }
    public class ICBC : SubBank
    {
        private ICBC()
        {
            ISIN = "CNE1000003G1";
            name = "Industrial and Commercial Bank of China";
            abbreviation = "ICBC";
            country = "China";
        }
        private static SubBank uniqueInstance = new ICBC();
        public static ICBC GetInstance()
        {
            return (ICBC)uniqueInstance;
        }
    }
    public class SMBC : SubBank
    {
        private SMBC()
        {
            ISIN = "JP3890350006";
            name = "Sumitomo Mitsui Banking Corporation";
            abbreviation = "SMBC";
            country = "Japan";
        }
        private static SubBank uniqueInstance = new SMBC();
        public static SMBC GetInstance()
        {
            return (SMBC)uniqueInstance;
        }
    }
    public class BARC : SubBank
    {
        private BARC()
        {
            ISIN = "GB0031348658";
            name = "Barclays";
            abbreviation = "BARC";
            country = "United Kingdom";
        }
        private static SubBank uniqueInstance = new BARC();
        public static BARC GetInstance()
        {
            return (BARC)uniqueInstance;
        }
    }
}
