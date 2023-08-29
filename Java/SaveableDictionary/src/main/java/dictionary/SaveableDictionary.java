package dictionary;

import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class SaveableDictionary {

    private Map<String, String> words;
    private String file;

    public SaveableDictionary() {

        this.words = new HashMap<>();

    }//end constructor

    public SaveableDictionary(String file) {
            
        this();
        this.file = file;

    }//end 2nd constructor

    public void add(String words, String translation) {

        if (this.words.containsKey(words)) {

            return;

        }//end if

        this.words.put(words, translation);
        this.words.put(translation, words);

    }//end add

    public String translate(String word) {

        if (!this.words.containsKey(word)) {

            return null;

        } else {

            return this.words.get(word);

        }//end else if

    }//end translate

    public void delete(String word) {

        String translate = translate(word);
        this.words.remove(word);
        this.words.remove(translate);

    }//end delete

    public boolean load() {

        try {
            
            Files.lines(Paths.get(this.file))
                    .map(m -> m.split(":"))
                    .forEach(parts -> {
                        this.words.put(parts[0], parts[1]);
                        this.words.put(parts[1], parts[0]);
                    });
            
            return true;
            
        } catch (IOException e) {
            
            return false;
            
        }//end try catch
        
    }//end load
    
    public boolean save() {
        
        try {
            
            PrintWriter writer = new PrintWriter(new File(this.file));
            saveWords(writer);
            writer.close();
            
        } catch (Exception e) {
            
            return false;
            
        }//end try catch
        
        return true;
        
    }//end save
    
    public void saveWords(PrintWriter writer) {
        
        List<String> alreadySaved = new ArrayList<>();
        
        this.words.keySet().stream()
                .forEach(word -> {
                    
                    if (alreadySaved.contains(word)) {
                        
                        return;
                        
                    }//end if
                    
                    String part = word + ":" + this.words.get(word);
                    writer.println(part);
                    alreadySaved.add(word);
                    alreadySaved.add(this.words.get(word));
   
                });
        
    }//end saveWords

}//end class
