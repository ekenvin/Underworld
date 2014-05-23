using UnityEngine;
using System.Collections;

public class DiveState : PlayerState {
	public float diveImpulse=1000.0f;

	public DiveState(PlayerControl _player):base(_player){
		name="Dive";
	}
	
	override public void onEnterState(){
		mPlayer.removeState(mPlayer.chargeState);
		mPlayer.rigidbody2D.gravityScale=2.0f;
		mPlayer.rigidbody2D.AddForce(Vector2.up* -diveImpulse);
	}
	
	override public void onExitState(){

		mPlayer.rigidbody2D.gravityScale=1.0f;
		mPlayer.runState.maxSpeed=mPlayer.runState.origMaxSpeed;
		mPlayer.runState.moveForce=mPlayer.runState.origMoveForce;
	}

	override public void update(){
		
	}
}
