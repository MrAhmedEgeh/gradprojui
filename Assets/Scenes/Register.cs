using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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
            if (string.IsNullOrEmpty(username.text) || string.IsNullOrEmpty(email.text) || string.IsNullOrEmpty(pass1.text) ||
                string.IsNullOrEmpty(pass2.text))
            {
                notifications.text = "Please enter all fields";
            }
        });
    }
    public void goToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
