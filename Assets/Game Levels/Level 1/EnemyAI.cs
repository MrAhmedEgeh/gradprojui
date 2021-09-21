using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class EnemyAI : MonoBehaviour
{
    //Reference to waypoints
    public List<Transform> points;
    //The int value for next point index
    public int nextID = 0;
    //The value of that applies to ID for changing
   // int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;
    public Animator anim;
    public static EnemyAI instance;
    public bool Attack;
    bool IsMoveToNextPoint = true;

    public bool latency = true;

    public int EnemyCurrentHealth = 4, EnemyMaxHealth;

    bool enemyDead = false;

    public GameObject LastEnemy;
    private void Awake()
    {
        instance = this;
        Attack = false;
    }

    void Start()
    {
        EnemyMaxHealth = EnemyCurrentHealth;
        LastEnemy = GameObject.Find("Enemy (17)");


    }

    private void Update()
    {
        if (!LastEnemy.activeSelf)
        {
            if (Login.playerData.playerid != 2)
            {
                // Add new line for checkpoint table using setter
                StartCoroutine(Login.checkPointData[0].InsertNewLine(Login.playerData.playerid, 2, "0,0"));
                // Update Level_id to 2 in player table
                Login.playerData.setLevelID(2);
                // Update coins  in player table
                Login.playerData.setCoins(Coins.score);
            }
        }

        if (IsMoveToNextPoint == true)
        {
            MoveToNextPoint();
        }
        else
        {
            AttackPlayer();
        }

    }


    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into the point's direction
        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetFloat("skull_run", speed);
            transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
            {
                nextID = 0;
               
            }
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            anim.SetFloat("skull_run", speed);
            transform.position = Vector2.MoveTowards(transform.position, -goalPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
            {
                
                nextID = 1;
               
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsMoveToNextPoint = false;
        }
    }

    void AttackPlayer()
    {
        if(enemyDead == true)
        {
            return;
        }
        
       if(Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 2f) // is player in range for attack?
        {

            anim.SetFloat("skull_run", 0f);
            if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 2f)
            {
                anim.SetBool("skull_att1", true);
            }
            

        }
        else
        {
            // disable attack animation
            anim.SetBool("skull_att1", false);

            // go to patrol
            IsMoveToNextPoint = true;

            //enable running
            anim.SetFloat("skull_run", speed);
        }
    }
    public void EnemyTakeDamage()
    {
        EnemyCurrentHealth -= 1;
        if (EnemyCurrentHealth <= 0)
        {
            if(enemyDead == true) { return; }

            anim.SetBool("skull_die", true);
            Destroy(gameObject);


        }
    }

}


