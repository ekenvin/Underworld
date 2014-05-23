using UnityEngine;
using System.Collections;

public class ChargeState : PlayerState {

	public float attackImpulse=5000;
	public float attackTime=0.4f;

	public ChargeState(PlayerControl _player):base(_player){
		mPlayer=_player;
		name="Charge";
	}
	
	override public void onEnterState(){
		mPlayer.runState.maxSpeed=Mathf.Infinity;

		mPlayer.Invoke("endCharge",attackTime);
	}
	
	override public void onExitState(){
		mPlayer.rigidbody2D.gravityScale=1.0f;

		mPlayer.runState.maxSpeed=mPlayer.runState.origMaxSpeed;
		mPlayer.runState.moveForce=mPlayer.runState.origMoveForce;
	}
	
	override public void update(){
		mPlayer.rigidbody2D.AddForce(Vector2.right*attackImpulse);
	}
}
