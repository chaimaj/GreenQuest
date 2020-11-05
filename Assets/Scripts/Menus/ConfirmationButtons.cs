using UnityEngine;
using System.Collections;

public class ConfirmationButtons : MonoBehaviour {

	public bool yes;
	public GameObject confirmation;



	void OnMouseDown(){
		if (yes) {
			Debug.Log ("quiiiit");
						Application.Quit ();		
				} else {
			DialogOnScreen.move = true;
			confirmation.SetActive(false);
			Debug.Log ("deactivate");
		}
	
	}
}
