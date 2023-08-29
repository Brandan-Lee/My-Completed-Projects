
import java.util.Scanner;

public class UserInterface {

    private Scanner scanner;
    private BirdDatabase birdBase;

    public UserInterface(Scanner scanner, BirdDatabase birdBase) {
        this.scanner = scanner;
        this.birdBase = birdBase;
    }//end UserInterface

    public void start() {

        while (true) {
            final String command = askUserInput("? ");

            if (command.equalsIgnoreCase("add")) {
                add();
            } else if (command.equalsIgnoreCase("observation")) {
                observation();
            } else if (command.equalsIgnoreCase("all")) {
                printAll();
            } else if (command.equalsIgnoreCase("one")) {
               printOne();
            } else if (command.equalsIgnoreCase("quit")) {
                break;
            } else {
                System.out.println("Unknown command");
            }

        }//end while

    }//end start

    public String askUserInput(String prompt) {
        System.out.print(prompt + " ");
        return scanner.nextLine();
    }//end askUserInput

    public void add() {
        String name = askUserInput("Name: ");
        String nameInLatin = askUserInput("Name in Latin: ");

        birdBase.add(name, nameInLatin);
    }//end add

    public void observation() {
        String name = askUserInput("Name: ");
        boolean wasSuccessful = birdBase.observation(name);
        
        if (!wasSuccessful) {
            System.out.println(name + " is not a bird!");
        }//end if
        
    }//end observation

    public void printOne() {
        String name = askUserInput("Name: ");
        String birdToPrint = birdBase.getOne(name);

        if (birdToPrint == null) {
            System.out.println(name + " is not a bird");
        } else {
            System.out.println(birdToPrint);
        }//end else if 
        
    }//end printOne
    
    public void printAll() {
        System.out.println(birdBase.getAll());
    }//end printAll
}//end class
