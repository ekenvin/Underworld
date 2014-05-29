using UnityEngine;
using System.Collections;

public class WorldObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.gameObject.GetComponent<PlayerControl>()!=null){
			onPlayerCollided(col.collider.gameObject.GetComponent<PlayerControl>());
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.GetComponent<PlayerControl>()!=null){
			onPlayerCollided(col.collider2D.gameObject.GetComponent<PlayerControl>());
		}
	}

	public virtual void onPlayerCollided(PlayerControl player){
		Debug.Log("Player collided");
	}
}
