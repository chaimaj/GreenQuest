using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public static float minXCam = -56;
	public float smoothrate =0.5f;
	Transform player;
	

	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		velocity = new Vector2 (0.5f, 0.5f);
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		Debug.Log ("minXCam  " + minXCam);
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 newPos = Vector2.zero;
		newPos.x = Mathf.SmoothDamp (transform.position.x, player.position.x, ref velocity.x, smoothrate);
		newPos.y = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smoothrate);


		Vector3 newPosition = new Vector3(newPos.x, newPos.y, -15);
		if (newPos.x > minXCam) {
						transform.position = Vector3.Slerp (transform.position, newPosition, Time.time);
				}
	}
}
