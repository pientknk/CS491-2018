﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCharacterController : ingameCharacter {
	public float jumpDelay = 0.1f;

	private Rigidbody2D rigid2D;
	private bool hasSecondJump;
	private float jumpStartTime;

	// Use this for initialization
	void Start () {
		gameObject.name = "DoubleJumpCharacter";
		base.Start();
		rigid2D = GetComponent<Rigidbody2D>();
		hasSecondJump = true;
	}

	void Update () {
		grounded();
		//get input and move player accordingly 
		playerMove(rigid2D);
		if(isGrounded && Input.GetKeyDown(keyJump)) {
			isGrounded = false;
			playerJump (rigid2D);
			jumpStartTime = Time.time + jumpDelay;
			hasSecondJump = true;
			//print ("Jumped");
		}
		else if (hasSecondJump && !isGrounded && Input.GetKeyDown(keyJump) && (Time.time > jumpStartTime)) {
			playerJump (rigid2D);
			//print ("Double jumped");
			hasSecondJump = false;
		}

		if(Input.GetKeyDown(keySwap)) {
			swapCharacter();
		}
	}

	public override void playerAction(Rigidbody2D rigidBody) {
	}

	public override void resetPlayerState() {
	}
}

