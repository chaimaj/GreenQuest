using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public static float timer=0;
	public static bool paused=false;

	public GameObject menuPause;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (DialogOnScreen.move) {
						timer += Time.deltaTime;
				} else {
						timer = timer;
				}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (!paused){
				DialogOnScreen.move=false;
				paused=true;
				menuPause.SetActive(true);
			}
			else {
				DialogOnScreen.move=true;
				menuPause.SetActive(false);
				paused=false;
			}

		}
	}


}
