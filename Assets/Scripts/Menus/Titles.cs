using UnityEngine;
using System.Collections;

public class Titles : MonoBehaviour {


	public int order =1;
	// Use this for initialization
	void Start () {
		gameObject.renderer.sortingLayerName = "GUI";
		gameObject.renderer.sortingOrder = order;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
