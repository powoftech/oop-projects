package classes.subbank;

public class ICBC extends SubBank {
    private ICBC() {
        name = "Industrial and Commercial Bank of China";
        abbreviation = "ICBC";
        ISIN = "CNE1000003G1";
        country = "China";
        id = ISIN.substring(3, 7);
    }

    private static ICBC uniqueInstance = new ICBC();

    public static ICBC getInstance() {
        return uniqueInstance;
    }
}
