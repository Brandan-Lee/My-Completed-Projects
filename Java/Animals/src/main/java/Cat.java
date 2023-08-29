
public class Cat extends Animal implements NoiseCapable {

    private String name;

    public Cat(String name) {

        super(name);

    }//end constructor

    public Cat() {

        super("Cat");

    }//end 2nd constructor

    public void purr() {

        System.out.println(super.getName() + " purrs");

    }//end purr

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
        
        purr();
        
    }//end makeNoise
    
}//end class
