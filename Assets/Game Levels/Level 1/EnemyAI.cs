using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    public float latency = 3f;

    public int EnemyCurrentHealth = 4, EnemyMaxHealth;

    bool enemyDead = false;

    public static GameObject LastEnemy;

    private void Awake()
    {
        instance = this;
        Attack = false;
    }

    void Start()
    {
        EnemyMaxHealth = EnemyCurrentHealth;

        LastEnemy = GameObject.Find("Enemy (15)").transform.GetChild(0).gameObject;

    }

    private void Update()
    {
        if (LastEnemy == null) // if last enemy is not alive
        {
            if (Login.playerData != null && Login.playerData.level_id < 2)  // if player id is less than 2
            {
                Debug.Log("wooooooooow 2");
                if (Login.checkPointData[1] == null) // if player haven't played this level before
                {
                    // Add new line for checkpoint table using checkpoint class
                    StartCoroutine(Login.checkPointData[0].InsertNewLine(Login.playerData.playerid, 2, "0,0"));
                }
                // Update Level_id to 2 in player table
                StartCoroutine(Login.playerData.updateLevelID(Login.playerData.playerid, 2));
                Login.playerData.setLevelID(2);
                // Update coins  in player table
                StartCoroutine(Login.playerData.updateCoins(Login.playerData.playerid, Coins.score));
                Login.playerData.setCoins(Coins.score);
                // win message panel
                winMenu.instance.wineMenu();
            }
            else
            {
                Debug.Log("SOMETHING WENT WRONG");
                winMenu.instance.wineMenu();
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

        // enemy look direction
        if (GameObject.Find("Player").transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
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


