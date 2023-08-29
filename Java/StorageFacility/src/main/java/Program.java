
public class Program {

    public static void main(String[] args) {

//1
//        StorageFacility facility = new StorageFacility();
//        facility.add("a14", "ice skates");
//        facility.add("a14", "ice hockey stick");
//        facility.add("a14", "ice skates");
//
//        facility.add("f156", "rollerblades");
//        facility.add("f156", "rollerblades");
//
//        facility.add("g63", "six");
//        facility.add("g63", "pi");
//
//        System.out.println(facility.contents("a14"));
//        System.out.println(facility.contents("f156"));
//2
        StorageFacility facility = new StorageFacility();
        facility.add("a14", "ice skates");
        facility.add("a14", "ice hockey stick");
        facility.add("a14", "ice skates");

        facility.add("f156", "rollerblades");
        facility.add("f156", "rollerblades");

        facility.add("g63", "six");
        facility.add("g63", "pi");

        facility.remove("f156", "rollerblades");

        System.out.println(facility.contents("f156"));

        facility.remove("f156", "rollerblades");

        System.out.println(facility.storageUnits());

//        StorageFacility facility = new StorageFacility();
//        facility.add("a14", "ice skates");
//        facility.add("a14", "ice hockey stick");
//        facility.add("a14", "ice skates");
//
//        facility.add("f156", "rollerblades");
//        facility.add("f156", "rollerblades");
//
//        facility.add("g63", "six");
//        facility.add("g63", "pi");
//
//        facility.remove("f156", "rollerblades");
//
//        System.out.println(facility.contents("f156"));
//        System.out.println(facility.storageUnits());
    }//end main

    /*
    Examples of output
    1.
    [ice skates, ice hockey stick, ice skates]
    [rollerblades, rollerblades]
    
    2.
    
     */
}//end class
