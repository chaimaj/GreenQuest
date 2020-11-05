using UnityEngine;
using System.Collections;

public class CameraFollowFish : MonoBehaviour {

	public float smoothrate =0.5f;
	public Transform fish;
	
	
	private Vector2 velocity;
	
	// Use this for initialization
	void Start () {
		velocity = new Vector2 (0.5f, 0.5f);

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 newPos = Vector2.zero;
		newPos.x = Mathf.SmoothDamp (transform.position.x, fish.position.x +5, ref velocity.x, smoothrate);
		//newPos.y = Mathf.SmoothDamp(transform.position.y, fish.position.y, ref velocity.y, smoothrate);
		
		
		Vector3 newPosition = new Vector3(newPos.x, transform.position.y, -15);

			transform.position = Vector3.Slerp (transform.position, newPosition, Time.time);

	}
}
