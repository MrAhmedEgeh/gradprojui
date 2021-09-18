using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        
        if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 2f) // if player is in range attack him
        {
            // Attack animation COMPO
            anim.SetBool("skull_att1", true);

        }
        else
        {
            // if the distance between enemy and point[0] or point[1] is bigger than distance between enemy and player go back to patrol
            if (Vector2.Distance(transform.position, points[0].transform.position) > Vector2.Distance(transform.position, GameObject.Find("Player").transform.position))
            {
                IsMoveToNextPoint = true;
            }
            else if (Vector2.Distance(transform.position, points[1].transform.position) > Vector2.Distance(transform.position, GameObject.Find("Player").transform.position))
            {
                IsMoveToNextPoint = true;
            }
        }
        
        if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) > 2f ) // if player is not close chase him
        {
            anim.SetBool("skull_att1", false);
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, speed * Time.deltaTime);


            if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < 2f) // if player is in range attack him
            {
                anim.SetBool("skull_att1", true);
            }

            // if the distance between enemy and point[0] or point[1] is bigger than distance between enemy and player go back to patrol
            if(Vector2.Distance(transform.position, points[0].transform.position) > Vector2.Distance(transform.position, GameObject.Find("Player").transform.position))
            {
                IsMoveToNextPoint = true;
            }else if (Vector2.Distance(transform.position, points[1].transform.position) > Vector2.Distance(transform.position, GameObject.Find("Player").transform.position))
            {
                IsMoveToNextPoint = true;
            }

        }
    }


}


