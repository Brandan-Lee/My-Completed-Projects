
import java.util.ArrayList;
import java.util.Collections;

public class MagicSquare {

    private int[][] square;

    // ready constructor
    public MagicSquare(int size) {

        if (size < 2) {

            size = 2;

        }//end if

        this.square = new int[size][size];

    }//end constructor

    // implement these three methods
    public ArrayList<Integer> sumsOfRows() {

        ArrayList result = new ArrayList<>();

        for (int row = 0; row < this.square.length; row++) {

            int temp = 0;

            for (int col = 0; col < this.square.length; col++) {

                temp += this.square[row][col];

            }//end 2nd for

            result.add(temp);

        }//end 1st for

        return result;

    }//end sumsOfRows

    public ArrayList<Integer> sumsOfColumns() {

        ArrayList result = new ArrayList();

        for (int row = 0; row < this.square.length; row++) {

            int temp = 0;

            for (int col = 0; col < this.square.length; col++) {

                temp += this.square[col][row];

            }//end 2nd for

            result.add(temp);

        }//end 1st for

        return result;

    }//end sumsOfColumns

    public ArrayList<Integer> sumsOfDiagonals() {

        ArrayList result = new ArrayList();
        int temp = 0;
        int temp2 = 0;

        for (int row = 0; row < this.square.length; row++) {

            for (int col = 0; col < this.square.length; col++) {

                if (row == col) {

                    temp += this.square[row][col];

                }//end if

                if ((row + col) == (this.square.length - 1)) {

                    temp2 += this.square[row][col];

                }//end if

            }//end 2nd for

        }//end 1st for

        result.add(temp);
        result.add(temp2);
        return result;

    }//end sumsOfDiagonals

    // ready-made helper methods -- don't touch these
    public boolean isMagicSquare() {

        return sumsAreSame() && allNumbersDifferent();

    }//end isMagicSquare

    public ArrayList<Integer> giveAllNumbers() {

        ArrayList<Integer> numbers = new ArrayList<>();

        for (int row = 0; row < square.length; row++) {

            for (int col = 0; col < square[row].length; col++) {

                numbers.add(square[row][col]);

            }//end 2nd for

        }//end 1st for

        return numbers;

    }//end giveAllNumbers

    public boolean allNumbersDifferent() {

        ArrayList<Integer> numbers = giveAllNumbers();
        Collections.sort(numbers);

        for (int i = 1; i < numbers.size(); i++) {

            if (numbers.get(i - 1) == numbers.get(i)) {

                return false;

            }//end if

        }//end for

        return true;

    }//end allNumbersDifferent

    public boolean sumsAreSame() {

        ArrayList<Integer> sums = new ArrayList<>();
        sums.addAll(sumsOfRows());
        sums.addAll(sumsOfColumns());
        sums.addAll(sumsOfDiagonals());

        if (sums.size() < 3) {

            return false;

        }//end if

        for (int i = 1; i < sums.size(); i++) {

            if (sums.get(i - 1) != sums.get(i)) {

                return false;

            }//end if

        }//end for

        return true;

    }//end sumsAreSame

    public int readValue(int x, int y) {

        if (x < 0 || y < 0 || x >= getWidth() || y >= getHeight()) {

            return - 1;

        }//end if

        return this.square[y][x];

    }//end readValue

    public void placeValue(int x, int y, int value) {

        if (x < 0 || y < 0 || x >= getWidth() || y >= getHeight()) {

            return;

        }//end if

        this.square[y][x] = value;

    }//end placeValue

    public int getWidth() {

        return this.square.length;

    }//end getWidth

    public int getHeight() {

        return this.square.length;

    }//end getHeight

    @Override
    public String toString() {

        StringBuilder result = new StringBuilder();

        for (int row = 0; row < square.length; row++) {

            for (int col = 0; col < square[row].length; col++) {

                result.append(square[row][col]).append("\t");

            }//end 2nd for

            result.append("\n");

        }//end 1st for

        return result.toString();

    }//end toString

}//end class
