using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    void Start()
    {
        transform.position = ConstantSaver.lastCheckPointPos;
    }
}
