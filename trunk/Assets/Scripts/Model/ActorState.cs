using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorState{
	public GameObject mActor;


	public ActorState(GameObject _actor){
		mActor=_actor;
	}

	public virtual void onEnterState(){

	}

	public virtual void onExitState(){

	}

	public virtual void update(){

	}
	public virtual void fixedUpdate(){

	}
}
