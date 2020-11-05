﻿using UnityEngine;
using System.Collections;

public class FishTimer : MonoBehaviour {

	public static float timer=0;
	public static bool paused=false;

	public GameObject fish;
	
	public GameObject Disabler;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (ProgressionBar.end) {
						timer = timer;
						fish.SetActive (false);
					
				} else {
						timer += Time.deltaTime;
				}

	if (Input.GetKeyDown (KeyCode.P)) {
				
			if (!paused){
				Time.timeScale =0;
				Disabler.GetComponent<BoxCollider2D>().enabled=true;
				paused=true;
			}
			else {
				Time.timeScale =1;
				Disabler.GetComponent<BoxCollider2D>().enabled=false;
				paused=false;
			}
			
		}
}
}
