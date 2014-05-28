using UnityEngine;
using System.Collections;

public class RunState : PlayerState {

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float origMoveForce;
	public float maxSpeed = 40f;				// The fastest the player can travel in the x axis.
	public float origMaxSpeed;
	public float acceleration=0.08f;
	public bool attackEnabled;

	public RunState(PlayerControl _player):base(_player){
		name="Run";
		origMaxSpeed=maxSpeed;
		origMoveForce=moveForce;
		attackEnabled=true;
	}

	override public void onEnterState(){
		
	}
	
	override public void onExitState(){
		
	}
	
	override public void update(){

		// Cache the horizontal input.
		float h = acceleration;//Input.GetAxis("Horizontal")/2;
		
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		mPlayer.anim.SetFloat("Speed", mPlayer.rigidbody2D.velocity.x);
		mPlayer.anim.speed=mPlayer.rigidbody2D.velocity.x/10.0f;


		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * mPlayer.rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			mPlayer.rigidbody2D.AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(mPlayer.rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			mPlayer.rigidbody2D.velocity = new Vector2(Mathf.Sign(mPlayer.rigidbody2D.velocity.x) * maxSpeed, mPlayer.rigidbody2D.velocity.y);
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !mPlayer.facingRight)
			// ... flip the player.
			mPlayer.Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && mPlayer.facingRight)
			// ... flip the player.
			mPlayer.Flip();
	}
	override public void handleInput(){
		if(Input.GetButton("Jump") && Input.GetButton("Slide") && attackEnabled){
			mPlayer.addState(mPlayer.chargeState);
			attackEnabled=false;
		}
		else if(Input.GetButtonDown("Jump")){
			mPlayer.addState(mPlayer.jumpState);
		}
		else if(mPlayer.grounded && Input.GetButton("Slide")){
			mPlayer.addState(mPlayer.slideState);
		}

		if(!Input.GetButton("Jump") && !Input.GetButton("Slide")){
			attackEnabled=true;
		}


		
		
	}

	override public void handleUIInput(){
		//UI and mobile input
		if(buttonStates["JumpBtn"] && buttonStates["SlideBtn"]){
			mPlayer.addState(mPlayer.chargeState);
			attackEnabled=false;
		}
		else if(buttonStates["JumpBtn"])
			mPlayer.addState(mPlayer.jumpState);
		else if(mPlayer.grounded && buttonStates["SlideBtn"])
			mPlayer.addState(mPlayer.slideState);

		if(!buttonStates["JumpBtn"] && !buttonStates["SlideBtn"]){
			attackEnabled=true;
		}
	}
}
