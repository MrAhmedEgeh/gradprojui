using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text playerName;


    private void Start()
    {
        if (Login.playerData != null)
        {
            playerName.text = Login.playerData.username;
        }
    }
}
