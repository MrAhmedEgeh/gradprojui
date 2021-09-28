using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "skull_enemy")
        {
            /*
            if(Vector2.Distance(GameObject.Find("Player").transform.position, GameObject.Find("skull").transform.position) < 2f){
                // Damage enemy
                collision.gameObject.GetComponent<EnemyAI>().EnemyTakeDamage();
            }*/
            collision.gameObject.GetComponent<EnemyAI>().EnemyTakeDamage();
        }
    }
}
