using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{

     void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player" && gameObject.transform.parent.GetComponent<EnemyAI>().latency == true)
        {

        Debug.Log("Player detected");
        // Take damage function
        PlayerHealth.instance.TakeFixedDamage(1);
            gameObject.transform.parent.GetComponent<EnemyAI>().latency = !gameObject.transform.parent.GetComponent<EnemyAI>().latency;
            // Knock back function
            StartCoroutine(PlyerSpikeKnock.instance.Knockback(0.2f, 50, GameObject.Find("Player").transform.position));



        }
    }
}
