using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel2 : MonoBehaviour
{
    private GameObject Boss;

    private void Start()
    {
        Boss = GameObject.Find("Boss").transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (Boss == null)
        {
            EndLevel2Func();
        }
    }

    void EndLevel2Func()
    {
        if (Login.playerData != null && Login.playerData.level_id < 2)  // if level id is less than 2
        {
            if (Login.checkPointData[1] == null) // if player haven't played this level before
            {
                // Add new line for checkpoint table using checkpoint class
                //StartCoroutine(Login.checkPointData[0].InsertNewLine(Login.playerData.playerid, 2, "0,0"));
            }
            // Update Level_id to 2 in player table
            StartCoroutine(Login.playerData.updateLevelID(Login.playerData.playerid, 3));
            Login.playerData.setLevelID(3);
            // Update coins  in player table
            StartCoroutine(Login.playerData.updateCoins(Login.playerData.playerid, Coins.score));
            Login.playerData.setCoins(Coins.score);
            // win message panel
            winMenu.instance.wineMenu();
        }
        else
        {
            winMenu.instance.wineMenu();
        }
    }
}
