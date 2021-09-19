using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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
    private void Awake()
    {
        instance = this;
        Attack = false;
    }

    private void Update()
    {


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
        
       if(Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 2f) // is player in range for attack?
        {
            /*
            // get closer to player
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);

            // Play run animation
            anim.SetFloat("skull_run", speed);

            // if enemy is close to player
            if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 1.5f)
            {
                anim.SetFloat("skull_run", 0);
                anim.SetBool("skull_att1", true);
            }
            */
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


}


