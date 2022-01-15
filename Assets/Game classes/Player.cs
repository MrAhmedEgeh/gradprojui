using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



using UnityEngine.SceneManagement;
using EasyUI.Toast;

using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Text;
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

    public IEnumerator updateCoins1(int playerid, int coins)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", playerid);
        reqData.AddField("coins", coins);
        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/updatePlayerCoins.php", reqData))
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
    public IEnumerator updateLevelID1(int playerid, int levelid)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", playerid);
        reqData.AddField("levelID", levelid);
        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/updatePlayerLevelID.php", reqData))
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



    public void updateLevelID2(int playerid, int levelid)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/updatePlayerLevelID.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("playerid", playerid.ToString());
        nvc.Add("levelID", levelid.ToString());
       

        System.Text.StringBuilder postVars = new StringBuilder();
        foreach (string key in nvc)
            postVars.AppendFormat("{0}={1}&", key, nvc[key]);
        postVars.Length -= 1; // clip off the remaining &

        //This

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            streamWriter.Write(postVars.ToString());
        Debug.Log(postVars.ToString());

    }
    public void updateCoins2(int playerid, int coins)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/updatePlayerCoins.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("playerid", playerid.ToString());
        nvc.Add("coins", coins.ToString());


        System.Text.StringBuilder postVars = new StringBuilder();
        foreach (string key in nvc)
            postVars.AppendFormat("{0}={1}&", key, nvc[key]);
        postVars.Length -= 1; // clip off the remaining &

        //This

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            streamWriter.Write(postVars.ToString());
        Debug.Log(postVars.ToString());

    }

    private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
    {
        // all Certificates are accepted
        return true;
    }
}
