
import java.util.ArrayList;
import java.util.Scanner;

public class PersonalDetails {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        
        String name = "";
        int sum = 0, count = 0, longest, temp = 0;
        double average = 0.0;
        
        while (true){
            String input = scanner.nextLine();
            
            if (input.equals("")){
                break;
            }//end if
            
            String[] col = input.split(",");
            sum += Integer.valueOf(col[1]);
            count++;
            longest = col[0].length();
            
            if (temp < longest){
                temp = longest;
                name = col[0];
            }//end if
            
        }//end while
        System.out.println("Longest name: " + name);
        System.out.println("Average of the birth years: " + 1.0 * sum/count);
    }//end main
}//end class
