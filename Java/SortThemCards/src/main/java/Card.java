

public class Card implements Comparable<Card> {

    private int value;
    private Suit suit;

    public Card(int value, Suit suit) {
        
        if (value < 2 || value > 14) {
            
            throw new IllegalArgumentException("Card value must be in range "
                    + "2...14.");
            
        }//end if

        this.value = value;
        this.suit = suit;
        
    }//end constructor

    @Override
    public String toString() {
        
        String cardValue = "" + value;
        
        if(value == 11) {
            
            cardValue = "J";
            
        } else if (value == 12) {
            
            cardValue = "Q";
            
        } else if (value == 13) {
            
            cardValue = "K";
            
        } else if (value == 14) {
            
            cardValue = "A";
            
        }//end if else if else if else if
        
        return suit + " " + cardValue;
        
    }//end toString

    public int getValue() {
        
        return value;
        
    }//end getValue

    public Suit getSuit() {
        
        return suit;
        
    }//end getSuit
    
    @Override
    public int compareTo(Card comparedCard) {
        
        if (this.value == comparedCard.getValue()) {
            
            return this.suit.ordinal() - comparedCard.suit.ordinal();
            
        } else {
            
            return this.value - comparedCard.getValue();
            
        }
        
    }//end compareTo
    
}//end class
