using UnityEngine;
using System.Collections;

public class DecorChange : MonoBehaviour {

	private GameObject [] parts;

	// Use this for initialization
	void Start () {
		parts = GameObject.FindGameObjectsWithTag ("Part");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject part in parts) {
			BoxCollider2D [] garbage = part.GetComponentsInChildren<BoxCollider2D>();
			if (garbage.Length==0){
				part.GetComponentInChildren<SpriteRenderer>().color= new Color(42*0.004f,197*0.004f,179*0.004f);
			}

		}
	
	}
}
