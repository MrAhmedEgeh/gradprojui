using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.CSharp;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Specialized;
using System.Text;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField username;  // USERNAME FIELD
    public InputField password; // PASSWORD FIELD
    public Button loginBtn;    // LOGIN BUTTON FIELD
    public Toggle checkbox;  // REMEMBER ME CHECKBOX
    public Button registerBtn;   // GO TO REGISTER BUTTON
    public Button forgotPass;   // GO TO FORGET PASSWORD BUTTON

    public static Player playerData;
    public static List<Levels> levelsData;
    public static List<Scoring> scoreData;

    void Start()
    {
        if(PlayerPrefs.HasKey("username") && PlayerPrefs.HasKey("password"))
        {
           StartCoroutine(Logins(PlayerPrefs.GetString("username"), PlayerPrefs.GetString("password")));
            //PlayerPrefs.DeleteAll();  // WILL BE USED IN THE LOGOUT
        }

        loginBtn.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(username.text) || string.IsNullOrEmpty(password.text))
            {
                Toast.Show("Please enter all fields", 2f, ToastColor.Red);
            }
            else
            {
                //StartCoroutine(Logins(username.text, password.text));
                PostForm(username.text, password.text);
            }

        });

        registerBtn.onClick.AddListener(() =>
        {
            goToRegister();
        });
        forgotPass.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("forgetPass");
        });
    }

    IEnumerator Logins(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                
                if(www.downloadHandler.text.Equals("wrong credentials") || www.downloadHandler.text.Equals("Invalid data"))
                {
                    Toast.Show(www.downloadHandler.text, 2f, ToastColor.Red);
                }
                else
                {
                    
                    if (checkbox.isOn)
                    {
                        PlayerPrefs.SetString("username", username);
                        PlayerPrefs.SetString("password", password);
                    }
                    

                    //fetch player's data from player table
                    StartCoroutine(FetchPlayerData(www.downloadHandler.text));
                    //fetch levels data
                    StartCoroutine(FetchLevelData()); 
                    // fetch scoring
                    StartCoroutine(FetchScoringData(www.downloadHandler.text));


                }
               
            }
        }
    }

    public void goToRegister()
    {
        SceneManager.LoadScene("RegisterScene");
    }

    // FETCHING PLAYER'S DATA
     IEnumerator FetchPlayerData(string id)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", id);
        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/getPlayer.php", reqData))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                playerData = JsonUtility.FromJson<Player>(www.downloadHandler.text);
                /*
                Debug.Log(playerData);
                Debug.Log(playerData.playerid);
                Debug.Log(playerData.username);
                Debug.Log(playerData.level_id);
                Debug.Log(playerData.coins);
                Debug.Log(playerData.getId());
                */
            }
        }
        
    }
    IEnumerator FetchLevelData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://gradproject.site/cgi-bin/getLevels.php"))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                levelsData = JsonConvert.DeserializeObject<List<Levels>>(www.downloadHandler.text);
                
                Debug.Log(levelsData[0].level_id);
                Debug.Log(levelsData[0].level_name);
                Debug.Log(levelsData[1].level_id);
                Debug.Log(levelsData[1].level_name);
               

            }
        }

    }

    IEnumerator FetchScoringData(string id)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", id);
        using (UnityWebRequest www = UnityWebRequest.Post("https://gradproject.site/cgi-bin/getScores.php", reqData))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                scoreData = JsonConvert.DeserializeObject<List<Scoring>>(www.downloadHandler.text);
                Debug.Log(scoreData[0].playerid);
                Debug.Log(scoreData[0].level_id);
                Debug.Log(scoreData[0].score);

                // redirect to menu
                SceneManager.LoadScene("TheMenu");

            }
        }

    }
    /*---------------TESTING PART---------------------------------------*/
    void PostForm(string username, string password)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/Login.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("loginUser", username);
        nvc.Add("loginPass", password);
        System.Text.StringBuilder postVars = new StringBuilder();
        foreach (string key in nvc)
            postVars.AppendFormat("{0}={1}&", key, nvc[key]);
        postVars.Length -= 1; // clip off the remaining &

        //This

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            streamWriter.Write(postVars.ToString());
        Debug.Log(postVars.ToString());

        WebResponse response = request.GetResponse();
        dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
        if (responseFromServer.Equals("wrong credentials") || responseFromServer.Equals("Invalid data"))
        {
            Toast.Show(responseFromServer, 2f, ToastColor.Red);
        }
        else
        {
            if (checkbox.isOn)
            {
                PlayerPrefs.SetString("username", username);
                PlayerPrefs.SetString("password", password);
            }
            FetchLevelData2();
            FetchPlayerData2(responseFromServer);
            FetchScoringData2(responseFromServer);
        }

    }

    private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
    {
        // all Certificates are accepted
        return true;
    }
    void FetchLevelData2()
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/getLevels.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "GET";
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream receiveStream = response.GetResponseStream();
        StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

        string responseFromServer = readStream.ReadToEnd();

        levelsData = JsonConvert.DeserializeObject<List<Levels>>(responseFromServer);
        /*
        Debug.Log(levelsData[0].level_id);
        Debug.Log(levelsData[0].level_name);
        Debug.Log(levelsData[1].level_id);
        Debug.Log(levelsData[1].level_name);
        */
    }
    void FetchPlayerData2(string id)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/getPlayer.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("playerid", id);
        System.Text.StringBuilder postVars = new StringBuilder();
        foreach (string key in nvc)
            postVars.AppendFormat("{0}={1}&", key, nvc[key]);
        postVars.Length -= 1; // clip off the remaining &

        //This

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            streamWriter.Write(postVars.ToString());
        Debug.Log(postVars.ToString());

        WebResponse response = request.GetResponse();
        dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
       
        playerData = JsonUtility.FromJson<Player>(responseFromServer);
        /*
        Debug.Log(playerData);
        Debug.Log(playerData.playerid);
        Debug.Log(playerData.username);
        Debug.Log(playerData.level_id);
        Debug.Log(playerData.coins);
        Debug.Log(playerData.getId());
        */
    }
    void FetchScoringData2(string id)
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://gradproject.site/cgi-bin/getScores.php");
        request.ContentType = "application/x-www-form-urlencoded";
        request.Method = "POST";
        Stream dataStream = request.GetRequestStream();
        NameValueCollection nvc = new NameValueCollection();
        nvc.Add("playerid", id);
        System.Text.StringBuilder postVars = new StringBuilder();
        foreach (string key in nvc)
            postVars.AppendFormat("{0}={1}&", key, nvc[key]);
        postVars.Length -= 1; // clip off the remaining &

        //This

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            streamWriter.Write(postVars.ToString());
        Debug.Log(postVars.ToString());

        WebResponse response = request.GetResponse();
        dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();

        scoreData = JsonConvert.DeserializeObject<List<Scoring>>(responseFromServer);
        Debug.Log(scoreData[0].playerid);
        Debug.Log(scoreData[0].level_id);
        Debug.Log(scoreData[0].score);

        // redirect to menu
       SceneManager.LoadScene("TheMenu");
    }
}

