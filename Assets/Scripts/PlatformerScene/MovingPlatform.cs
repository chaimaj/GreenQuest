using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	// Use this for initialization
	private int leftEdge =268;
	private int rightEdge=279;
	private bool right=true;
	private bool left=false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (right){
			iTween.MoveTo (gameObject, new Vector3 (rightEdge, transform.position.y, transform.position.z), 4);
				if (transform.position.x >=rightEdge-0.5f){
					right=false;
				}

				}
		else if (!right){
			iTween.MoveTo (gameObject, new Vector3 (leftEdge, transform.position.y, transform.position.z), 4);
				if (transform.position.x <=leftEdge+0.5f){
					right=true;
			}

		}
	
	}


}
