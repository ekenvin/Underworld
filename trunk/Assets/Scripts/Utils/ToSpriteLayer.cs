using UnityEngine;
using System.Collections;

public class ToSpriteLayer : MonoBehaviour {

	public string toLayer="Foreground";

	// Use this for initialization
	void Start () {
	
	}

	void Awake(){

	}
	
	// Update is called once per frame
	void Update () {
		renderer.sortingLayerName=toLayer;
	}
}
