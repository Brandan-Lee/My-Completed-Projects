
import java.util.Scanner;

public class GiftTax {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.println("Value of the gift?");
        double value = Double.valueOf(scan.nextLine());
        
        double band1 = (100 + (value - 5000) * 0.08);
        double band2 = (1700 + (value - 25000) * 0.10);
        double band3 = (4700 + (value - 55000) * 0.12);
        double band4 = (22100 + (value - 200000) * 0.15);
        double band5 = (142100 + (value - 1000000) * 0.17);
        
        if (value < 5000) {
            System.out.println("No tax!");
        } else if ((value >= 5000) && (value < 25000)) {
            System.out.println("Tax: " + band1);   
        } else if ((value >= 25000) && (value < 55000)) {
            System.out.println("Tax: " + band2);   
        } else if ((value >= 55000) && (value < 200000)) {
            System.out.println("Tax: " + band3);   
        }   else if ((value >= 200000) && (value < 1000000)) {
            System.out.println("Tax: " + band4);    
        } else if (value >= 1000000) {
            System.out.println("Tax: " + band5);
            
        }
    }
}
