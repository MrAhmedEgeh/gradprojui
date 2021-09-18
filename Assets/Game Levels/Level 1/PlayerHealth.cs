using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int currentHealth = 5, maxHealth;
    public Image[] hearts;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        hearts[currentHealth + 1].enabled = false;

        if (currentHealth <= -1)
        {
            // player Die animation
            PlayerMovement.instance.PlayerDeath();
            // DIE MENU APPEARS
            // StartCoroutine(DieMenu.instance.dieMenu());

            // Restart Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeFixedDamage(int x)
    {
        currentHealth -= x;
        hearts[currentHealth + 1].enabled = false;

        if (currentHealth <= -1)
        {
            // player Die animation
            PlayerMovement.instance.PlayerDeath();
            // DIE MENU APPEARS
            // StartCoroutine(DieMenu.instance.dieMenu());

            // Restart Scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
