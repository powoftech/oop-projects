package classes;

import java.lang.Math;
import java.time.*;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.concurrent.ThreadLocalRandom;

import interfaces.Exportable;
import classes.subbank.*;

public class Card implements Exportable {
    private String cardNumber = "";
    private LocalDateTime creationDate = LocalDateTime.MIN;
    private LocalDateTime expirationDate = LocalDateTime.MIN;
    private SubBank subBank = NullObject.getInstance();

    public String getCardNumber() {
        return this.cardNumber;
    }

    public void setCardNumber(String cardNumber) {
        this.cardNumber = cardNumber;
    }

    public LocalDateTime getCreationDate() {
        return this.creationDate;
    }

    public void setCreationDate(LocalDateTime creationDate) {
        this.creationDate = creationDate;
    }

    public LocalDateTime getExpirationDate() {
        return this.expirationDate;
    }

    public void setExpirationDate(LocalDateTime expirationDate) {
        this.expirationDate = expirationDate;
    }

    public SubBank getSubBank() {
        return this.subBank;
    }

    public void setSubBank(SubBank subBank) {
        this.subBank = subBank;
    }

    public Card() {

    }

    public Card(LocalDateTime creationDate) {
        this.creationDate = creationDate;
        this.expirationDate = creationDate.plus(5, ChronoUnit.YEARS);
    }

    public Card(LocalDateTime creationDate, SubBank subBank) {
        this(creationDate);
        this.subBank = subBank;
    }

    private int randomNumberGenerator(int length) {
        int begin = (int) Math.pow(10, length - 1);
        int end = (int) Math.pow(10, length);
        return ThreadLocalRandom.current().nextInt(begin, end);
    }

    public void create(String userID) {
        if (this.subBank.compareTo(NullObject.getInstance()) != 0) {
            this.cardNumber = "4" + userID.substring(1, 4) + randomNumberGenerator(8)
                    + subBank.getID();
            this.creationDate = LocalDateTime.now();
            this.expirationDate = this.creationDate.plus(5, ChronoUnit.YEARS);
        }
    }

    public void exportInformation() {
        DateTimeFormatter uniqueFormatter = DateTimeFormatter.ofPattern("MM/yyyy");

        System.out.println("    Sub bank: " + this.subBank.getName());
        System.out.println("    Card number: " + this.cardNumber);
        System.out.println("    Creation date: " + uniqueFormatter.format(creationDate));
        System.out.println("    Expiration date: " + uniqueFormatter.format(expirationDate));
    }
}
