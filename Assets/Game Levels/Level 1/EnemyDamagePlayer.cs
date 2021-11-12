using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePlayer : MonoBehaviour
{
    private float cooldownTime = 4f;
    private float nextDamage;


    private void Start()
    {
        nextDamage = Time.time + 2f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Player")
        {

            if (Time.time > nextDamage)
            {
                nextDamage = Time.time + cooldownTime;
                // Take damage function
                PlayerHealth.instance.TakeFixedDamage(1);
                // Knock back function
                //StartCoroutine(PlyerSpikeKnock.instance.Knockback(0.2f, 50, GameObject.Find("Player").transform.position));
                StartCoroutine(PlyerSpikeKnock.instance.FixedKnockback(GameObject.Find("Player").transform.position));
            }


        }
    }
}
