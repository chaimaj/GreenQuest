using UnityEngine;
using System.Collections;

public class InfoNextButton : MonoBehaviour {

	// Use this for initialization

	public GameObject infoLayer;

	void Start () {
	
	}
	
	// Update is called once per frame

	void Update(){
		if (Input.GetKeyDown(KeyCode.Return)){
			iTween.MoveTo (infoLayer, Camera.main.transform.position +new Vector3 (0,-11,15),0.01f);
		}

		}

	void OnMouseDown(){
		
		iTween.MoveTo (infoLayer, Camera.main.transform.position +new Vector3 (0,-11,15),0.01f);
	}
}
