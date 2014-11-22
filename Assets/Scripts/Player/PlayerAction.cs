using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour{
	

	private bool sprinting;
	private bool jumping;

	private float speed;

	// positive or negative direction
	private float direction;

	/*
	 * 
	 */ 
	void Awake(){
		this.sprinting = false;
		this.jumping = false;
		this.speed = 0f;
	} // end of Awake function



	/*
	 * Getters and Setters
	 */ 

	public float getSpeed(){return speed;}

	public void setSpeed(float speed){this.speed = speed;}

	public bool isSprinting(){return sprinting;}

	public void setSprinting(bool sprinting){this.sprinting = sprinting;}

	public bool isJumping(){return jumping;}

	public void setJumping(bool jumping){this.jumping = jumping;}

	public void setDirection(float direction){this.direction = direction;}

	public float getDirection(){return this.direction;}

} // end of PlayerAction class
