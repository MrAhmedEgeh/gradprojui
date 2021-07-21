using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
public class Register : MonoBehaviour
{
    // Start is called before the first frame update
    public Button loginBtn;
    public Button registerBtn;
    public InputField username;
    public InputField email;
    public InputField pass1;
    public InputField pass2;
    public Text notifications;
    void Start()
    {
        loginBtn.onClick.AddListener(() =>
        {
            goToLogin();
        });
        registerBtn.onClick.AddListener(() =>
        {
            if(allFieldsNotEmpty(username.text, email.text, pass1.text, pass2.text))
            {
                if (varifyEmail(email.text))
                {
                    if(varifyPassword(pass1.text, pass2.text))
                    {
                        //RegisterUser(username.text, email.text, pass1.text);
                        notifications.text = "woooooooow";
                    }
                    else
                    {
                        notifications.text = "Passwords must match and be 6 digits";
                    }
                }
                else
                {
                    notifications.text = "Please enter a valid email";
                }
            }
            else
            {
                notifications.text = "Please enter all fields";
            }
        });
    }
    public bool allFieldsNotEmpty(string username, string email, string password1, string password2)
    {
        return string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password1) ||
            string.IsNullOrEmpty(password2) ?  false : true;
    }
    public bool varifyEmail(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success ? true : false;
    }

    public bool varifyPassword(string pass1, string pass2)
    {
        return pass1.Length >= 6 && pass2.Length >= 6 ? 
               pass1.Equals(pass2) ? true : false 
           : false;
    }
    public void goToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }

    IEnumerator RegisterUser(string username, string emails, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("emails", emails);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/gradProjectBackend/Register/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                if (www.downloadHandler.text.Equals("wrong credentials") || www.downloadHandler.text.Equals("Invalid data"))
                {
                    notifications.text = www.downloadHandler.text;
                }
                else
                {
                    SceneManager.LoadScene("LoginScene");
                }

            }
        }
    }
}
