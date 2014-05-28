using UnityEngine;
using System.Collections;

public class LevelInfoDisplay : MonoBehaviour {
	public TextMesh lives;
	public TextMesh timer;
	public bool jumpPressed;
	public bool slidePressed;
	public Level levelInfo;

	public Button jumpBtn;
	public Button slideBtn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lives.text="DEATHS: "+levelInfo.playerLives;
		timer.text="TIME LEFT: "+(int)levelInfo.timeRemaining;
		jumpPressed=jumpBtn.isDown;
		slidePressed=slideBtn.isDown;
	}


}
