using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public List<Button> Levels = new List<Button>();

    public List<Image> level1Score;
    public List<Image> level2Score;
    public List<Image> level3Score;

    private void Start()
    {
        if (Login.playerData != null)
        {
            int levelReached = Login.playerData.level_id;
            int level1Scoring = Login.scoreData[0].score;
            int level2Scoring = Login.scoreData[1].score;
            int level3Scoring = Login.scoreData[2].score;



            for (int i = 0; i < Levels.Count; i++)
            {
                Levels[i].interactable = false;
                if(i < levelReached)
                {
                    Levels[i].interactable = true;
                }
            }
            // LEVEL 1 SCORING
            for (int i = 0; i < 5; i++)
            {
                if (i < level1Scoring)
                {
                    level1Score[i].enabled = true;
                }
                else
                {
                    level1Score[i].enabled = false;
                }
            }
            // LEVEL 2 SCORING
            for (int i = 0; i < 5; i++)
            {
                if (i < level2Scoring)
                {
                    level2Score[i].enabled = true;
                }
                else
                {
                    level2Score[i].enabled = false;
                }
            }
            // LEVEL 3 SCORING
            for (int i = 0; i < 5; i++)
            {
                if (i < level3Scoring)
                {
                    level3Score[i].enabled = true;
                }
                else
                {
                    level3Score[i].enabled = false;
                }
            }

        }
    }

   public void Level1()
    {
        SceneManager.LoadScene("level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("level3");
    }
}
