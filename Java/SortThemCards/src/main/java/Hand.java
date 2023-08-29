
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class Hand implements Comparable<Hand> {

    private List<Card> hand;

    public Hand() {

        this.hand = new ArrayList<>();

    }//end constructor

    public void add(Card card) {

        this.hand.add(card);

    }//end add

    public void print() {

        for (Card card : this.hand) {

            System.out.println(card);

        }//end for

    }//end class

    public void sort() {

        Collections.sort(this.hand);

    }//end sort

    public int compareTo(Hand otherHand) {

        int value = this.hand.stream()
                .map(card -> card.getValue())
                .reduce(0, (a, b) -> a + b);
        
        int otherValue = otherHand.hand.stream()
                .map(card -> card.getValue())
                .reduce(0, (a, b) -> a + b);

        return value - otherValue;
        
    }//end compareTo
    
    public void sortBySuit() {
        
        Collections.sort(this.hand, new BySuitInValueOrder());
        
    }//end sortBySuit

}//end class
