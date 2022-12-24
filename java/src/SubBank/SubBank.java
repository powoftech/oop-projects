package SubBank;

import Interfaces.Exportable;

public abstract class SubBank implements Exportable, Comparable<SubBank> {
    protected String name = "";
    protected String abbreviation = "";
    protected String ISIN = "";
    protected String country = "";
    protected String id = "";

    public String getName() {
        return name;
    }

    public String getISIN() {
        return ISIN;
    }

    public String getAbbreviation() {
        return abbreviation;
    }

    public String getCountry() {
        return country;
    }

    public String getID() {
        return id;
    }

    public void exportInformation() {
        System.out.println("  Name: " + this.name);
        System.out.println("  Abbreviation: " + this.abbreviation);
        System.out.println("  ISIN: " + this.ISIN);
        System.out.println("  Country: " + this.country);
    }

    @Override
    public int compareTo(SubBank other) {
        if ((getISIN().compareTo(other.getISIN())) == 0) {
            return 0;
        }
        return 1;
    }
}
