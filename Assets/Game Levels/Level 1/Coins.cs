using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coins : MonoBehaviour
{
    public Text Score;
    int score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            score++;
            Score.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
