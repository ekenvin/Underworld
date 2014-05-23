using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void onPlayerCollided(PlayerControl player){
		Debug.Log("Player collided");
	}
}
