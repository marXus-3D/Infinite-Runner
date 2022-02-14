using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMotor : MonoBehaviour 
{
	private Transform lookAt;
	private Vector3 moveVector;
private float transition = 0f;
public float animDuration = 2f;
public Vector3 animOffset = new Vector3(0,2,5);
	private Vector3 startOffset;

	void Start () {
		lookAt = GameObject.FindGameObjectWithTag("Player").transform;
		startOffset = transform.position - lookAt.position;
	}
	
	void Update () {
		moveVector = lookAt.position + startOffset;
		//X
		moveVector.x = 0;
		//Y
		moveVector.y = Mathf.Clamp(moveVector.y,3,5);

		if (transition > 1.0f)
		{
			transform.position = moveVector;
		}
		else
		{
			//Animation start of the game
			transform.position = Vector3.Lerp(moveVector + animOffset,moveVector,transition);
			transition += Time.deltaTime * 1 / animDuration;
			transform.LookAt (lookAt.position + Vector3.up);
		}
	}
}
