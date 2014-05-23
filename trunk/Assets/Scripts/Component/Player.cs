using UnityEngine;
using System.Collections;

public class Player : Actor {

	public PlayerControl mControl;


	// Use this for initialization
	void Start () {
		mControl=gameObject.GetComponent<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
