using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public  class Player
{
    public  int playerid;
    public  string username;
    public  int level_id;
    public  int coins;

    public Player(int playerid, string username, int level_id, int coins)
    {
        this.playerid = playerid;
        this.username = username;
        this.level_id = level_id;
        this.coins = coins;
    }
    public string getId()
    {
        return username;
    }
}
