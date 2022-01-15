using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel1 : MonoBehaviour
{
    private GameObject Boss;
    private bool onlyOnce = false;
    private void Start()
    {
        Boss = GameObject.Find("Enemy (8)").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss == null && onlyOnce == false)
        {
            EndLevel1Func();
        }
       
    }
    void EndLevel1Func()
    {
        if (Login.playerData != null)  
        {
            Debug.Log("level 1 score");
            Debug.Log(ScoreHandler.score);

            if (Login.playerData.level_id < 2)
            {
                // Update Level_id to 2 in player table
                //StartCoroutine(Login.playerData.updateLevelID(Login.playerData.playerid, 2));
                Login.playerData.updateLevelID2(Login.playerData.playerid, 2);
                Login.playerData.setLevelID(2);
            }

            // Update coins  in player table
           // StartCoroutine(Login.playerData.updateCoins(Login.playerData.playerid, Coins.score));
            Login.playerData.updateCoins2(Login.playerData.playerid, Coins.score);
            Login.playerData.setCoins(Coins.score);

            //SCORING
            GameScore();

            // win message panel
            winMenu.instance.wineMenu();
            onlyOnce = true;
        }
        else
        {
            Debug.Log("SOMETHING WENT WRONG");
            winMenu.instance.wineMenu();
            onlyOnce = true;
        }
    }

    void GameScore()
    {
        Debug.Log("level 1 score");
        Debug.Log(ScoreHandler.score);
        if (ScoreHandler.score == 1 || ScoreHandler.score == 2)
        {
           // StartCoroutine(Login.scoreData[0].updateScore(Login.playerData.playerid, 1, 1));
            Login.scoreData[0].updateScore2(Login.playerData.playerid, 1, 1);
            Login.scoreData[0].setScore(1);
        }
        else if (ScoreHandler.score == 3 || ScoreHandler.score == 4)
        {
            //StartCoroutine(Login.scoreData[0].updateScore(Login.playerData.playerid, 1, 2));
            Login.scoreData[0].updateScore2(Login.playerData.playerid, 1, 2);
            Login.scoreData[0].setScore(2);
        }
        else if (ScoreHandler.score == 5 || ScoreHandler.score == 6)
        {
            //StartCoroutine(Login.scoreData[0].updateScore(Login.playerData.playerid, 1, 3));
            Login.scoreData[0].updateScore2(Login.playerData.playerid, 1, 3);
            Login.scoreData[0].setScore(3);
        }
        else if (ScoreHandler.score == 7 || ScoreHandler.score == 8)
        {
            //StartCoroutine(Login.scoreData[0].updateScore(Login.playerData.playerid, 1, 4));
            Login.scoreData[0].updateScore2(Login.playerData.playerid, 1, 4);
            Login.scoreData[0].setScore(4);
        }
        else if (ScoreHandler.score == 9 || ScoreHandler.score == 10)
        {
            // StartCoroutine(Login.scoreData[0].updateScore(Login.playerData.playerid, 1, 5));
            Login.scoreData[0].updateScore2(Login.playerData.playerid, 1, 5);
            Login.scoreData[0].setScore(5);
        }
        else if (ScoreHandler.score > 10)
        {
            //StartCoroutine(Login.scoreData[0].updateScore(Login.playerData.playerid, 1, 5));
            Login.scoreData[0].updateScore2(Login.playerData.playerid, 1, 5);
            Login.scoreData[0].setScore(5);
        }
    }
}
