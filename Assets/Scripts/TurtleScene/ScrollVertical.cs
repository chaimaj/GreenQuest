using UnityEngine;
using System.Collections;

public class ScrollVertical : MonoBehaviour {

	public float speed;

	
	void Update () {

		renderer.material.mainTextureOffset = new Vector2 (0, Time.time * speed);
	}
}