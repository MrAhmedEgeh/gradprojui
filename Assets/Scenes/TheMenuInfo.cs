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

        if (PlayerPrefs.HasKey("username") && PlayerPrefs.HasKey("password"))
        {
            playername.text = "Player: " + Login.playerData.username;
            playerlevel.text = "Level: " + Login.playerData.level_id.ToString();
            playercoin.text = Login.playerData.coins.ToString();
            /* need to add :Login first
            playername.text = "Player: " + playerData.username;
            playerlevel.text = "Level: " + playerData.level_id.ToString();
            playercoin.text = playerData.coins.ToString();*/
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
