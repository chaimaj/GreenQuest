using UnityEngine;
using System.Collections;

public class BackMenu : MonoBehaviour {

	public GameObject mini;

	private Vector3 newScale;
	private Vector3 actualScale;

	private bool scale=false;
	private float speed=5;
	private GameObject menu;


	// Use this for initialization
	void Start () {
		actualScale = gameObject.transform.localScale;
		menu = GameObject.FindGameObjectWithTag ("MainMenu");

	}
	
	// Update is called once per frame
	void Update () {
		if (scale){ // if scale then change the scale of the gameobject to newScale
			transform.localScale = Vector3.Lerp (transform.localScale, newScale, speed * Time.deltaTime);
		}
	}

	private void OnMouseEnter () {
		
		scale=true;
		newScale = new Vector3 (0.2922589f, 0.2214104f, 1.19129f);
		}

	private void OnMouseExit () {
		newScale=actualScale;
		}

	void OnMouseDown(){
		iTween.MoveTo (menu,new Vector3 (0,0,0),4);
		iTween.MoveTo (mini,new Vector3 (12,0,0),4);
	
	}
}
