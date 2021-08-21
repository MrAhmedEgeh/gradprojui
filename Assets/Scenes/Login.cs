using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
/*
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;*/
using System.IO;

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
    public static Levels levelsData;
    public static Checkpoint checkPointData;
    public static Statistics statisticsData;
    public static Weapons weaponsData;
    void Start()
    {
        if(PlayerPrefs.HasKey("username") && PlayerPrefs.HasKey("password"))
        {
            //StartCoroutine(Logins(PlayerPrefs.GetString("username"), PlayerPrefs.GetString("password")));
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
                StartCoroutine(Logins(username.text, password.text));
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

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Login/Login.php", form))
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
                    /*
                    if (checkbox.isOn)
                    {
                        PlayerPrefs.SetString("username", username);
                        PlayerPrefs.SetString("password", password);
                    }*/
                    

                    //fetch player's data from player table
                    StartCoroutine(FetchPlayerData(www.downloadHandler.text));
                    //fetch levels data
                    StartCoroutine(FetchLevelData()); // not done
                    //fetch checkpoints data
                    StartCoroutine(FetchCheckpointsData(www.downloadHandler.text));
                    //fetch statistics data
                    StartCoroutine(FetchStatisticsData(www.downloadHandler.text));
                    //fetch weapons data
                    StartCoroutine(FetchWeaponsData(www.downloadHandler.text));
                    // redirect to menu
                    //SceneManager.LoadScene("TheMenu");

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
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Getters/getPlayer.php", reqData))
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
                Debug.Log(playerData.getId());*/
                
            }
        }
        
    }
    IEnumerator FetchLevelData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/gradProjectBackend/Getters/getLevels.php"))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                levelsData = JsonUtility.FromJson<Levels>(www.downloadHandler.text);
                //Debug.Log(www.downloadHandler.text);
                //Debug.Log(levelsData.level_id);


            }
        }

    }
    IEnumerator FetchCheckpointsData(string id)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Getters/getCheckpoints.php", reqData))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                checkPointData = JsonUtility.FromJson<Checkpoint>(www.downloadHandler.text);
                //Debug.Log(checkPointData.checkpoint);

            }
        }

    }
    IEnumerator FetchStatisticsData(string id)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Getters/getStatistics.php", reqData))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                statisticsData = JsonUtility.FromJson<Statistics>(www.downloadHandler.text);
                //Debug.Log(statisticsData.numberofdeath);

            }
        }

    }
    IEnumerator FetchWeaponsData(string id)
    {
        WWWForm reqData = new WWWForm();
        reqData.AddField("playerid", id);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Getters/getWeapons.php", reqData))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                weaponsData = JsonUtility.FromJson<Weapons>(www.downloadHandler.text);
                Debug.Log(weaponsData.weapon_name);

            }
        }

    }
}

