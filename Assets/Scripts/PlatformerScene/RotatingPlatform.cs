using UnityEngine;
using System.Collections;

public class RotatingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		iTween.RotateBy(gameObject, iTween.Hash("z", 1));
		StartCoroutine (WaitToRotate());
	}

	IEnumerator WaitToRotate(){
		yield return new WaitForSeconds(2);
	
	}
}
