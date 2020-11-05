using UnityEngine;
using System.Collections;

public class DragGarbage : MonoBehaviour {

	public static bool drag=false;
	private Vector3 screenPoint;


	void OnMouseDown(){
		screenPoint=Camera.main.WorldToScreenPoint(gameObject.transform.position);
	}
	

	
	void OnMouseDrag(){// drag the gameobject with the mouse

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
}
