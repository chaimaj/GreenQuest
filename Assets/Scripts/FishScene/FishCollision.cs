using UnityEngine;
using System.Collections;

public class FishCollision : MonoBehaviour {

	public Sprite fixSprite;
	private Sprite actual;
	private bool fixFish=true;
	// Use this for initialization
	void Start () {
		actual = gameObject.GetComponent<SpriteRenderer> ().sprite;
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("collisiooooooon");
		if (fixFish) {
			Destroy (col.gameObject);	
			StartCoroutine (enableFish());
		}
	}

	
	IEnumerator enableFish(){
		fixFish =false;
		gameObject.GetComponent<SpriteRenderer> ().sprite = fixSprite;
		FishMovement.MoveSpeed = 0.5f;
		yield return new WaitForSeconds(4f);
		fixFish = true;
		gameObject.GetComponent<SpriteRenderer> ().sprite = actual;
		FishMovement.MoveSpeed = 1f;
	}
}