import java.time.format.DateTimeFormatter;

public class DateFormatter {
    private static final DateTimeFormatter formatter = DateTimeFormatter.ofPattern("MM/dd/yyyy");

    public static DateTimeFormatter getFormatter() {
        return DateFormatter.formatter;
    }
}
