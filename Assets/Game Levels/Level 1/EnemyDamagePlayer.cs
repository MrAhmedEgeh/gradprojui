using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D collision)
    {
        
       // Debug.Log("Enemy damage player");
        if (collision.tag == "Player")
        {
            Debug.Log("Player detected");
            // Take damage function
            PlayerHealth.instance.TakeFixedDamage(1);
            // Knock back function
            StartCoroutine(PlyerSpikeKnock.instance.Knockback(0.2f, 50, GameObject.Find("Player").transform.position));
           
        }
    }
}
