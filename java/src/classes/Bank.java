package classes;

import java.util.*;

import classes.utility.ClearConsole;
import classes.utility.DateFormatter;
import classes.utility.RegexUtilities;

import java.time.*;
import java.io.Console;
import java.text.DecimalFormat;
import java.time.format.DateTimeParseException;

public final class Bank {
    public enum Status {
        LoggedIn,
        LoggedOut
    }

    private static String name = "The World Bank";
    private static List<User> users = new ArrayList<User>();
    private static int currentUser = -1; // Index in users list
    private static final String emptyString = "";

    public static String getName() {
        return name;
    }

    public static List<User> getUsers() {
        return users;
    }

    public static Status getStatus() {
        if (currentUser == -1)
            return Status.LoggedOut;
        return Status.LoggedIn;
    }

    public static void setCurrentUser(int index) {
        currentUser = index;
    }

    public static User getCurrentUser() {
        return users.get(currentUser);
    }

    public static void register() {
        ClearConsole.execute();
        User newUser = new User();
        Console console = System.console();

        do {
            newUser.setEmail(System.console().readLine("Enter email: "));

            if (!RegexUtilities.isValidEmail(newUser.getEmail())) {
                System.out.println("This email address was not in correct format!\nRetry...");
                newUser.setEmail(emptyString);
            } else
                for (User user : users) {
                    if (user.getEmail().equalsIgnoreCase(newUser.getEmail())) {
                        System.out.println("This email address is currently being used!\nRetry...");
                        newUser.setEmail(emptyString);
                    }
                }
        } while (newUser.getEmail().equals(emptyString));

        // Name
        do {
            newUser.setName(System.console().readLine("Enter the name: "));
            if (!RegexUtilities.isValidName(newUser.getName())) {
                System.out.println("This name was not in correct format!\nRetry...");
                newUser.setName(emptyString);
            } else
                for (User user : users) {
                    if (user.getName().equals(newUser.getName())) {
                        System.out.println("This name is currently being used!\nRetry...");
                        newUser.setName(emptyString);
                    }
                }
        } while (newUser.getName().equals(emptyString));

        // Date of birth
        String dateString = emptyString;
        LocalDate dateResult = LocalDate.MIN;
        do {
            dateString = System.console().readLine("Enter date of birth (MM/dd/yyyy): ");
            try {
                dateResult = LocalDate.parse(dateString, DateFormatter.getFormatter());

            } catch (DateTimeParseException e) {
                System.out.println("This date of birth was not in correct format! \nRetry...");
                dateResult = LocalDate.MIN;
            }
        } while (dateResult.equals(LocalDate.MIN));
        newUser.setDateOfBirth(dateResult);

        // Password
        char[] passwordChar = null;
        String passwordString = emptyString;
        passwordChar = console.readPassword("Enter password: ");
        passwordString = String.valueOf(passwordChar);
        System.out.println("\"" + passwordString + "\"");
        newUser.setPassword(passwordString);

        // Balance
        do {
            String balanceString = System.console().readLine("Enter the balance: ");
            if (!RegexUtilities.isValidDouble(balanceString)) {
                System.out.println("Retry...");
            } else {
                newUser.setBalance(Double.parseDouble(balanceString));
            }
        } while (newUser.getBalance() == Double.MIN_VALUE);

        // Permission
        String permissionString = emptyString;
        do {
            permissionString = System.console().readLine("Are you the administrator? [y/n] ");
        } while (!permissionString.equalsIgnoreCase("y")
                && !permissionString.equalsIgnoreCase("n"));
        if (permissionString.equalsIgnoreCase("y")) {
            newUser.setAdministrator();
        }

        // ID
        newUser.setID(String.format("%04d", (users.size() + 1)));

        // Registration date
        newUser.setRegistrationDate(LocalDateTime.now());

        users.add(newUser);

        System.out.println("Registered successfully!");
    }

