using UnityEngine;
using System.Collections;

public class ClickGarbage : MonoBehaviour {

	public static int maxGarbage=0;
	public bool isGarbage;



	void OnMouseDown(){
		if (isGarbage){
			maxGarbage+=1;	
		}
		GameObject.Destroy (gameObject);
	}
}
