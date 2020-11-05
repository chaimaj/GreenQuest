using UnityEngine;
using System.Collections;

public class SortTimer : MonoBehaviour {


	public static float timer=60;
	public static bool paused=false;
	public static bool finish=false;

	public GameObject Disabler;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0) {
						timer = 0;
						finish = true;
			
				} else {
						timer -= Time.deltaTime;

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