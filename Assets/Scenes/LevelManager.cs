using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public List<Button> Levels = new List<Button>();

    private void Start()
    {
        if (Login.playerData != null)
        {
            int levelReached = Login.playerData.level_id;

            for(int i = 0; i < Levels.Count; i++)
            {
                Levels[i].interactable = false;
                if(i < levelReached)
                {
                    Levels[i].interactable = true;
                }
            }
        }
    }

   public void Level1()
    {
        SceneManager.LoadScene("level1");
    }
}
