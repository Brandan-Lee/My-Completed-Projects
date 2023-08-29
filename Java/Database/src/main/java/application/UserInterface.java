package application;

import java.sql.SQLException;
import java.util.Scanner;

public class UserInterface {

    private Scanner scanner;
    private TodoDao database;

    public UserInterface(Scanner scanner, TodoDao database) {
        
        this.scanner = scanner;
        this.database = database;
        
    }//end constructor

    public void start() throws SQLException {
        
        while (true) {
            
            System.out.println("");
            System.out.println("Enter command:");
            System.out.println("1) list");
            System.out.println("2) add");
            System.out.println("3) mark as done");
            System.out.println("4) remove");
            System.out.println("x) quit");

            System.out.print("> ");
            String command = this.scanner.nextLine();
            
            if (command.equals("x")) {
                
                break;
                
            }//end if

            // implement the functionality here
            
            switch (Integer.parseInt(command)) {
                
                case 1:
                    listContents();
                    break;
                case 2:
                    addNewToDos();
                    break;
                case 3:
                    markTaskAsCompleted();
                    break;
                case 4:
                    removeTask();
                    break;
                default:
                    System.out.println("Invalid option");
                    break;
                    
            }//end switch
            
        }//end while

        System.out.println("Thank you!");
        
    }//end start
    
    public void listContents() throws SQLException {
        
        System.out.println("Listing the database contents");
        System.out.println(this.database.list());
        
    }//end listContents
    
    public void addNewToDos() throws SQLException {
        
        System.out.println("Adding a new todo");
        System.out.println("Enter name");
        String name = this.scanner.nextLine();
        String description = this.scanner.nextLine();
        this.database.add(new Todo(name, description, false));
        
    }//end addnewToDos
    
    public void markTaskAsCompleted() throws SQLException {
        
        System.out.println("Which todo should be marked as done (give the id)?");
        int todoCompleted = Integer.valueOf(this.scanner.nextLine());
        this.database.markAsDone(todoCompleted);
        
    }//end marktaskAsCompleted
    
    public void removeTask() throws SQLException {
        
        System.out.println("Which todo should be removed (give the id)?");
        int todoToremove = Integer.valueOf(this.scanner.nextLine());
        this.database.remove(todoToremove);
        
    }//end removeTask
    
}//end class
