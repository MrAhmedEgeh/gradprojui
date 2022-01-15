using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TheMenuInfo :  MonoBehaviour
{
    // Left part
    public Text playername;
    public Text playerlevel;
    public Text playercoin;
    public Button logout;

   void Start()
    {
        
        
        if (Login.playerData != null)
        {
            playername.text = "Player: " + Login.playerData.username;
            playerlevel.text = "Level: " + (Login.playerData.level_id - 1).ToString();
            playercoin.text = Login.playerData.coins.ToString();
            logout.onClick.AddListener(() =>
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("LoginScene");
            });
        }
        else if(Login.playerData == null)
        {
            SceneManager.LoadScene("LoginScene");
        }
        

    }
}
