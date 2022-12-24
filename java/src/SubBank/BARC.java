package SubBank;

public class BARC extends SubBank {
    private BARC() {
        name = "Barclays";
        abbreviation = "BARC";
        ISIN = "GB0031348658";
        country = "United Kingdom";
        id = ISIN.substring(3, 4);
    }

    private static BARC uniqueInstance = new BARC();

    public static BARC getInstance() {
        return uniqueInstance;
    }
}
