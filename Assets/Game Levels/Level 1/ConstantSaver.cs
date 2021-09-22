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
        if (Login.playerData != null)
        {
            Debug.Log(toVector2("-0.89,-2.25").ToString());
            lastCheckPointPos = toVector2(Login.checkPointData[0].checkpoint);
            
        }
        else
        {
            lastCheckPointPos = new Vector2(-0.89f, -2.25f);
        }
    }
    public Vector2 toVector2(string x)
    {
        string[] temp = x.Split(',');
        Vector2 vec = new Vector2(int.Parse(temp[0]), int.Parse(temp[1]));

        return vec;
    }

}
