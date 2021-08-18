using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TheMenuInfo : Login
{
    // Left part
    public Text playername;
    public Text playerlevel;
    public Text playercoin;
    public Button logout;

   void Start()
    {

        if (PlayerPrefs.HasKey("username") && PlayerPrefs.HasKey("password"))
        {
            playername.text = "Player: " + playerData.username;
            playerlevel.text = "Level: " + playerData.level_id.ToString();
            playercoin.text = playerData.coins.ToString();
            logout.onClick.AddListener(() =>
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("LoginScene");
            });
        }
        else
        {
            SceneManager.LoadScene("LoginScene");
        }
            
    }
}
