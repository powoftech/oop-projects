import java.util.regex.Pattern;

public class RegexUtilities {
    public static boolean isValidEmail(String email) {
        if (email == null || email.isEmpty() || email.isBlank()) {
            return false;
        }

        // A valid email address pattern from OWASP Validation Regex repository
        String emailRegex = "^[a-zA-Z0-9_+&*-]+(?:\\.[a-zA-Z0-9_+&*-]+)*@(?:[a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,}$";
        Pattern pattern = Pattern.compile(emailRegex);
        return pattern.matcher(email).matches();
    }

    public static boolean isValidName(String name) {
        if (name == null || name.isEmpty() || name.isBlank())
            return false;

        String nameRegex = "^[a-zA-Z \\-\\.\\']*$";
        Pattern pattern = Pattern.compile(nameRegex);
        return pattern.matcher(name).matches();
    }

    public static Boolean isValidDouble(String doubleString)
        {
            double balance = Double.MIN_VALUE;
            try
            {
                balance = Double.parseDouble(doubleString);
            }
            catch (NumberFormatException exception)
            {
                System.out.println("The input does not represent a number in valid format.");
                return false;
            }
            catch (NullPointerException exception)
            {
                System.out.println("The input is null or empty.");
                return false;
            }
            if (balance < 0)
            {
                System.out.println("The input cannot be negative.");
                return false;
            }
            return true;
        }
}
