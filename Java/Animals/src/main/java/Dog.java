
public class Dog extends Animal implements NoiseCapable {

    private String name;

    public Dog(String name) {

        super(name);

    }//end constructor

    public Dog() {

        super("Dog");

    }//end 2nd constructor

    public void bark() {

        System.out.println(super.getName() + " barks");

    }//end bark

//    @Override
//    public void eat () {
//        
//        super.eat();
//        
//    }//end eat
//    
//    @Override
//    public void sleep() {
//        
//        super.sleep();
//        
//    }//end sleep
    
    @Override
    public void makeNoise() {

        bark();

    }//end makeNoise

}//end class
