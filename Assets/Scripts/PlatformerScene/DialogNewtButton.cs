using UnityEngine;
using System.Collections;

public class DialogNewtButton : MonoBehaviour {

	// Use this for initialization
	public static bool next=false;

	void Update(){
		if (Input.GetKeyDown(KeyCode.Return)){
			next=true;
		}
		
	}

	void OnMouseDown(){
		next = true;
	}
}