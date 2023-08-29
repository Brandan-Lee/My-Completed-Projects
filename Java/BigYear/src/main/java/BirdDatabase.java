
import java.util.ArrayList;

public class BirdDatabase {
    
    private ArrayList<Bird> birds;
    
    public BirdDatabase() {
        this.birds = new ArrayList<>();
    }//end BirdDatabase
    
    public void add(String name, String latinName) {
        this.birds.add(new Bird(name, latinName)); 
    }//end add
    
     public boolean observation(String name) {
        
        for (Bird bird : birds) {
            
            if (bird.getName().equals(name)) {
                bird.increaseObservation();
                return true;
            }//end if
            
        }//end for
        
        return false;
    }//end observation
    
    public String getAll() {
        String allBirds = "";
        
        for (Bird bird : birds) {
            allBirds += bird.toString();
        }//end for
        
        return allBirds;
    }//end getAll
    
    public String getOne(String name) {
        
        for (Bird bird : birds) {
            
            if (bird.getName().equalsIgnoreCase(name)) {
                return bird.toString();
            }//end if
            
        }//end for
        
        return null;
    }//end getOne
    
}//end class
