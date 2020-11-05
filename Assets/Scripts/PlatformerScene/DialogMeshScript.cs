using UnityEngine;
using System.Collections;

public class DialogMeshScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("haa");
		gameObject.renderer.sortingLayerName = "GUI";
		gameObject.renderer.sortingOrder = 1;
		Debug.Log (gameObject.renderer.sortingLayerName);
	}
	
	// Update is called once per frame
	void Update () {
		if (DialogOnScreen.rep != null) {
			Debug.Log(DialogOnScreen.rep);
			gameObject.GetComponent<TextMesh>().text=DialogOnScreen.rep;		
		}
	
	}
}
