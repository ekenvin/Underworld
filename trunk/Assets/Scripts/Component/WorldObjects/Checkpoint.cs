using UnityEngine;
using System.Collections;

public class Checkpoint : WorldObject {

	public float addTime;
	private Level levelInfo;
	private bool triggered;

	// Use this for initialization
	void Start () {
		levelInfo=GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<Level>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onPlayerCollided(PlayerControl player){
		if(!triggered){
			levelInfo.timeRemaining+=addTime;
			levelInfo.playerStart=this.gameObject;
			triggered=true;
		}

	}
}
