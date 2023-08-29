
public abstract class Animal {
    
    private String name;
    
    public Animal(String name) {
        
        this.name = name;
        
    }//end constructor
    
    public String getName() {
        
        return this.name;
        
    }//end getName
    
    public void eat() {
        
        System.out.println(this.name + " eats");
        
    }//end eat
    
    public void sleep() {
        
        System.out.println(this.name + " sleeps");
        
    }//end sleeps
    
}//end class
