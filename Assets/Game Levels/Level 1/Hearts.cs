using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("heart"))
        {
            Debug.Log("Enter");
            if (PlayerHealth.instance.currentHealth < 5)
            {
                Debug.Log(PlayerHealth.instance.currentHealth);

                // Grab current Health counter (1 - 5)
                int index = PlayerHealth.instance.currentHealth;
                // Enable last heart
                PlayerHealth.instance.hearts[index + 1].enabled = true;
                // Increament Counter
                PlayerHealth.instance.currentHealth++;
                // Destroy Heart item
                Destroy(collision.gameObject);

            }
        }
    }
}
