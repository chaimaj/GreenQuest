using UnityEngine;
using System.Collections;

public class CollectGarbage : MonoBehaviour {

	public static int collectedGarbage = 0;
	public Sprite boat1;
	public Sprite boat2;
	public Sprite boat3;
	

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Collisionnn");
		DragGarbage.drag = false;
		collectedGarbage += 1;
		GameObject.Destroy (col.gameObject);
		if (collectedGarbage > 5) {
			gameObject.GetComponent<SpriteRenderer>().sprite =boat1;
		}
		if (collectedGarbage > 10) {
			gameObject.GetComponent<SpriteRenderer>().sprite =boat2;	
		}
		if (collectedGarbage > 15) {
			gameObject.GetComponent<SpriteRenderer>().sprite =boat3;
		}
	}
}
