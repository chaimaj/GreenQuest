using UnityEngine;
using System.Collections;

public class MiniJeux : MonoBehaviour {

	public string levelToLoad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
			if (gameObject.tag == "unlocked") {
			PlayerPrefs.SetString ("Location","FromMenu");
			Application.LoadLevel(levelToLoad);
		}
	
	}
}
