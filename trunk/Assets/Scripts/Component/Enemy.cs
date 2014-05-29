using UnityEngine;
using System.Collections;

public class Enemy : Actor {

	PlayerControl player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.collider.gameObject.GetComponent<PlayerControl>()!=null){
			playerInteract(col.collider.gameObject.GetComponent<PlayerControl>());
		}
	}

	public void OnCollisionExit2D(Collision2D col){
		if(col.collider.gameObject.GetComponent<PlayerControl>()!=null){
			playerEndInteract();
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.GetComponent<PlayerControl>()!=null){
			playerInteract(col.gameObject.GetComponent<PlayerControl>());
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.GetComponent<PlayerControl>()!=null){
			playerEndInteract();
		}
	}

	public virtual void playerInteract(PlayerControl _player){
		player=_player;
		if(player.mStates.Contains(player.diveState) || player.mStates.Contains(player.chargeState))
			die();
		else
			player.die();
	}

	public virtual void playerEndInteract(){

	}

	public void die(){
		playerEndInteract();
		Destroy(this.gameObject);
	}
}
