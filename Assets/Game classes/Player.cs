using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public  class Player
{
    public  int playerid;
    public  string username;
    public  int level_id;
    public  int coins;
    private MonoBehaviour mono;
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
    }
    public void setCoins(int coins)
    {
        this.coins = coins;
    }

    public IEnumerator updateCoins(int playerid, int coins)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", playerid);
        reqData.AddField("coins", coins);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Updaters/updatePlayerCoins.php", reqData))
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
    public IEnumerator updateLevelID(int playerid, int levelid)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", playerid);
        reqData.AddField("levelID", levelid);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Updaters/updatePlayerLevelID.php", reqData))
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
