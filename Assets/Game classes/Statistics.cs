using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics 
{
    public int playerid;
    public int numberofdeath; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB

    public Statistics(int playerid, int numberofdeath)
    {
        this.playerid = playerid;
        this.numberofdeath = numberofdeath;
    }
    public int getNumberOfDeath()
    {
        return numberofdeath;
    }
    public void setNumberOfDeath(int numberofdeath)
    {
        this.numberofdeath = numberofdeath;
        // update function must called to update DB
    }
}
