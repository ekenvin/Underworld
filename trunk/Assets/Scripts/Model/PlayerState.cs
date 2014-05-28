using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState : ActorState {

	public PlayerControl mPlayer;
	//debug purposes
	public string name;
	public Dictionary<string,bool> buttonStates;



	public PlayerState(PlayerControl _player):base(_player.gameObject){
		mPlayer=_player;
		buttonStates=new Dictionary<string, bool>();
		buttonStates.Add("JumpBtn",false);
		buttonStates.Add("SlideBtn",false);
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
	public virtual void handleUIInput(){

	}

	public virtual void receiveUIInputState(string btnName, bool b){
		if(buttonStates.ContainsKey(btnName)){
			buttonStates[btnName]=b;
		}
		else{
			buttonStates.Add(btnName,b);
		}
	}
}
