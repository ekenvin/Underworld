using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFollow : WorldObject {

	protected bool isFollowing;
	public List<GameObject> path;
	protected int curPoint;

	protected Vector2 moveDir;
	public float moveForce=1f;
	public float speedMod=0f;
	public float distThreshold=1f;
	public float maxSpeed=500f;
	public float minSpeed=1f;

	protected PlayerControl player;

	// Use this for initialization
	void Start () {
		moveDir=new Vector2(0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isFollowing){
			Vector3 dir=path[curPoint].transform.position-player.transform.position;

			dir.Normalize();
			moveDir.x=dir.x;
			moveDir.y=dir.y;

			//player.rigidbody2D.AddForce(moveDir * moveForce);
			player.rigidbody2D.velocity=moveDir*moveForce;
			if(moveForce+speedMod>minSpeed && moveForce+speedMod<maxSpeed)
				moveForce+=speedMod;

			Vector2 playerPos=new Vector2(player.transform.position.x,player.transform.position.y);
			Vector2 nextPointPos=new Vector2(path[curPoint].transform.position.x,path[curPoint].transform.position.y);
			float dist=Vector2.Distance(playerPos,nextPointPos);
			if(dist<distThreshold){
				nextPoint();
			}
		}
	}

	public void nextPoint(){
		curPoint++;
		if(curPoint>=this.path.Count){
			exitPath();
		}
	}

	override public void onPlayerCollided(PlayerControl _player){
		if(!isFollowing){

			player=_player;
			moveForce=player.rigidbody2D.velocity.magnitude;
			Debug.Log(moveForce);
			isFollowing=true;

			player.freeze();

			player.rigidbody2D.gravityScale=0;
			player.GetComponent<BoxCollider2D>().isTrigger=true;
			player.GetComponent<CircleCollider2D>().isTrigger=true;
			isFollowing=true;
			curPoint=-1;
			nextPoint();
			Debug.Log("Start Follow");
			//play animation/sound
		}

	}

	public void exitPath(){
		isFollowing=false;
		player.GetComponent<BoxCollider2D>().isTrigger=false;
		player.GetComponent<CircleCollider2D>().isTrigger=false;
		player.unfreeze();
		player.rigidbody2D.gravityScale=1;

	}
}
