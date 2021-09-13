using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour
{
    public static DieMenu instance;
    [SerializeField] GameObject dieMenuObj;

    private void Awake()
    {
        instance = this;
    }
    public IEnumerator dieMenu()
    {
        yield return new WaitForSeconds(0.8f);
        dieMenuObj.SetActive(true);
        Time.timeScale = 0f;
    }
    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("level1");
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TheMenu");
    }
}
