using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private PlayerHealth health;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           PlayerHealth.instance.TakeDamage();
            StartCoroutine(PlyerSpikeKnock.instance.Knockback(0.02f, 290, GameObject.Find("Player").transform.position));

           
        }
    }
}
