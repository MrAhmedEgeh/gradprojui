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
    void Start()
    {
        loginBtn.onClick.AddListener(() =>
        {
            goToLogin();
        });
    }
    public void goToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
