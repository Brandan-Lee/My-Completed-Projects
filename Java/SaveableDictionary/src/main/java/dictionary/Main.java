
/*
In this exercise we will extend the dictionary, so that it can read words from a
file and write words to a file. The dictionary must also be able to translate 
both from Finnish to another language and from another language to Finnish (in
this exercise we ignore the fact that some words might be written the same in 
Finnish and in other languages). Your mission is to create a dictionary in the
class SaveableDictionary. Implement the class in the package dictionary.

1. The basic functionality
For the dictionary, implement a constructor which takes no parameters, and the
following methods:

public void add(String words, String translation) adds a word to the dictionary.
Every word has just one translation, and if the same word is added for the 
second time, nothing happens.
public String translate(String word) returns the translation for the given word.
If the word is not in the dictionary, returns null.

2. Deleting words
Add the dictionary method public void delete(String word) which deletes the 
given word and its translation from the dictionary.

It might be worth reviewing the material concerning deleting objects from an 
ArrayList from previous weeks.

3. Reading from file
Make a constructor public SaveableDictionary(String file) and method public 
boolean load(), which loads the dictionary from the file given to the 
constructor as a parameter. If the program is unable to open the file or read 
from it, the method returns false, otherwise it returns true.

NB: the constructor only tells the dictionary the name of the file to load the 
dictionary from. The constructor does not read the file. Only the method load 
reads the file.
In the dictionary file, one line contains a word and its translation separated 
by ":". The exercise template contains a file words.txt which contains the 
following:

Read the dictionary file line by line with the method nextLine. You can split a
line using the String method split
 */
package dictionary;

public class Main {

    public static void main(String[] args) {

//1
//        SaveableDictionary dictionary = new SaveableDictionary();
//        dictionary.add("apina", "monkey");
//        dictionary.add("banaani", "banana");
//        dictionary.add("apina", "apfe");
//
//        System.out.println(dictionary.translate("apina"));
//        System.out.println(dictionary.translate("monkey"));
//        System.out.println(dictionary.translate("ohjelmointi"));
//        System.out.println(dictionary.translate("banana"));
//2
//        SaveableDictionary dictionary = new SaveableDictionary();
//        dictionary.add("apina", "monkey");
//        dictionary.add("banaani", "banana");
//        dictionary.add("ohjelmointi", "programming");
//        dictionary.delete("apina");
//        dictionary.delete("banana");
//
//        System.out.println(dictionary.translate("apina"));
//        System.out.println(dictionary.translate("monkey"));
//        System.out.println(dictionary.translate("banana"));
//        System.out.println(dictionary.translate("banaani"));
//        System.out.println(dictionary.translate("ohjelmointi"));
//3
        SaveableDictionary dictionary = new SaveableDictionary("words.txt");
        boolean wasSuccessful = dictionary.load();

        if (wasSuccessful) {
            
            System.out.println("Successfully loaded the dictionary from file");
            
        }

        System.out.println(dictionary.translate("apina"));
        System.out.println(dictionary.translate("ohjelmointi"));
        System.out.println(dictionary.translate("alla oleva"));

    }//end main

    /*
    Examples of output
    1
    monkey
    apina
    null
    banaani
    
    2
    null
    null
    null
    null
    programming
    
    3
    Successfully loaded the dictionary from file
    monkey
    null
    below
    */
}//end class
