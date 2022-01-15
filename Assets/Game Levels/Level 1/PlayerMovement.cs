using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
	public static PlayerMovement instance;

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;


	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	int currentWeaponLyr = 0;
	int attackCounter;
	int moblatkcounter;
    // Update is called once per frame

    private void Awake()
    {
		instance = this;

    }
  
    void Update()
	{

		horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
			AudioManager.instance.playPlayerJumpSound();
		}

		if (CrossPlatformInputManager.GetButtonDown("Crouch") || Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			animator.SetBool("IsCrouching", true);
		}
		else if (CrossPlatformInputManager.GetButtonUp("Crouch") || Input.GetButtonUp("Crouch"))
		{
			crouch = false;
			animator.SetBool("IsCrouching", false);
		}

        if (Input.GetKeyDown(KeyCode.F))
        {
			changeWeaponLyr();

		}

        if (Input.GetKeyDown(KeyCode.E) && (attackCounter != 1 && attackCounter != 2))
        {
			Attack1();
			attackCounter = 1;
		}else if (Input.GetKeyDown(KeyCode.E) && attackCounter != 2)
        {
			Attack2();
			attackCounter = 2;
		}else if (Input.GetKeyDown(KeyCode.E) && attackCounter != 3)
        {
			Attack3();
			attackCounter = 0;
		}
		
	}
	public void OnLanding()
    {
		animator.SetBool("IsJumping", false);
	}
	/*
	public void OnCrouching(bool isCrouching)
    {
		animator.SetBool("IsCrouching", isCrouching);
    }
	*/
	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	public void crouchBtnUp()
    {
		crouch = false;
		animator.SetBool("IsCrouching", false);
	}
	public void crouchBtnDown()
	{
		crouch = true;
		animator.SetBool("IsCrouching", true);
	}
	public void attackBtnDown()
    {
		
		if (moblatkcounter != 1 && moblatkcounter != 2)
		{
			Attack1();
			moblatkcounter = 1;
		}
		else if (moblatkcounter != 2)
		{
			Attack2();
			moblatkcounter = 2;
		}
		else if ( moblatkcounter != 3)
		{
			Attack3();
			moblatkcounter = 0;
		}
	}
	public void chooseIdleLyr()
    {
		animator.SetLayerWeight(0, 1);
		animator.SetLayerWeight(1, 0);
	}
	public void chooseSwordLyr()
	{
		animator.SetLayerWeight(0, 0);
		animator.SetLayerWeight(1, 1);
	}
	
	public void changeWeaponLyr()
    {
        if (currentWeaponLyr == 0)
        {
			currentWeaponLyr += 1;
			animator.SetLayerWeight(currentWeaponLyr - 1, 0);
			animator.SetLayerWeight(currentWeaponLyr, 1);
        }
        else
        {
			currentWeaponLyr -= 1;
			animator.SetLayerWeight(currentWeaponLyr + 1, 0);
			animator.SetLayerWeight(currentWeaponLyr, 1);
		}
    }

	void Attack1()
    {
		// Play animation of Attack 1
		animator.SetTrigger("att1");
		AudioManager.instance.playPlayerSwordSound();


	}
	void Attack2()
	{
		// Play animation of Attack 2
		animator.SetTrigger("att2");
		AudioManager.instance.playPlayerSwordSound();

	}
	void Attack3()
	{
		// Play animation of Attack 3
		animator.SetTrigger("att3");
		AudioManager.instance.playPlayerSwordSound();
	}

	public void PlayerDeath()
    {
		
		animator.SetBool("isDead", true);
		
	}

}