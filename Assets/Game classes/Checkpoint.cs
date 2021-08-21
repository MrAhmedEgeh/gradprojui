using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint 
{
    public int playerid;
    public int level_id; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB
    public string checkpoint; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB

    public Checkpoint(int playerid, int level_id, string checkpoint)
    {
        this.playerid = playerid;
        this.level_id = level_id;
        this.checkpoint = checkpoint;
    }
    public string getCheckpoint()
    {
        return checkpoint;
    }
    public void setCheckpoint(string point)
    {
        this.checkpoint = point;
        // update function must called to update DB
    }
    
}
