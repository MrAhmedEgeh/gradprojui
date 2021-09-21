using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSaver : MonoBehaviour
{
    private static ConstantSaver instance;
    public Vector2 lastCheckPointPos;
    private void Awake()
    {
        if(Login.playerData != null)
        {
            lastCheckPointPos = getVector2(Login.checkPointData[0].checkpoint);
        }
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

    public Vector2 getVector2(string rString)
    {
        string[] temp = rString.Substring(1, rString.Length - 1).Split(',');
        float x = System.Convert.ToSingle(temp[0]);
        float y = System.Convert.ToSingle(temp[1]);
        Vector2 rValue = new Vector2(x, y);
        return rValue;
    }

}
