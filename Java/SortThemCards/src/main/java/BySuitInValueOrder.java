
import java.util.Comparator;

public class BySuitInValueOrder implements Comparator<Card> {
    
    public int compare(Card c1, Card c2) {
        
        int suitValueOrder = c1.getSuit().ordinal() - c2.getSuit().ordinal();
        
        if (suitValueOrder == 0) {
            
            return c1.compareTo(c2);
            
        } else {
            
            return suitValueOrder;
            
        }//end else if
        
    }//end compare
    
}//end class
