using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheMenuInfo : Login
{
    // Left part
    public Text playername;
    public Text playerlevel;
    public Text playercoin;

   void Start()
    {
        playername.text = "Player: " + playerData.username;
        playerlevel.text = "Level: " + playerData.level_id;
        playercoin.text = playerData.coins.ToString();
    }
}
