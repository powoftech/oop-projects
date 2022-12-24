package classes.subbank;

public class NullObject extends SubBank {
    private NullObject() {

    }

    private static NullObject uniqueInstance = new NullObject();

    public static NullObject getInstance() {
        return uniqueInstance;
    }
}
