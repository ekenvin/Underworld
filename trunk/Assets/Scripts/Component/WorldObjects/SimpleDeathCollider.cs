using UnityEngine;
using System.Collections;

public class SimpleDeathCollider : WorldObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	override public void onPlayerCollided(PlayerControl player){
		player.die();
	}
}
