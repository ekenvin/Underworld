using UnityEngine;
using System.Collections;

public class LevelInfoDisplay : MonoBehaviour {
	public TextMesh lives;
	public TextMesh timer;
	public Level levelInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lives.text="Lives: "+levelInfo.playerLives;
		timer.text="Time Remaining: "+(int)levelInfo.timeRemaining;
	}


}
