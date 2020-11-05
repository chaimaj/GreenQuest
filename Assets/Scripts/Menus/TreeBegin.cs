using UnityEngine;
using System.Collections;

public class TreeBegin : MonoBehaviour {

	public GameObject control;
	private GameObject menu;
	private GameObject [] holes;


	void Awake(){
		holes = GameObject.FindGameObjectsWithTag ("hole");
		foreach (GameObject hole in holes) {
			hole.SetActive(false);		
		}
	}

	// Use this for initialization
	void Start () {
		menu = GameObject.FindGameObjectWithTag ("MainMenu");

	}
	
	// Update is called once per frame
	void OnMouseDown(){
		Destroy (menu);
		foreach (GameObject hole in holes) {
			hole.SetActive(true);		
		}
		control.SetActive(true);
	}
}
