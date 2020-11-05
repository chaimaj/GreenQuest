using UnityEngine;
using System.Collections;

public class Begin : MonoBehaviour {

	// Use this for initialization
	public GameObject fish;
	public GameObject control;
	private GameObject menu;

	void Start () {

		menu = GameObject.FindGameObjectWithTag ("MainMenu");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		Destroy (menu);
		fish.SetActive(true);
		control.SetActive(true);
	
	}
}
