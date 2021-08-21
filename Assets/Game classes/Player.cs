using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public  class Player
{
    public  int playerid;
    public  string username;
    public  int level_id;
    public  int coins;

    public Player(int playerid, string username, int level_id, int coins)
    {
        this.playerid = playerid;
        this.username = username;
        this.level_id = level_id; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB
        this.coins = coins; // MUST HAVE AN UPDATE FUNCTION TO UPDATE DB
    }
    public string getId()
    {
        return username;
    }
    public void incrementCoins()
    {
        this.coins = this.coins + 10;
        // update function must called to update DB
        updateCoins(this.coins);
    }
    IEnumerator updateCoins(int coins)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", coins);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Getters/updateCoins.php", reqData))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
               
            }
        }
    }
}
