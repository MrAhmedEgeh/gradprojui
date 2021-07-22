using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using EasyUI.Toast;
public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField username;  // USERNAME FIELD
    public InputField password; // PASSWORD FIELD
    public Button loginBtn;    // LOGIN BUTTON FIELD
    public Toggle checkbox;  // REMEMBER ME CHECKBOX
    public Button registerBtn;   // GO TO REGISTER BUTTON
    public Button forgotPass;   // GO TO FORGET PASSWORD BUTTON
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
                    if (checkbox.isOn)
                    {
                        PlayerPrefs.SetString("username", username);
                        PlayerPrefs.SetString("password", password);
                    }
                    SceneManager.LoadScene("MainMenu");
                }
               
            }
        }
    }
    public void goToRegister()
    {
        SceneManager.LoadScene("RegisterScene");
    }
}

