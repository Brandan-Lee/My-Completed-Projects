
import java.util.ArrayList;
import java.util.HashMap;


public class StorageFacility {

    private HashMap<String, ArrayList<String>> hm;
    
    public StorageFacility() {
        
        this.hm = new HashMap<>();
        
    }//end StorageFacility
    
    public void add(String unit, String item) {
        
        this.hm.putIfAbsent(unit, new ArrayList<>());
        this.hm.get(unit).add(item);
        
    }//end add
    
    public ArrayList<String> contents(String storageUnit) {
        
        ArrayList<String> empty = new ArrayList<>();
        return this.hm.getOrDefault(storageUnit, empty);         
        
    }//end contents
    
    public void remove(String storageUnit, String item) {
        
        this.hm.get(storageUnit).remove(item);
        
        if (this.hm.get(storageUnit).isEmpty()) {
            this.hm.remove(storageUnit);
        }//end if
        
    }//end remove
    
    public ArrayList<String> storageUnits() {
        
        ArrayList<String> unitsContaining = new ArrayList<>();
        
        for (String e : hm.keySet()) {
            
            if (!hm.get(e).isEmpty()) {
                unitsContaining.add(e);
            }//end if
            
        }//end for
        
        return unitsContaining;
    }//end storageUnits
}//end class
