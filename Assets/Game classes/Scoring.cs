using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Specialized;
using System.Text;
public class Scoring
{
    public int playerid;
    public int level_id;
    public int score;

    public int getId()
    {
        return playerid;
    }
    public int getLevelID()
    {
        return level_id;
    }
    public int getScore()
    {
        return score;
    }
    //SETTERS
    
    public void setScore(int score)
    {
        this.score = score;
    }
    public IEnumerator updateScore(int playerid, int level, int score)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", playerid);
        reqData.AddField("level_id", level);
        reqData.AddField("score", score);

        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/updateScore.php", reqData))
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

    public void updateScore2(int playerid, int level, int score)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/updateScore.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("playerid", playerid.ToString());
        nvc.Add("level_id", level.ToString());
        nvc.Add("score", score.ToString());



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
