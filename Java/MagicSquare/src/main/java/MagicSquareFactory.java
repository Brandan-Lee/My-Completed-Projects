
public class MagicSquareFactory {

    public MagicSquare createMagicSquare(int size) {

        MagicSquare square = new MagicSquare(size);
        int currentRow = 0;
        int currentCol = size / 2;
        square.placeValue(currentCol, currentRow, 1);
        
        for (int i = 2; i <= size * size; i++) {
            
            int nextRow = currentRow - 1;
            
            if (nextRow < 0) {
                
                nextRow = square.getHeight() - 1;
                
            }//end if
            
            int nextCol = currentCol + 1;
            
            if (nextCol >= square.getWidth()) {
                
                nextCol = 0;
                
            }//end if
            
            int nextBoxValue = square.readValue(nextCol, nextRow);
            
            if (nextBoxValue != 0) {
                
                nextRow = currentRow + 1;
                nextCol = currentCol;
                
            }//end if
            
            square.placeValue(nextCol, nextRow, i);
            currentRow = nextRow;
            currentCol = nextCol;
            
        }//end for
        
        return square;
        
    }//end createMagicSquare

}//end class
