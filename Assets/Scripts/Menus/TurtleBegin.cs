using UnityEngine;
using System.Collections;

public class TurtleBegin : MonoBehaviour {

	public GameObject control;
	private GameObject menu;

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag ("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		Destroy (menu);
		control.SetActive(true);
		
	}
}
