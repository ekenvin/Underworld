using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	public int playerLives;
	public float timeRemaining;

	public float initialTime;

	private GameObject player;
	public GameObject playerStart;

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining-=Time.deltaTime;
		if(timeRemaining<=0){
			resetLevel();
		}
	}

	void FixedUpdate(){

	}

	public void resetLevel(){
		playerLives--;
		if(playerLives<0){

		}
		player.transform.position=playerStart.transform.position;
	}
}
