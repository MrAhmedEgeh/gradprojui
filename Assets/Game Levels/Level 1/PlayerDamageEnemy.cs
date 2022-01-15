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
           // collision.gameObject.GetComponent<EnemyAI>().EnemyTakeDamage();
        }else if (collision.tag == "bat")
        {
            collision.gameObject.GetComponent<BatAI>().BatTakeDamage();
        }else if (collision.tag == "skull")
        {
            collision.gameObject.GetComponent<SkullAI>().EnemyTakeDamage();
        }else if (collision.tag == "boss")
        {
            collision.gameObject.GetComponent<BossAI>().BossTakeDamage();
        }
    }
}
