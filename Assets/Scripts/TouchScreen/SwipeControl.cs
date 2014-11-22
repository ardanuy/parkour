/*
 * 
 * 8-point Compass Rose system for swipe direction recognition
 * North		N	  0°				
 * North-East	NE	 45° (45°×1)		
 * East			E	 90° (45°×2)		
 * South-East	SE	135° (45°×3)	
 * South		S	180° (45°×4)	
 * South-West	SW	225° (45°×5)	
 * West			W	270° (45°×6)	
 * North-West	NW	315° (45°×7)	
 * 
 * 
 * 
 */ 
using UnityEngine;
using System.Collections;

public class SwipeControl : TouchInput {

	// reference to PlayerAction
	private PlayerAction playerAction;

	// stores point down and up
	private Vector2 pointDownPosition, pointUpPosition;
	
	// calculates distances from the hit down and up points
	private float xDistance = 0f;
	private float yDistance = 0f;
	private float distance = 0f;
	
	// tweaks 
	public float xPixelDistanceThreshold = 40f;
	public float yPixelDistanceThreshold = 40f;
	public float distanceThreshold = 25f;

	/*
	 * 
	 */ 
	void Awake(){
		// reference to PlayerAction class
		playerAction = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<PlayerAction> ();
	} // end of Awake function
	
	/**
	 * @param touch 
	 */
	void OnTouchUp(Touch touch){
		pointUpPosition = touch.position;
		
		// update distances
		UpdateDistances (pointUpPosition);
		
		// recognizes the swipe direction based on the 8 point compass rose
		SwipeDirectionRecognition ();		

	} // end of OnTouchUp
	
	/**
	 * 
	 */
	void OnTouchDown(Touch touch){
		pointDownPosition = touch.position;
	} // end of OnTouchDown
	
	/**
	 * 
	 */
	void OnTouchStay(Touch touch){
	} // end of OnToucStay
	
	
	/**
	 * 
	 */
	void OnTouchMove(Touch touch){
	} // end of OnTouchMove
	
	
	/**
	 * 
	 */
	void OnTouchExit(Touch touch){
		pointDownPosition = new Vector2 (0, 0);
		pointUpPosition = new Vector2 (0, 0);
	} // end of OnTouchExit
	
	
	// ------------------------ Gesture Recognizer ----------------------------
	
	/**
	 * 
	 */
	private void UpdateDistances(Vector2 hitPoint){
		// update distances
		xDistance = hitPoint.x - pointDownPosition.x;
		yDistance = hitPoint.y - pointDownPosition.y;
		distance = Vector2.Distance(pointDownPosition, hitPoint);
	} // end of UpdateDistances
	
	/**
	 * 
	 */
	private void SwipeDirectionRecognition(){
		
		// if distance is greater than a threshold
		if(distance > distanceThreshold){
			// there was a swipe on the touch screen
			
			if(isNorthMove()){
			}
			else if(isNorthEastMove()){
				playerAction.setJumping(true);
			}
			else if(isEastMove()){
				// if the player has a negative direction
				if(playerAction.getDirection() < -0.1){
					// ... and if the player is moving e.g. has some speed
					if(playerAction.getSpeed() > 0.1)
						// then set a positive direction based on it's speed magnitude
						playerAction.setDirection(Mathf.Abs(playerAction.getSpeed()));
					else
						// set a positive direction
						playerAction.setDirection(1);
				}
			}
			else if(isSouthEastMove()){
			}
			else if(isSouthMove()){
			}
			else if(isSouthWestMove()){
			}
			else if(isWestMove()){
				// if the player has a positive direction
				if(playerAction.getDirection() > 0.1){
					// and if the player is moving e.g. has some speed
					if(playerAction.getSpeed() > 0.1)
						// then set a negative direction based on it's current speed
						playerAction.setDirection(playerAction.getSpeed() * -1);
					else
						// set a negative direction
						playerAction.setDirection(-1);
				}
			}
			else if(isNorthWestMove()){
				playerAction.setJumping(true);
			}
			else{
			}
		}
		
		
	} // end of SwipeDirectionRecognition
	
	/**
	 * 
	 */
	private bool isNorthMove(){
		// if Y distance is greater than a threshold and has positive value, and X distance is not greater than a threshold
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance > 0)) && (Mathf.Abs(xDistance) < xPixelDistanceThreshold) ){
			return true;
		}
		return false;		
	} // end of isNorthMove
	
	/**
	 * 
	 */
	private bool isNorthEastMove(){
		// if X and Y distances are greater than a threshold and Y and X distances are positive values
		if ( ((Mathf.Abs (yDistance) > yPixelDistanceThreshold) && (Mathf.Abs (xDistance) > xPixelDistanceThreshold)) && 
		    ((yDistance > 0) && (xDistance > 0)) ){
			return true;
		}
		return false;
	} // end of isNorthEastMove
	
	/**
	 * 
	 */
	private bool isEastMove(){
		// if Y distance is not greater than a threshold and if X distance is greater than a threshold and has positive value
		if((Mathf.Abs(yDistance) < yPixelDistanceThreshold) && ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance > 0)) ){
			return true;
		}
		return false;
	} // end of isEastMove
	
	/**
	 * 
	 */
	private bool isSouthEastMove(){
		// // if Y distance is greater than a threshold and has negative value, and X distance is greater than a threshold and has positive value
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && 
		   ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance > 0)) ){
			return true;
		}
		return false;
	} // end of isSouthEastMove
	
	/**
	 * 
	 */
	private bool isSouthMove(){
		// if Y distance is greater than a threshold and has negative value, and X distance is not greater than a threshold
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && (Mathf.Abs(xDistance) < xPixelDistanceThreshold) ){
			return true;
		}
		
		return false;
	} // end of isSouthMove
	
	/**
	 * 
	 */
	private bool isSouthWestMove(){
		// // if Y distance is greater than a threshold and has negative value, and X distance is greater than a threshold and has negative value
		if( ((Mathf.Abs(yDistance) > yPixelDistanceThreshold) && (yDistance < 0)) && 
		   ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance < 0)) ){
			return true;
		}
		
		return false;
	} // end of isSouthWestMove
	
	/**
	 * 
	 */
	private bool isWestMove(){
		// if Y distance is not greater than a threshold and if X distance is greater than a threshold and has negative value
		if((Mathf.Abs(yDistance) < yPixelDistanceThreshold) && ((Mathf.Abs(xDistance) > xPixelDistanceThreshold) && (xDistance < 0)) ){
			return true;
		}
		
		return false;
	} // end of isWestMove
	
	/**
	 * 
	 */
	private bool isNorthWestMove(){
		// if X and Y distances are greater than a threshold and Y is positive and x is negative
		if ( ((Mathf.Abs (yDistance) > yPixelDistanceThreshold) && (Mathf.Abs (xDistance) > xPixelDistanceThreshold)) && 
		    ((yDistance > 0) && (xDistance < 0)) ){
			return true;
		}
		return false;
	} // end of isNorthWestMove
	
} // end of SwipeControl class
