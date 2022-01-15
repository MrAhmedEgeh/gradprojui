using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel2 : MonoBehaviour
{
    private GameObject Boss;
    private bool onlyOnce = false;
    private void Start()
    {
        Boss = GameObject.Find("Boss").transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (Boss == null && onlyOnce == false)
        {
            EndLevel2Func();
        }
    }

    void EndLevel2Func()
    {
        if (Login.playerData != null)  
        {

            if (Login.playerData.level_id < 3)
            {
                // Update Level_id to 2 in player table
                //StartCoroutine(Login.playerData.updateLevelID(Login.playerData.playerid, 3));
                Login.playerData.updateLevelID2(Login.playerData.playerid, 3);
                Login.playerData.setLevelID(3);
            }

            // Update coins  in player table
            //StartCoroutine(Login.playerData.updateCoins(Login.playerData.playerid, Coins.score));
            Login.playerData.updateCoins2(Login.playerData.playerid, Coins.score);
            Login.playerData.setCoins(Coins.score);

            // score
            GameScore();

            // win message panel
            winMenu.instance.wineMenu();
            onlyOnce = true;
        }
        else
        {
            winMenu.instance.wineMenu();
            onlyOnce = true;
        }
    }
    void GameScore()
    {
        Debug.Log("level 2 score");
        Debug.Log(ScoreHandler.score);
        if (ScoreHandler.score == 1)
        {
            //StartCoroutine(Login.scoreData[1].updateScore(Login.playerData.playerid, 2, 1));
            Login.scoreData[1].updateScore2(Login.playerData.playerid, 2, 1);
            Login.scoreData[1].setScore(1);
        }
        else if (ScoreHandler.score == 2 || ScoreHandler.score == 3)
        {
            //StartCoroutine(Login.scoreData[1].updateScore(Login.playerData.playerid, 2, 2));
            Login.scoreData[1].updateScore2(Login.playerData.playerid, 2, 2);
            Login.scoreData[1].setScore(2);
        }
        else if (ScoreHandler.score == 4)
        {
            //StartCoroutine(Login.scoreData[1].updateScore(Login.playerData.playerid, 2, 3));
            Login.scoreData[1].updateScore2(Login.playerData.playerid, 2, 3);
            Login.scoreData[1].setScore(3);
        }
        else if (ScoreHandler.score == 5)
        {
            //StartCoroutine(Login.scoreData[1].updateScore(Login.playerData.playerid, 2, 4));
            Login.scoreData[1].updateScore2(Login.playerData.playerid, 2, 4);
            Login.scoreData[1].setScore(4);
        }
        else if (ScoreHandler.score == 6 || ScoreHandler.score == 7)
        {
           // StartCoroutine(Login.scoreData[1].updateScore(Login.playerData.playerid, 2, 5));
            Login.scoreData[1].updateScore2(Login.playerData.playerid, 2, 5);
            Login.scoreData[1].setScore(5);
        }
        else if (ScoreHandler.score > 7)
        {
            //StartCoroutine(Login.scoreData[1].updateScore(Login.playerData.playerid, 2, 5));
            Login.scoreData[1].updateScore2(Login.playerData.playerid, 2, 5);
            Login.scoreData[1].setScore(5);
        }
    }
}
