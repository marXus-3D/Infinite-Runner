﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour 
{
	private CharacterController controller;
	private Vector3 moveVector;
	public float speed = 5.0f;
	public float verticalVelocity = 0.0f;
	public float gravity = 12.0f;
	
	public float animationDuration = 2f;
	private float startTime;
	private bool isDead = false;

	void Start () {
		controller = GetComponent<CharacterController>();
		startTime = Time.time;
	}
	
	
	void Update () {

		if (isDead)
			return;

		if (Time.time - startTime < animationDuration)
		{
			controller.Move(Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;

		if(controller.isGrounded)
		{
			verticalVelocity = -0.5f;
		}
		else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//X _ Left and Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * 5;
		//Y _ Up and Down
		moveVector.y = verticalVelocity;

		//Z - Forward
		moveVector.z = speed;

		controller.Move((moveVector * speed) * Time.deltaTime);
	}

	public void SetSpeed(float modifier)
	{
		speed = 5.0f + modifier;
	}

 	//Called everytime it touches a collider
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		// if u want a better calculation (hit.point.z > transform.position.z + 0.f && hit.gameObject.tag == "Obstacle")
		if(hit.gameObject.tag == "Obstacle")
			Death();
	}

	private void Death()
	{
		isDead = true;
		Debug.Log("Dead");
		GetComponent<Score>().OnDeath();
	}
}
