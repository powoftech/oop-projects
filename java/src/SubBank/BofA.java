package SubBank;

public class BofA extends SubBank {
    private BofA() {
        name = "Bank of America";
        abbreviation = "BofA";
        ISIN = "US0605051046";
        country = "United States";
        id = ISIN.substring(3, 4);
    }

    private static BofA uniqueInstance = new BofA();

    public static BofA getInstance() {
        return uniqueInstance;
    }
}
