using UnityEngine;
using System.Collections;

public class SlideState : PlayerState {

	public float slideStickImpulse;


	public SlideState(PlayerControl _player):base(_player){
		mPlayer=_player;
		slideStickImpulse=20;
		name="slide";
	}
	
	override public void onEnterState(){
		mPlayer.runState.maxSpeed=mPlayer.runState.origMaxSpeed;
		mPlayer.runState.moveForce=mPlayer.runState.origMoveForce;
	}
	
	override public void onExitState(){
		mPlayer.rigidbody2D.gravityScale=1.0f;
		mPlayer.runState.maxSpeed=mPlayer.runState.origMaxSpeed;
		mPlayer.runState.moveForce=mPlayer.runState.origMoveForce;
	}
	
	override public void update(){
		//slow down while sliding
		mPlayer.rigidbody2D.AddForce(Vector2.up * -(mPlayer.runState.moveForce/slideStickImpulse));
		//moveForce/=1.05f;
	}
	override public void handleInput(){
		if(Input.GetButtonUp("Slide")){
			mPlayer.removeState(mPlayer.slideState);
		}
		
	}

	override public void handleUIInput(){
		//UI and mobile input
		Debug.Log(buttonStates["SlideBtn"]);
		if(!buttonStates["SlideBtn"]){
			//Debug.Log("Exit slide state");
			mPlayer.removeState(mPlayer.slideState);
		}
	}
}
