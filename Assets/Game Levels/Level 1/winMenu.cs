using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class winMenu : MonoBehaviour
{
    public static winMenu instance;
    [SerializeField] GameObject winMenuObj;

    private void Awake()
    {
        instance = this;
    }
    public void wineMenu()
    {
        Coins.score = 0;
        winMenuObj.SetActive(true);
        Time.timeScale = 0f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TheMenu");
    }
}
