package application;

public class Todo {

    private int id;
    private String name;
    private String description;
    private Boolean done;

    public Todo(int id, String name, String description, Boolean done) {
        
        this.id = id;
        this.name = name;
        this.description = description;
        this.done = done;
        
    }//end constructor

    public Todo(String name, String description, Boolean done) {
        
        this(-1, name, description, done);
        
    }//end 2nd constructor

    public int getId() {
        
        return id;
        
    }//end getId

    public void setId(int id) {
        
        this.id = id;
        
    }//end setId

    public String getName() {
        
        return name;
        
    }//end getName

    public void setName(String name) {
        
        this.name = name;
        
    }//end setName

    public String getDescription() {
        
        return description;
        
    }//end getDescription

    public void setDescription(String description) {
        
        this.description = description;
        
    }//end setDescription

    public Boolean getDone() {
        
        return done;
        
    }//end getDone

    public void setDone(Boolean done) {
        
        this.done = done;
        
    }//end setDone

    @Override
    public String toString() {
        
        return "Todo{" + "id=" + id + ", name=" + name + ", description=" + 
                description + ", done=" + done + '}';
        
    }//end toString

}//end class
