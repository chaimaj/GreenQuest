using UnityEngine;
using System.Collections;

public class GarbageBehaviour : MonoBehaviour {

	public static bool drag=false;
	private bool move=false;
	private Vector3 screenPoint;
	


	
	// Update is called once per frame
	void Update () {
	if (move) {

			transform.Translate (Vector2.right * 2f * Time.deltaTime);		
		}
	}

	void OnMouseDown(){

		screenPoint=Camera.main.WorldToScreenPoint(gameObject.transform.position);
	}
	
	
	
	void OnMouseDrag(){// drag the gameobject with the mouse
		move = false;
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPos = Camera.main.ScreenToWorldPoint (currentScreenPoint);
		transform.position = currentPos;
		
		
	}

	void OnMouseEnter(){
		drag = true;
	}
	
	void OnMouseExit(){
		drag = false;
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Move"+ col.gameObject.name);
		move = true;
	}
}
