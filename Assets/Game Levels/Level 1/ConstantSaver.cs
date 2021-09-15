using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSaver : MonoBehaviour
{
    private static ConstantSaver instance;
    public Vector2 lastCheckPointPos;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
