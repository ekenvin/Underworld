using UnityEngine;
using System.Collections;

public class BouncePad : WorldObject {
	public float bounceForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	override public void onPlayerCollided(PlayerControl player){
		player.rigidbody2D.AddForce(new Vector2(-player.rigidbody2D.velocity.x, bounceForce));
		//play animation/sound
	}
}
