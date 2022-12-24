import java.lang.System;
import java.time.*;

import classes.*;
import classes.Bank;
import classes.Bank.Status;
import classes.User.Permission;
import classes.utility.*;

public class Main {
    public static void main(String[] args) throws Exception {
        Bank.getUsers().add(new User("0000", "Administrator", LocalDate.EPOCH, 12345678, "admin@gmail.com", "Admin",
                Permission.Administrator));
        Bank.getUsers().add(new User("0001", "Phuong Dang", LocalDate.of(2003, 04, 10), 3000000, "phuong@gmail.com",
                "Phuong", Permission.Default));
        Bank.getUsers().add(new User("0002", "Tai Ong", LocalDate.of(2003, 01, 01), 4000000, "tai@gmail.com", "Tai",
                Permission.Default));

        // int index = 0;
        // for (User user : Bank.getUsers()) {
        // System.out.println("User #" + (++index) + ": ");
        // user.exportInformation();
        // }
        boolean showMenu = true;
        boolean isDefault;

        while (showMenu) {
            isDefault = false;

            ClearConsole.execute();

            System.out.println("============ The World Bank ============");
            System.out.println("(R) Register account");
            System.out.println("(S) Savings account calculator");

            if (Bank.getStatus() == Status.LoggedOut) {
                System.out.println("(L) Login");
            }
            if (Bank.getStatus() == Status.LoggedIn) {
                System.out.println("(L) Logout");
                System.out.println("1. Deposit");
                System.out.println("2. Withdraw");
                System.out.println("3. Transfer");
                System.out.println("4. Open credit card");
                System.out.println("5. Export transaction history");
                System.out.println("6. Export user information");

                if (Bank.getCurrentUser().getPermission() == Permission.Administrator) {
                    System.out.println("*Administrator features: ");
                    System.out.println("(A) Export all users' information");
                }
            }
            System.out.println("(E) Exit application");
            System.out.println("========================================");

            switch (System.console().readLine("Select an option: ")) {
                case "R":
                case "r":
                    Bank.register();
                    break;

                case "S":
                case "s":
                    Bank.savingsAccount();
                    break;

                case "L":
                case "l":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.logout();
                    else
                        Bank.login();
                    break;

                case "1":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.getCurrentUser().deposit();
                    else
                        isDefault = true;
                    break;

                case "2":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.getCurrentUser().withdraw();
                    else
                        isDefault = true;
                    break;

                case "3":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.transfer();
                    else
                        isDefault = true;
                    break;

                case "4":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.getCurrentUser().openCard();
                    else
                        isDefault = true;
                    break;

                case "5":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.getCurrentUser().exportTransactionHistory();
                    else
                        isDefault = true;
                    break;

                case "6":
                    if (Bank.getStatus() == Status.LoggedIn)
                        Bank.getCurrentUser().exportInformation();
                    else
                        isDefault = true;
                    break;

                case "A":
                case "a":
                    if (Bank.getStatus() == Status.LoggedIn
                            && Bank.getCurrentUser().getPermission() == Permission.Administrator) {
                        ClearConsole.execute();
                        int index = 0;
                        for (User user : Bank.getUsers()) {
                            System.out.println("User #" + (++index) + ": ");
                            user.exportInformation();
                        }
                    } else
                        isDefault = true;
                    break;

                case "E":
                case "e":
                    showMenu = false;
                    System.out.println("Exiting...");
                    return;

                default:
                    break;
            }
            if (isDefault) {
                System.out.println("\nInvalid input!\nTry again...");
            }

            System.out.println("\nPress any key to continue...");

            System.console().readPassword();

        }

    }
}