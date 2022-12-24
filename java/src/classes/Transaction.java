package classes;
import java.time.LocalDateTime;

import classes.utility.DateFormatter;
import interfaces.Exportable;

public class Transaction implements Exportable {
    private LocalDateTime date = LocalDateTime.MIN;
    private double amount = Double.MIN_VALUE;
    private String beneficiary = "";
    private String type = "";

    public LocalDateTime getDate() {
        return this.date;
    }

    public void setDate(LocalDateTime date) {
        this.date = date;
    }

    public double getAmount() {
        return this.amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    public String getBeneficiary() {
        return this.beneficiary;
    }

    public void setBeneficiary(String beneficiary) {
        this.beneficiary = beneficiary;
    }

    public String getType() {
        return this.type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Transaction() {

    }

    public Transaction(double amount, String beneficiary, String type) {
        this.date = LocalDateTime.now();
        this.amount = amount;
        this.beneficiary = beneficiary;
        this.type = type;
    }

    public void exportInformation() {
        System.out.println("  Date: " + DateFormatter.getFormatter().format(date));
        System.out.println("  Amount: " + this.amount);
        System.out.println("  Beneficiary: " + this.beneficiary);
        System.out.println("  Type: " + this.type);
    }

}
