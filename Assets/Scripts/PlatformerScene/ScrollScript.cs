using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {

	public float speed = 0;
	Transform player;
	Vector2 actual;
	// Use this for initialization
	void Start () {
		actual = renderer.material.mainTextureOffset;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float movement = Mathf.Round (Input.GetAxis ("Horizontal"));

		if (movement == 0) 
			{
			renderer.material.mainTextureOffset = actual;
			} 
		else 
			{
			actual = new Vector2 (player.position.x*speed, actual.y+0f);
			renderer.material.mainTextureOffset = actual;
			
			}
	}
}
