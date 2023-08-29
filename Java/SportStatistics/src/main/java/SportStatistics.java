
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Scanner;

public class SportStatistics {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.println("File:");
        String file = scan.nextLine();
        
        ArrayList<Team> records = readRecordsFromFile(file);
        
        System.out.println("Team:");
        String team = scan.nextLine();

        int count = 0;
        int wins = 0;
        int losses = 0;
        
        for (Team teams : records){
            
            if (teams.getHomeTeam().contains(team)){
                count++;
            
            
            if (teams.gethomePoints() >= teams.getVisitPoints()){
                wins++;
                teams.setWins();
            } else {
                losses++;
                teams.setLosses();
            }//end else if
            
            teams.playGame();
            } else if (teams.getVisitTeam().contains(team)){
                count++;
                
                if (teams.getVisitPoints() >= teams.gethomePoints()){
                    wins++;
                    teams.setWins();
                } else {
                    losses++;
                    teams.setLosses();
                }//end 2nd else if
                
                teams.playGame();
                
            }//end 1st else if
            
        }//end for
        
        System.out.println("Games: " + count);
        System.out.println("Wins: " + wins);
        System.out.println("Losses: " + losses);
        
        }//end main
        
        public static ArrayList<Team> readRecordsFromFile(String file){
            ArrayList<Team> teams = new ArrayList<>();
            
            try (Scanner scanner = new Scanner(Paths.get(file))){
                while (scanner.hasNextLine()){
                    String line = scanner.nextLine();
                    String[] parts = line.split(",");
                    
                    String home = parts[0];
                    String away = parts[1];
                    int homePoints = Integer.valueOf(parts[2]);
                    int awayPoints = Integer.valueOf(parts[3]);
                    
                    teams.add(new Team(home, line, homePoints, awayPoints));
                }//end while
                
            } catch (Exception e){
                System.out.println("Error: " + e.getMessage());
            }//end try catch
            
            return teams;
        }//end readRecordsFromFile
        
    }//end class
