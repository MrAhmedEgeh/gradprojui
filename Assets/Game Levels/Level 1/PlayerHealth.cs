using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public int currentHealth = 4, maxHealth;
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

        if(currentHealth <= 0)
        {
            // player Die animation
            PlayerMovement.instance.PlayerDeath();
            // DIE MENU APPEARS
            
        }
    }
}
