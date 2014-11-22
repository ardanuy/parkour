using UnityEngine;
using System.Collections;

public class TouchInputControl : TouchInput {

	// reference to PlayerAction
	private PlayerAction playerAction;

	// calculates the amount of speed according to the hit point screen
	private float speed;
	
	// touch postition on the screen
	private Vector2 pointDownPosition, pointUpPosition;
	

	/*
	 * 
	 */ 
	void Awake(){
		// reference to PlayerAction class
		playerAction = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerAction> ();

	} // end of Awake function

	/**
	 * 
	 */
	void OnTouchUp(Touch touch){
		pointUpPosition = touch.position;
		speed = 0f;
		playerAction.setSpeed (speed);
		playerAction.setSprinting (false);
	} // end of OnTouchUp

	/**
	 * 
	 */
	void OnTouchDown(Touch touch){
		pointDownPosition = touch.position;
		speed = (pointDownPosition.y / Screen.height);

		// look for an action
		ActionRecognition (touch);
			

	} // end of OnTouchDown
	
	/**
	 * 
	 */
	void OnTouchStay(Touch touch){
		speed = (touch.position.y / Screen.height);


	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Touch touch){
		speed = (touch.position.y / Screen.height);

		// look for an action
		ActionRecognition (touch);

	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Vector2 hitPoint){
		pointDownPosition = new Vector2 (0, 0);
		pointUpPosition = new Vector2 (0, 0);
	} // end of OnTouchExit
	

	
	// ------------------------ Action Recognizer ----------------------------
	/**
	 * 
	 */
	private void ActionRecognition(Touch touch){

		if(touch.tapCount == 1){
			playerAction.setSpeed(speed);
		}
		// if tap count is equal to 2
		else if(touch.tapCount == 2){
			playerAction.setSprinting(true);
			playerAction.setSpeed(1);
		}
		else{
			// to do
		}

	}

} // end of TouchInputControl class

