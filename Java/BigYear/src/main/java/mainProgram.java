
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Random;
import java.util.Scanner;

public class mainProgram {

    public static void main(String[] args) {
        // NB! Do not create other scanner objects than the one below
        // if and when you create other classes, pass the scanner to them
        // as a parameter

        Scanner scan = new Scanner(System.in);
        
        BirdDatabase birdBase = new BirdDatabase();
        
        UserInterface ui = new UserInterface(scan, birdBase);
        ui.start();
        
    }//end main
    
}//end class                                                                                                              
