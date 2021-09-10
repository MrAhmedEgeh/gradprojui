using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;



	// Update is called once per frame
	void Update()
	{

		horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


		if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
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
}