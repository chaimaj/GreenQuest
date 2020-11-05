using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public bool newGame;
	public bool loadGame;
	public bool miniGame;
	public bool scores;



	private Vector3 newScale;
	private Vector3 actualScale;
	private bool scale=false;
	private float speed=5;

	private GameObject menu;
	private GameObject mini;
	private GameObject scor;
	// Use this for initialization
	void Start () {
		Screen.showCursor = false;
		Debug.Log (Application.persistentDataPath);
		actualScale = gameObject.transform.localScale;
		menu = GameObject.FindGameObjectWithTag ("MainMenu");
		mini = GameObject.FindGameObjectWithTag ("MenuMini");
		scor = GameObject.FindGameObjectWithTag ("ScoreMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if (scale){ // if scale then change the scale of the gameobject to newScale
			transform.localScale = Vector3.Lerp (transform.localScale, newScale, speed * Time.deltaTime);
		}
	
	}



	private void OnMouseDown(){
			if (newGame) {
			PlayerPrefs.DeleteAll ();
			Application.LoadLevel("Scene1");
				} else if (loadGame) {
			Application.LoadLevel("Scene1");
				} else if (miniGame) {
			Debug.Log("hhhheeey");
			iTween.MoveTo (menu,new Vector3 (-12f,0,0),4);
			iTween.MoveTo (mini,new Vector3 (0,0,0),4);

				} else {
			iTween.MoveTo (menu,new Vector3 (-12f,0,0),4);
			iTween.MoveTo (scor,new Vector3 (0,0,0),4);
				}
	
	
	}



	private void OnMouseEnter () {

			scale=true;
			
		newScale = new Vector3 (0.4737732f, 0.3589222f, 1.19129f);
			

	}
	private void OnMouseExit () {

			newScale=actualScale;
			
			

		
	}
}
