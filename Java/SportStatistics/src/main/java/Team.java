/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Spider
 */
public class Team {

    private String homeTeam;
    private String visitingTeam;
    private int homePoints;
    private int visitPoints;
    private int games;
    private int wins;
    private int losses;

    public Team(String homeTeam, String visitingTeam, int homePoints,
            int visitPoints) {
        this.homeTeam = homeTeam;
        this.visitingTeam = visitingTeam;
        this.homePoints = homePoints;
        this.visitPoints = visitPoints;
    }//end team

    public String getHomeTeam() {
        return this.homeTeam;
    }//end getHomeTeam

    public String getVisitTeam() {
        return this.visitingTeam;
    }//end getVisitTeam

    public int gethomePoints() {
        return this.homePoints;
    }//end getHomePoints

    public int getVisitPoints() {
        return this.visitPoints;
    }//end getVisitPoints

    public int playGame() {
        return this.games += 1;
    }//end playGame

    public int setWins() {
        return this.wins += 1;
    }//end setWins

    public int setLosses() {
        return this.losses += 1;
    }//end setLosses

    public int getWins() {
        return this.wins;
    }//end getWins

    public int getLosses() {
        return this.losses;
    }//end getLosses

}//end class
