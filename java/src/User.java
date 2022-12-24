import java.util.*;
import java.time.*;
import java.lang.*;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import Interfaces.Exportable;
import SubBank.*;

enum Permission {
    Default,
    Administrator
}

public class User implements Comparable<User>, Exportable {
    private String id = "";
    private String name = "";
    private LocalDate dateOfBirth = LocalDate.MIN;
    private double balance = Double.MIN_VALUE;
    private String email = "";
    private String password = "";
    private Permission permission = Permission.Default;
    private List<Transaction> transactionHistory = new ArrayList<Transaction>();
    private List<Card> cards = new ArrayList<Card>();
    private LocalDateTime registrationDate = LocalDateTime.MIN;

    public String getID() {
        return this.id;
    }

    public void setID(String id) {
        this.id = id;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public LocalDate getDateOfBirth() {
        return this.dateOfBirth;
    }

    public void setDateOfBirth(LocalDate dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }

    public double getBalance() {
        return this.balance;
    }

    public void addBalance(double balance) {
        this.balance += balance;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }

    public String getEmail() {
        return this.email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return this.password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Permission getPermission() {
        return this.permission;
    }

    public void setAdministrator() {
        this.permission = Permission.Administrator;
    }

    public List<Transaction> getTransactionHistory() {
        return this.transactionHistory;
    }

    public void addTransaction(Transaction transaction) {
        this.transactionHistory.add(transaction);
    }

    public List<Card> getCards() {
        return this.cards;
    }

    public LocalDateTime getRegistrationDate() {
        return this.registrationDate;
    }

    public void setRegistrationDate(LocalDateTime registrationDate) {
        this.registrationDate = registrationDate;
    }

    public User() {
    }

    public User(String id, String name, LocalDate dateOfBirth, double balance, String email, String password,
            Permission permission) {
        this.id = id;
        this.name = name;
        this.dateOfBirth = dateOfBirth;
        this.balance = balance;
        this.email = email;
        this.password = password;
        if (permission == Permission.Administrator)
            this.setAdministrator();
        this.registrationDate = LocalDateTime.now();
    }

    public void Deposit() {
        ClearConsole.execute();
        String doubleString = "";
        double depositAmount = Double.MIN_VALUE;
        do {
            System.out.println("Enter the deposit amount: ");
            doubleString = System.console().readLine();
            if (!RegexUtilities.isValidDouble(doubleString)) {
                System.out.println("Retry...");
            } else {
                depositAmount = Double.parseDouble(doubleString);
            }
        } while (depositAmount == Double.MIN_VALUE);

        this.balance += depositAmount;
        Transaction newTransaction = new Transaction(depositAmount, "Yourself", "Deposit");
        this.transactionHistory.add(newTransaction);
        System.out.println("Deposit successfully!");
    }

    public void Withdraw() {
        ClearConsole.execute();
        String doubleString = "";
        double withdrawAmount = Double.MIN_VALUE;
        do {
            System.out.println("Enter the withdraw amount: ");
            doubleString = System.console().readLine();
            if (!RegexUtilities.isValidDouble(doubleString)) {
                System.out.println("Retry...");
            } else {
                withdrawAmount = Double.parseDouble(doubleString);
                if (withdrawAmount > this.balance) {
                    withdrawAmount = Double.MIN_VALUE;

                    System.out.println("The balance is not sufficient for this process...");
                    System.out.println("Retry...");
                }
            }
        } while (withdrawAmount == Double.MIN_VALUE);

        this.balance -= withdrawAmount;
        Transaction newTransaction = new Transaction(-withdrawAmount, "Yourself", "Withdraw");
        this.transactionHistory.add(newTransaction);
        System.out.println("Withdraw successfully!");
    }

    public void exportTransactionHistory() {
        ClearConsole.execute();
        int index = 0;
        for (Transaction transaction : transactionHistory) {
            System.out.println("Transaction #" + (++index) + ": ");
            transaction.exportInformation();
        }
    }

    public void exportInformation() {
        System.out.println("  ID: " + this.id);
        System.out.println("  Name: " + this.name);
        System.out.println("  Email address: " + this.email);
        System.out.println("  Date of birth: " + DateFormatter.getFormatter().format(this.dateOfBirth));
        System.out.println("  Account balance: " + this.balance);
        System.out.println("  Registration date: " + DateFormatter.getFormatter().format(this.registrationDate));
        if (this.cards.size() == 0) {
            System.out.println("  *This user doesn't have any cards yet!");
        } else {
            int index = 0;

            System.out.println("  Export cards' information... ");
            for (Card card : cards) {
                System.out.println("   Card #" + (++index) + ": ");
                card.exportInformation();
            }
        }
    }

    @Override
    public int compareTo(User other) {
        if (this.getEmail().compareTo(other.getEmail()) == 0
                && this.getPassword().compareTo(other.getPassword()) == 0) {
            return 0;
        }
        return 1;
    }

    public void openCard() {
        Card newCard = new Card();

        boolean showMenu = true;

        while (showMenu) {
            ClearConsole.execute();
            System.out.println("Choose a sub bank:");
            System.out.println("1.  " + BofA.getInstance().getName());
            System.out.println("  a. Get bank information");
            System.out.println("2. " + ICBC.getInstance().getName());
            System.out.println("  b. Get bank information");
            System.out.println("3. " + SMBC.getInstance().getName());
            System.out.println("  c. Get bank information");
            System.out.println("4. " + BARC.getInstance().getName());
            System.out.println("  d. Get bank information");
            System.out.println("5. EXIT");
            System.out.print("\n\nSelect an option: ");

            switch (System.console().readLine()) {
                case "1":
                    showMenu = false;
                    newCard.setSubBank(BofA.getInstance());
                    break;

                case "2":
                    showMenu = false;
                    newCard.setSubBank(ICBC.getInstance());
                    break;

                case "3":
                    showMenu = false;
                    newCard.setSubBank(SMBC.getInstance());
                    break;

                case "4":
                    showMenu = false;
                    newCard.setSubBank(BARC.getInstance());
                    break;

                case "a":
                case "A":
                    showMenu = true;
                    BofA.getInstance().exportInformation();
                    System.console().readLine();
                    break;

                case "b":
                case "B":
                    showMenu = true;
                    ICBC.getInstance().exportInformation();
                    System.console().readLine();
                    break;

                case "c":
                case "C":
                    showMenu = true;
                    SMBC.getInstance().exportInformation();
                    System.console().readLine();
                    break;

                case "d":
                case "D":
                    showMenu = true;
                    BARC.getInstance().exportInformation();
                    System.console().readLine();
                    break;

                case "5":
                    showMenu = false;
                    System.out.println("Process cancelled!");
                    return;

                default:
                    showMenu = true;
                    break;
            }
        }
        newCard.create(this.id);
        newCard.exportInformation();

        if (!newCard.getCardNumber().isEmpty() && !newCard.getCardNumber().isBlank() && newCard != null) {
            this.cards.add(newCard);
            System.out.println("Created successfully!");
        }

    }
}