public class ClearConsole {
    public static void execute() {
        try {
            System.out.print("\033[H\033[2J");
            System.out.flush();
        } catch (final Exception e) {
            System.out.println("Cannot clear console!");
        }
    }
}
