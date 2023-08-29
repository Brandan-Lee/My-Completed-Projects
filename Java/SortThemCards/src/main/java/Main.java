
import java.util.ArrayList;
import java.util.Collections;


/*
The exercise template has a class that represents a playing card. Each card has
a value and a suit. A card's value is represented as a number 2, 3, ..., 14 and
its suit as Club, Diamond, Heart or Spade. Ace's value is 14. The value is 
represented with an integer, and the suit as an enum. Cards also have a method
toString, which can be used to print the value and the suit in a readable form.

1. Comparable Card class
Change the Card class to be Comparable. Implement the compareTo method so that
using it sorts the cards in ascending order based on their value. If the cards
being compared have the same value, they are sorted by club first, diamond 
second, heart third, and spade last.

Reading Ordinal method of Enum will help you out in sorting the cards by their
suit.
So, for this sorting, the least valuable card is two of clubs and most valuable
card is the ace of spades.

2. Hand
Create a class Hand to represent the cards in a player's hand. Add the following
methods to the class:

public void add(Card card) adds a card to the hand
public void print() prints the cards in hand as shown in the example below

Use an ArrayList to store the cards.

3. Sorting the hand
Add a method public void sort() to the Hand class, which sorts the cards in the
hand. After sorting, the cards are printed in order:

4. Comparing hands
In a card game, hands are ranked based on the sum of values of its cards. Modify
the Hand class to be comparable based on this criteria, i.e. change the class so
that interface Comparable<Hand> applies to it.

5. Sorting cards with different criteria
What if we want to sort the cards in different ways, e.g. sorting all the cards
of the same suit in a row. A class can only have one compareTo method, so we'll
need something else to sort the cards in to a different order.

Alternative sorting systems are possible through different sorting classes. Such
a class must have the Comparator<Card> interface. An object of the sorting class
will then compare two cards give as parameters. The class only has one method,
compare(Card c1, Card c2), which returns a negative value if the card c1 should
be sorted before card c2, a positive value if card c2 comes before card c1, and
zero if they are equal.

The idea is to create a different sorting class for each different way of 
sorting the cards, e.g. cards of the same suit in a row.:

When sorting the cards by suit, use the same order as with the compareTo method:
clubs first, diamonds second, hearts third, spades last.

Sorting still works with the sort method of Collections class. As its other 
parameter, the method now receives the object that has the sorting logic.

Now, create a class BySuitInValueOrder class that has the Comparator interface,
which sorts the cards in the same order as in the above example, except that now
the cards are sorted by value inside their suit.

6. Sorting the hand by suit
Add a method public void sortBySuit() to class Hand. When the method is called,
it sorts the cards in the hand with the same logic as in the previous part. 
After being sorted, the cards are printed in the following order:
 */
public class Main {

    public static void main(String[] args) {
        // test your code here

//        Card first = new Card(2, Suit.DIAMOND);
//        Card second = new Card(14, Suit.SPADE);
//        Card third = new Card(12, Suit.HEART);
//
//        System.out.println(first);
//        System.out.println(second);
//        System.out.println(third);
//2
//        Hand hand = new Hand();
//
//        hand.add(new Card(2, Suit.DIAMOND));
//        hand.add(new Card(14, Suit.SPADE));
//        hand.add(new Card(12, Suit.HEART));
//        hand.add(new Card(2, Suit.SPADE));
//
//        hand.print();
//3
//        Hand hand = new Hand();
//
//        hand.add(new Card(2, Suit.DIAMOND));
//        hand.add(new Card(14, Suit.SPADE));
//        hand.add(new Card(12, Suit.HEART));
//        hand.add(new Card(2, Suit.SPADE));
//
//        hand.sort();
//
//        hand.print();
//4
//        Hand hand1 = new Hand();
//
//        hand1.add(new Card(2, Suit.DIAMOND));
//        hand1.add(new Card(14, Suit.SPADE));
//        hand1.add(new Card(12, Suit.HEART));
//        hand1.add(new Card(2, Suit.SPADE));
//
//        Hand hand2 = new Hand();
//
//        hand2.add(new Card(11, Suit.DIAMOND));
//        hand2.add(new Card(11, Suit.SPADE));
//        hand2.add(new Card(11, Suit.HEART));
//
//        int comparison = hand1.compareTo(hand2);
//
//        if (comparison < 0) {
//            
//            System.out.println("better hand is");
//            hand2.print();
//            
//        } else if (comparison > 0) {
//            
//            System.out.println("better hand is");
//            hand1.print();
//            
//        } else {
//            
//            System.out.println("hands are equal");
//            
//        }//end if else if else\
//5
//        ArrayList<Card> cards = new ArrayList<>();
//
//        cards.add(new Card(3, Suit.SPADE));
//        cards.add(new Card(2, Suit.DIAMOND));
//        cards.add(new Card(14, Suit.SPADE));
//        cards.add(new Card(12, Suit.HEART));
//        cards.add(new Card(2, Suit.SPADE));
//
//        SortBySuit sortBySuitSorter = new SortBySuit();
//        Collections.sort(cards, sortBySuitSorter);
//
//        cards.stream()
//                .forEach(c -> System.out.println(c));
//6
        Hand hand = new Hand();

        hand.add(new Card(12, Suit.HEART));
        hand.add(new Card(4, Suit.SPADE));
        hand.add(new Card(2, Suit.DIAMOND));
        hand.add(new Card(14, Suit.SPADE));
        hand.add(new Card(7, Suit.HEART));
        hand.add(new Card(2, Suit.SPADE));

        hand.sortBySuit();

        hand.print();

    }//end main

    /*
    Examples of output
    DIAMOND 2
    SPADE A
    HEART Q
    
    2
    DIAMOND 2
    SPADE A
    HEART Q
    SPADE 2
    
    3
    DIAMOND 2
    SPADE 2
    HEART Q
    SPADE A
    
    4
    better hand is
    DIAMOND J
    SPADE J
    HEART J
    
    5
    DIAMOND 2
    HEART Q
    SPADE 3
    Spade A
    Spade 2
    
    6
    DIAMOND 2
    HEART 7
    HEART Q
    SPADE 2
    SPADE 4
    SPADE A
     */
}//end class