    public static void login() {
        ClearConsole.execute();
        if (getStatus() == Status.LoggedIn) {
            System.out.println("There is a user is logged in!");

            String response = emptyString;
            do {
                response = System.console().readLine("Are you sure you want to log out? [y/n] ");
            } while (!response.equalsIgnoreCase("y")
                    && !response.equalsIgnoreCase("n"));
            if (response.equalsIgnoreCase("y")) {
                logout();
            } else {
                System.out.println("\nLogin cancelled!");
                return;
            }
        }

        User user = new User();
        Console console = System.console();
        boolean retry;

        do {
            retry = false;
            char[] passwordChar = null;
            String passwordString = emptyString;

            user.setEmail(System.console().readLine("Enter email: "));
            passwordChar = console.readPassword("Enter password: ");
            passwordString = String.valueOf(passwordChar);
            System.out.println("\"" + passwordString + "\"");
            user.setPassword(passwordString);

            if (users.contains(user)) {
                currentUser = users.indexOf(user);
                System.out.println("\nLogin successfully!");
            } else {
                System.out.println("The email address or password is incorrect!");
                user.setEmail(emptyString);
                user.setPassword(emptyString);

                String response = emptyString;
                do {
                    response = System.console().readLine("Do you want to continue? [y/n] ");
                } while (!response.equalsIgnoreCase("y")
                        && !response.equalsIgnoreCase("n"));
                if (response.equalsIgnoreCase("y")) {
                    retry = true;
                    System.out.println();
                } else {
                    System.out.println("\nLogin cancelled!");
                    return;
                }
            }
        } while (retry);
    }

    public static void logout() {
        if (getStatus() == Status.LoggedOut) {
            System.out.println("You already logged out.\n");
        } else {
            setCurrentUser(-1);
            System.out.println("Logout successfully.\n");
        }
    }

    public static void savingsAccount() {
        ClearConsole.execute();

        double depositAmount = Double.MIN_VALUE;
        double term = Double.MIN_VALUE;
        double interestRates = Double.MIN_VALUE;
        double estimatedInterest = Double.MIN_VALUE;
        String doubleString = emptyString;
        DecimalFormat decimalFormat = new DecimalFormat("#,###.##");

        do {
            doubleString = System.console().readLine("Enter the deposit amount: ");
            if (!RegexUtilities.isValidDouble(doubleString)) {
                System.out.println("Retry...");
            } else {
                depositAmount = Double.parseDouble(doubleString);
            }
        } while (depositAmount == Double.MIN_VALUE);

        do {
            doubleString = System.console().readLine("Enter the term deposit (months): ");
            if (!RegexUtilities.isValidDouble(doubleString)) {
                System.out.println("Retry...");
            } else {
                term = Double.parseDouble(doubleString);
            }
        } while (term == Double.MIN_VALUE);

        do {
            doubleString = System.console().readLine("Enter the interest rates (%%/year): ");
            if (!RegexUtilities.isValidDouble(doubleString)) {
                System.out.println("Retry...");
            } else {
                interestRates = Double.parseDouble(doubleString);
            }
        } while (interestRates == Double.MIN_VALUE);

        estimatedInterest = depositAmount * interestRates / 100 * term / 12;

        System.out.println("Estimated interest: " + decimalFormat.format(estimatedInterest));
    }

