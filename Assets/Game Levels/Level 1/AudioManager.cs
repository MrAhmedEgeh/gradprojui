using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager:MonoBehaviour
{
    // FOR PLAYER
    public AudioSource playerJump;
    public AudioSource playerSword;
    public AudioSource pickCoins;
    public AudioSource pickHearts;


    // WIN LEVEL
    public AudioSource winSound;

    // GIVE ACCESS TO THIS SCRIPT FROM OTHER SCRIPTS
    public static AudioManager instance;
    private void Start()
    {
        instance = this;
    }
    public void playPlayerJumpSound()
    {
        playerJump.Play();
    }
    public void playPlayerSwordSound()
    {
        playerSword.Play();
    }
    public void playPlayerPickCoinsSound()
    {
        pickCoins.Play();
    }
    public void playPlayerPickHeartSound()
    {
        pickHearts.Play();
    }

    public void playWinSound()
    {
        winSound.Play();
    }

}
