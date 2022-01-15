using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static int score;
    public static ScoreHandler instance;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

}
