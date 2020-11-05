using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public bool newGame=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown(){

		if (newGame) {
			PlayerPrefs.DeleteAll ();
			}
		Application.LoadLevel ("Scene1");
	}
	

}
