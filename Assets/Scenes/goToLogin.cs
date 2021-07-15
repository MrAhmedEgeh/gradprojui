using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class goToLogin : MonoBehaviour
{
    // Start is called before the first frame update
    public Button goBackToLogin;
    public Button submit;
    public InputField email;
    public Text notifications;
    void Start()
    {
        goBackToLogin.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LoginScene");
        });
        submit.onClick.AddListener(() =>
        {
            if (string.IsNullOrEmpty(email.text))
            {
                notifications.text = "Please enter all fields";
            }
        });
    }


}
