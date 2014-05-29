using UnityEngine;
using System.Collections;

public class JumpState : PlayerState {

	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 950f;			// Amount of force added when the player jumps..

	public JumpState(PlayerControl _player):base(_player){
		mPlayer=_player;
		name="Jump";
	}
	
	override public void onEnterState(){
		// Set the Jump animator trigger parameter.
		mPlayer.anim.SetTrigger("Jump");
		
		// Play a random jump audio clip.
		if(jumpClips!=null){
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], mPlayer.transform.position);
		}


		// Add a vertical force to the player.
		mPlayer.rigidbody2D.AddForce(new Vector2(mPlayer.rigidbody2D.velocity.x, jumpForce));

	}
	
	override public void onExitState(){
		
	}
	
	override public void update(){
		
	}

	override public void handleInput(){
		if(Input.GetButton("Slide") && !Input.GetButton("Jump")){
			mPlayer.addState(mPlayer.diveState);
		}
	}
}
