package SubBank;

public class SMBC extends SubBank {
    private SMBC() {
        name = "Sumitomo Mitsui Banking Corporation";
        abbreviation = "SMBC";
        ISIN = "JP3890350006";
        country = "Japan";
        id = ISIN.substring(3, 4);
    }

    private static SMBC uniqueInstance = new SMBC();

    public static SMBC getInstance() {
        return uniqueInstance;
    }
}
