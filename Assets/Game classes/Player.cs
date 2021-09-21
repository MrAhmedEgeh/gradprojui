using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public  class Player:MonoBehaviour
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
    public int getId()
    {
        return playerid;
    }
    public string getUsername()
    {
        return username;
    }
    public int getLevel_ID()
    {
        return level_id;
    }
    public int getCoins()
    {
        return coins;
    }
    // SETTERS
    public void setLevelID(int id)
    {
        this.level_id = id;
        // update in db
        StartCoroutine(updateLevelID(level_id));
    }
    public void setCoins(int coins)
    {
        this.coins = coins;
        // update in db
        StartCoroutine(updateCoins(coins));
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
    IEnumerator updateLevelID(int levelid)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("levelid", levelid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Getters/updateLevelID.php", reqData))
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
