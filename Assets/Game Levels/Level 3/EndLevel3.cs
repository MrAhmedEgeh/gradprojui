using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndLevel3Func();


        }
    }

    void EndLevel3Func()
    {
        if (Login.playerData != null)  
        {

            if (Login.playerData.level_id < 4)
            {
                // Update Level_id to 3 in player table
                //StartCoroutine(Login.playerData.updateLevelID(Login.playerData.playerid, 4));
                Login.playerData.updateLevelID2(Login.playerData.playerid, 4);
                Login.playerData.setLevelID(4);
            }
            // Update coins  in player table
            //StartCoroutine(Login.playerData.updateCoins(Login.playerData.playerid, Coins.score));
            Login.playerData.updateCoins2(Login.playerData.playerid, Coins.score);
            Login.playerData.setCoins(Coins.score);

            GameScore();

            // win message panel
            winMenu.instance.wineMenu();
        }
        else
        {
            winMenu.instance.wineMenu();
        }
    }
    void GameScore()
    {
        if (ScoreHandler.score == 1)
        {
            // StartCoroutine(Login.scoreData[2].updateScore(Login.playerData.playerid, 3, 1));
            Login.scoreData[2].updateScore2(Login.playerData.playerid, 3, 1);
            Login.scoreData[2].setScore(1);
        }
        else if (ScoreHandler.score == 2)
        {
            //StartCoroutine(Login.scoreData[2].updateScore(Login.playerData.playerid, 3, 2));
            Login.scoreData[2].updateScore2(Login.playerData.playerid, 3, 2);
            Login.scoreData[2].setScore(2);
        }
        else if (ScoreHandler.score == 3)
        {
           // StartCoroutine(Login.scoreData[2].updateScore(Login.playerData.playerid, 3, 3));
            Login.scoreData[2].updateScore2(Login.playerData.playerid, 3, 3);
            Login.scoreData[2].setScore(3);
        }
        else if (ScoreHandler.score == 4 || ScoreHandler.score == 5)
        {
            //StartCoroutine(Login.scoreData[2].updateScore(Login.playerData.playerid, 3, 4));
            Login.scoreData[2].updateScore2(Login.playerData.playerid, 3, 4);
            Login.scoreData[2].setScore(4);
        }
        else if (ScoreHandler.score == 6)
        {
           // StartCoroutine(Login.scoreData[2].updateScore(Login.playerData.playerid, 3, 5));
            Login.scoreData[2].updateScore2(Login.playerData.playerid, 3, 5);
            Login.scoreData[2].setScore(5);
        }
        else if (ScoreHandler.score > 6)
        {
            //StartCoroutine(Login.scoreData[2].updateScore(Login.playerData.playerid, 3, 5));
            Login.scoreData[2].updateScore2(Login.playerData.playerid, 3, 5);
            Login.scoreData[2].setScore(5);
        }
    }
}
