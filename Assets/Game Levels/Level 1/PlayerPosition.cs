using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private ConstantSaver sv;
    void Start()
    {
        sv = GameObject.FindGameObjectWithTag("ConstantSaver").GetComponent<ConstantSaver>();
        transform.position = sv.lastCheckPointPos;
    }
}
