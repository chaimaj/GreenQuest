using UnityEngine;
using System.Collections;

public class TurtleCollision : MonoBehaviour {



	public static int turtleFed=0;
	public GameObject counter;
	public Sprite fixSprite;
	public Sprite fedSprite;
	public int pos;
	private int maxJelly=0;
	private bool allow=true;
	private bool fed =false;
	private Sprite actual;

	void Start(){
		actual = gameObject.GetComponent<SpriteRenderer> ().sprite;
	}


	void OnTriggerEnter2D(Collider2D col){
		if (!fed) {
						if ((col.gameObject.tag == "jelly") && (allow)) {
								maxJelly += 1;
								if (maxJelly == 10) {
										turtleFed += 1;
										gameObject.GetComponent<SpriteRenderer>().sprite =fedSprite;
										fed=true;
								}
								counter.GetComponent<TextMesh>().text=""+maxJelly;
								Destroy (col.gameObject);
						}
						if (col.gameObject.tag == "garbage") {
								Destroy (col.gameObject);
								StartCoroutine (enableTurtle ());
						}
				}
}

	IEnumerator enableTurtle(){
		allow =false;
		gameObject.GetComponent<SpriteRenderer> ().sprite = fixSprite;
		yield return new WaitForSeconds(3f);
		allow = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = actual;
	}




	
}
