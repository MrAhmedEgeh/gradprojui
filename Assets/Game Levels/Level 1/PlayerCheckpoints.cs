using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoints : MonoBehaviour
{
    private ConstantSaver sv;
    public Animator anim; 
    void Start()
    {
        sv = GameObject.FindGameObjectWithTag("ConstantSaver").GetComponent<ConstantSaver>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("mkFires", true);
            sv.lastCheckPointPos = transform.position;
            // update checkpoint
            Login.checkPointData[0].setCheckpoint(sv.lastCheckPointPos.ToString());
        }
    }
}
