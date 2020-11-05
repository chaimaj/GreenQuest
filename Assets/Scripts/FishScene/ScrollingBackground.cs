using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public float speed;
	//private bool state=false;
	//private Vector2 actual;
	
	// Update is called once per frame
	void Start () {
				//actual = renderer.material.mainTextureOffset;
		}

	void Update () {
	/*	if ((FishMovement.MoveSpeed == 0.5f) && (!state)){
						//actual = renderer.material.mainTextureOffset;
						speed = speed / 2;
						state = true;
						Debug.Log ("speed /2"+speed);
				}
		else {
						//actual = renderer.material.mainTextureOffset;
			
						speed = speed * 2;
						state = false;
						Debug.Log ("speed *2"+speed);
				}
*/
		//actual = new Vector2 (Time.time * speed, 0);
		renderer.material.mainTextureOffset = new Vector2 (Time.time * speed, 0);
	}
}
