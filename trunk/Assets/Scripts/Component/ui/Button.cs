using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public delegate void OnClick(string btnName,bool b);
	public OnClick onClicked;

	public bool isDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		isDown=false;
		if(onClicked!=null){
			onClicked(gameObject.name, isDown);
		}

	}

	void OnMouseDown(){
		isDown=true;
		if(onClicked!=null){
			onClicked(gameObject.name, isDown);
		}

	}

	void OnMouseEnter(){
		if(Input.GetMouseButton(0)){
			isDown=true;
		}
		if(onClicked!=null){
			onClicked(gameObject.name, isDown);
		}
	}

	void OnMouseExit(){
		isDown=false;
		if(onClicked!=null){
			onClicked(gameObject.name, isDown);
		}
	}
}
