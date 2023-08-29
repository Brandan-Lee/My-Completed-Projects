
public class Bird {
    
    private String name;
    private String latinName;
    private int observation;
    
    public Bird(String name, String latinName) {
        this.name = name;
        this.latinName = latinName;
        this.observation = 0;
    }//end Bird
    
    public String getName() {
        return this.name;
    }//end getName
    
    public String getLatinName() {
        return this.latinName;
    }//end getLatinName
    
    public void increaseObservation() {
        this.observation++;
    }//end increaseObservation
    
    @Override
    public String toString() {
        return this.name + " (" + this.latinName + "): " + this.observation + " observations";
    }//end toString
            
}//end class