    public static void transfer() {
        ClearConsole.execute();
        if (getStatus() == Status.LoggedOut) {
            System.out.println("You are not logged in.\nPlease log in and try again.");
            System.out.println("\nTransfer cancelled!");
            return;
        }

        Transaction newTransaction = new Transaction();
        int beneficiaryIndex = Integer.MIN_VALUE;
        Boolean showMenu = true;
        Boolean retry = false;

        while (showMenu) {
            int index = 0;

            ClearConsole.execute();

            System.out.println("Transfer solution:");
            System.out.println("1. Name");
            System.out.println("2. ID");
            System.out.println("3. Card number");
            System.out.println("4. EXIT");

            switch (System.console().readLine("Select an option: ")) {
                case "1":
                    String beneficiaryName = emptyString;
                    do {
                        retry = false;
                        beneficiaryName = System.console().readLine("Enter beneficiary's name: ");

                        if (!RegexUtilities.isValidName(beneficiaryName)) {
                            System.out.println("This name was not in correct format!\nRetry...");
                            beneficiaryName = emptyString;
                            retry = true;
                        } else if (beneficiaryName.equals(getCurrentUser().getName())) {
                            retry = true;
                            beneficiaryName = emptyString;
                            System.out.println("Cannot transfer to yourselves!\nRetry...");
                        }
                    } while (retry);

                    for (User user : users) {
                        if (beneficiaryName.equals(user.getName())) {
                            beneficiaryIndex = index;
                            newTransaction.setBeneficiary(beneficiaryName);
                            break;
                        }
                        index++;
                    }
                    if (beneficiaryIndex == Integer.MIN_VALUE) {
                        showMenu = true;
                        System.out.println("This name has not been registered!\nTry again...");
                        System.console().readPassword();
                    } else {
                        showMenu = false;
                    }
                    break;

                case "2":
                    String beneficiaryID = emptyString;
                    do {
                        retry = false;
                        beneficiaryID = System.console().readLine("Enter beneficiary's ID: ");

                        if (beneficiaryID.equals(getCurrentUser().getID())) {
                            retry = true;
                            beneficiaryID = emptyString;
                            System.out.println("Cannot transfer to yourselves!\nRetry...");
                        }
                    } while (retry);

                    for (User user : users) {
                        if (beneficiaryID.equals(user.getID())) {
                            beneficiaryIndex = index;
                            newTransaction.setBeneficiary(beneficiaryID);
                            break;
                        }
                        index++;
                    }
                    if (beneficiaryIndex == Integer.MIN_VALUE) {
                        showMenu = true;
                        System.out.println(
                                "This ID was not in correct format or has not been registered!\nTry again...");
                        System.console().readPassword();
                    } else {
                        showMenu = false;
                    }
                    break;

                case "3":
                    String beneficiaryCardNumber = emptyString;
                    beneficiaryCardNumber = System.console().readLine("Enter beneficiary's card number: ");

                    for (User user : users) {
                        for (Card card : user.getCards()) {
                            if (card.getCardNumber().equals(beneficiaryCardNumber)) {
                                beneficiaryIndex = index;
                                newTransaction.setBeneficiary(beneficiaryCardNumber);
                                break;
                            }
                        }
                        index++;
                    }

                    if (beneficiaryIndex == Integer.MIN_VALUE) {
                        showMenu = true;
                        System.out.println(
                                "This card number was not in correct format or has not been registered!\nTry again...");
                        System.console().readPassword();
                    } else {
                        showMenu = false;
                    }
                    break;

                case "4":
                    showMenu = false;
                    System.out.println("\nTransfer cancelled!");
                    return;

                default:
                    showMenu = true;
                    System.out.println("\nInvalid input!\nTry again...");
                    System.console().readPassword();
                    break;
            }

        }

        Double transferAmount = Double.MIN_VALUE;
        do {
            String amountString = System.console().readLine("Enter the amount: ");
            if (!RegexUtilities.isValidDouble(amountString)) {
                System.out.println("Retry...");
            } else {
                transferAmount = Double.parseDouble(amountString);
                if (transferAmount > getCurrentUser().getBalance()) {
                    System.out.println("The balance is not sufficient for this process.\nRetry...");
                    transferAmount = Double.MIN_VALUE;
                } else
                    newTransaction.setAmount(-transferAmount);
            }
        } while (transferAmount == Double.MIN_VALUE);

        newTransaction.setDate(LocalDateTime.now());
        newTransaction.setType("Transfer");

        getCurrentUser().addTransaction(newTransaction);

        users.get(beneficiaryIndex).addBalance(transferAmount);

        System.out.println("\nTransfer successfully!");
    }
}
