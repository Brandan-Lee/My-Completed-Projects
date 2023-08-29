package ticTacToe;

import java.util.ArrayList;
import javafx.application.Application;
import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Font;
import javafx.stage.Stage;

public class TicTacToeApplication extends Application {

    String currentPlayer = "X";
    ArrayList<Button> buttons = new ArrayList<>();
    
     public static void main(String[] args) {

        launch(TicTacToeApplication.class);

    }//end main
    
    @Override
    public void start(Stage window) throws Exception {

        BorderPane layout = new BorderPane();
        Label status = new Label("Turn: " + this.currentPlayer);
        status.setFont(Font.font("MonoSpaced", 25));

        GridPane gameBoard = new GridPane();
        gameBoard.setPadding(new Insets(10, 10, 10, 10));
        gameBoard.setHgap(10);
        gameBoard.setVgap(10);

        for (int i = 0; i < 9; i++) {

            Button button = new Button();
            button.setFont(Font.font("MonoSpaced", 25));
            button.setMinSize(70, 70);
            button.setMaxSize(70, 70);

            button.setOnMouseClicked((event) -> {

                if (status.getText().startsWith("Winner: ")
                        || status.getText().equals("It's a draw")) {

                    button.disarm();

                } else if (button.getText().isEmpty()) {

                    button.setText(this.currentPlayer);

                    if (checkIfWinner()) {
                        
                        status.setText("The end!");
                        
                    } else if (allBoxesAreFilled()) {
                        
                        status.setText("It's a draw!");
                        
                    } else {
                        
                        takeTurn();
                        status.setText("Turn: " + this.currentPlayer);
                        
                    }//end if else if else
                    
                }//end if else if

            });
            this.buttons.add(button);
            
        }//end for
        
        gameBoard.add(this.buttons.get(0), 0, 0);
        gameBoard.add(this.buttons.get(1), 0, 1);
        gameBoard.add(this.buttons.get(2), 0, 2);
        gameBoard.add(this.buttons.get(3), 1, 0);
        gameBoard.add(this.buttons.get(4), 1, 1);
        gameBoard.add(this.buttons.get(5), 1, 2);
        gameBoard.add(this.buttons.get(6), 2, 0);
        gameBoard.add(this.buttons.get(7), 2, 1);
        gameBoard.add(this.buttons.get(8), 2, 2);
        
        layout.setTop(status);
        layout.setCenter(gameBoard);
        
        Scene sScene = new Scene(layout);
        window.setScene(sScene);
        window.show();
        
    }//end start

    public void takeTurn() {

        if (this.currentPlayer.equals("X")) {

            this.currentPlayer = "O";

        } else if (this.currentPlayer.equals("O")) {

            this.currentPlayer = "X";

        }//end if else if

    }//end takeTurn

    public boolean allBoxesAreFilled() {

        for (Button b : this.buttons) {

            if (b.getText().isEmpty()) {

                return false;

            }//end if

        }//end for

        return true;

    }//end allBoxesareFilled

    public boolean checkVerticalColumns() {

        if (!this.buttons.get(0).getText().isEmpty()
                && (this.buttons.get(0).getText().equals(this.buttons.get(1).getText()))
                && (this.buttons.get(0).getText().equals(this.buttons.get(2).getText()))) {

            return true;

        }//end if

        if (!this.buttons.get(3).getText().isEmpty()
                && (this.buttons.get(3).getText().equals(this.buttons.get(4).getText()))
                && (this.buttons.get(3).getText().equals(this.buttons.get(5).getText()))) {

            return true;

        }//end if

        if (!this.buttons.get(6).getText().isEmpty()
                && (this.buttons.get(6).getText().equals(this.buttons.get(7).getText()))
                && (this.buttons.get(6).getText().equals(this.buttons.get(8).getText()))) {

            return true;

        }//end if

        return false;

    }//end checkVerticalColumns

    public boolean checkHorizontalRows() {

        if (!this.buttons.get(0).getText().isEmpty()
                && (this.buttons.get(0).getText().equals(this.buttons.get(3).getText()))
                && (this.buttons.get(0).getText().equals(this.buttons.get(6).getText()))) {

            return true;

        }//end if

        if (!this.buttons.get(1).getText().isEmpty()
                && (this.buttons.get(1).getText().equals(this.buttons.get(4).getText()))
                && (this.buttons.get(0).getText().equals(this.buttons.get(7).getText()))) {

            return true;

        }//end if

        if (!this.buttons.get(2).getText().isEmpty()
                && (this.buttons.get(2).getText().equals(this.buttons.get(5).getText()))
                && (this.buttons.get(2).getText().equals(this.buttons.get(8).getText()))) {

            return true;

        }//end if

        return false;

    }//end checkHorizontalRows

    public boolean checkDiagonals() {

        if (!this.buttons.get(0).getText().isEmpty()
                && (this.buttons.get(0).getText().equals(this.buttons.get(4).getText()))
                && (this.buttons.get(0).getText().equals(this.buttons.get(8).getText()))) {

            return true;

        }//end if

        if (!this.buttons.get(2).getText().isEmpty()
                && (this.buttons.get(2).getText().equals(this.buttons.get(4).getText()))
                && (this.buttons.get(2).getText().equals(this.buttons.get(6).getText()))) {

            return true;

        }//end if

        return false;

    }//end checkDiagonals

    public boolean checkIfWinner() {

        return checkVerticalColumns() || checkHorizontalRows() || checkDiagonals();

    }//end checkIfWinner

}//end class
