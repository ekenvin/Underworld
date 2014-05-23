using UnityEngine;
using System.Collections;

public class PlayerState : ActorState {

	public PlayerControl mPlayer;
	//debug purposes
	public string name;

	public PlayerState(PlayerControl _player):base(_player.gameObject){
		mPlayer=_player;
	}

	override public void onEnterState(){

	}

	override public void onExitState(){

	}

	override public void update(){

	}
	override public void fixedUpdate(){

	}
	public virtual void handleInput(){

	}
}
