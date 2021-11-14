using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private float speed = 8;
    private Animator anim;
    private bool isAttacking = false;
    private Transform FirstPoint;
    private Transform SecondPoint;
    private Transform goalPoint;
    private Transform PlayerRef; // used for refrencing the player
    private float cooldownTime = 4f;
    private float nextDamage;
    private int BossCurrentHealth = 8;

    private void Awake()
    {
        FirstPoint = transform.parent.gameObject.transform.GetChild(1).gameObject.transform;
        SecondPoint = transform.parent.gameObject.transform.GetChild(2).gameObject.transform;
        //Get the next Point transform
        goalPoint = FirstPoint;

        PlayerRef = GameObject.Find("Player").transform;
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        float FirstPTtoSecondPT = Vector2.Distance(FirstPoint.position, SecondPoint.position);
        float PlayertoFirstPT = Vector2.Distance(PlayerRef.position, FirstPoint.position);

        if (PlayertoFirstPT < FirstPTtoSecondPT)
        {
            isAttacking = true;
        }

        if (isAttacking)
        {
            AttackPlayer();
        }
        else
        {
            MoveToNextPoint();
        }

        if (BossCurrentHealth <= 0)
        {
            anim.SetBool("boss_die", true);
            Destroy(gameObject, 0.617f);

        }
    }

    void MoveToNextPoint()
    {
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetFloat("boss_run", speed);
            transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
            {
                goalPoint = SecondPoint;

            }
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            anim.SetFloat("boss_run", speed);
            transform.position = Vector2.MoveTowards(transform.position, -goalPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
            {
                goalPoint = FirstPoint;

            }
        }
    }

    void AttackPlayer()
    {
        float FirstPTtoSecondPT = Vector2.Distance(FirstPoint.position, SecondPoint.position);
        float PlayertoFirstPT = Vector2.Distance(PlayerRef.position, FirstPoint.position);

        if (PlayertoFirstPT < FirstPTtoSecondPT)
        {
            /*FACE THE PLAYER */

            if (GameObject.Find("Player").transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }

            /*WALK TO PLAYER */
            transform.position = Vector2.MoveTowards(transform.position, PlayerRef.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, PlayerRef.position) < 2f)
            {
                /*PLAY ATTACK ANIMATION */
                anim.SetBool("boss_att1", true);

                /*DAMAGE PLAYER */
                if (Time.time > nextDamage)
                {
                    nextDamage = Time.time + cooldownTime;
                    anim.SetBool("boss_att1", true);
                    PlayerHealth.instance.TakeFixedDamage(1);
                    StartCoroutine(PlyerSpikeKnock.instance.Test());
                }
            }
        }
        else
        {
            isAttacking = false;
            anim.SetBool("boss_att1", false);
        }
    }

    public void BossTakeDamage()
    {
        BossCurrentHealth -= 2;
    }


}
