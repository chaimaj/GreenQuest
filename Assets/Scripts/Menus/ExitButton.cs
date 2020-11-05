using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {


	public GameObject confirmation;
	// Use this for initialization
	public Texture2D myCursor;
	
	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y

	void Start(){
		Screen.showCursor = false;
	}


	void OnMouseDown(){
			
		confirmation.SetActive (true);
		DialogOnScreen.move = false;
	
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);
	}
}
