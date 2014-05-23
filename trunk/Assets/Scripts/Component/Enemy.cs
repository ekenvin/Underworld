using UnityEngine;
using System.Collections;

public class Enemy : Actor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void die(){
		Destroy(this.gameObject);
	}
}
