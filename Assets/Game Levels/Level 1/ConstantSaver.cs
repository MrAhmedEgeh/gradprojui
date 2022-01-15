using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSaver : MonoBehaviour
{
    private static ConstantSaver instance;
    public static Vector2 lastCheckPointPos;
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
    private void Start()
    {
        lastCheckPointPos = new Vector2(-0.89f, -2.25f);
    }

}
