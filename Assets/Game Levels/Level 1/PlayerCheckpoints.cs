using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoints : MonoBehaviour
{
    public Animator anim; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("mkFires", true);
            ConstantSaver.lastCheckPointPos = transform.position;
            // update checkpoint
            if (Login.playerData != null)
            {
                Login.checkPointData[0].setCheckpoint(ConstantSaver.lastCheckPointPos.ToString());
            }
        }
    }
}
