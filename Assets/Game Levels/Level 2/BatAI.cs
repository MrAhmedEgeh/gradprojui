using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{
    private Transform PlayerRef; // used for refrencing the player
    private Animator anim;  // used for animation 
    private float speed = 10f;  // used for bat speed
    private Vector3 startpoint;  // used to save the first point

    private Vector3 stpoint;
    private Vector3 enpoint;

    private float cooldownTime = 8f;
    private float nextDamage;

    private int BatCurrentHealth = 3;

    private void Start()
    {
        startpoint = gameObject.transform.position;
        PlayerRef = GameObject.Find("Player").transform;
        anim = gameObject.GetComponent<Animator>();

        stpoint = transform.parent.gameObject.transform.GetChild(1).gameObject.transform.position;
        enpoint = transform.parent.gameObject.transform.GetChild(2).gameObject.transform.position;

    }
    private void Update()
    {
        AttackPlayer();

        if(BatCurrentHealth <= 0)
        {
            anim.SetBool("bat_die", true);
            Destroy(gameObject, 0.467f);
        }
    }
    void AttackPlayer()
    {
        float distanceToStartPoint = Vector2.Distance(startpoint, transform.position);
        float distanceToPlayer = Vector2.Distance(PlayerRef.position, transform.position);

        float distanceSTtoEN = Vector2.Distance(stpoint, enpoint);
        float distanceENtoPlayer = Vector2.Distance(enpoint, PlayerRef.position);

        /* if the distance between st and player is less than dtsance between st and end
         * distanceToPlayer < 5f
         */
        if (distanceENtoPlayer < distanceSTtoEN)
        {
            anim.SetFloat("bat_move", 10f);
            transform.position = Vector2.MoveTowards(this.transform.position, PlayerRef.position, speed * Time.deltaTime);

            if (distanceToPlayer < 2f && Time.time > nextDamage)
            {
                nextDamage = Time.time + cooldownTime;
                anim.SetBool("bat_att", true);
                PlayerHealth.instance.TakeFixedDamage(1);
                //StartCoroutine(PlyerSpikeKnock.instance.FixedKnockback(GameObject.Find("Player").transform.position));
                StartCoroutine(PlyerSpikeKnock.instance.Knockback(2f, 0f, GameObject.Find("Player").transform.position));
            }
        }
        else
        {
            anim.SetBool("bat_att", false);
            transform.position = Vector2.MoveTowards(this.transform.position, startpoint, speed * Time.deltaTime);
        if (distanceToStartPoint < 2f)
        {
            anim.SetFloat("bat_move", 0f);
        }

        }

    }

    public void BatTakeDamage()
    {
        BatCurrentHealth -= 3;
    }
}
