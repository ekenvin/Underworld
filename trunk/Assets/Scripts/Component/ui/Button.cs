using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public delegate void OnClick();
	public OnClick onClicked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		if(onClicked!=null){
			onClicked();
		}
	}
}
