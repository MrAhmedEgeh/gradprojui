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
    void Start()
    {
        goBackToLogin.onClick.AddListener(() =>
        {
            Debug.Log("enter");
            SceneManager.LoadScene("LoginScene");
        });
    }


}
