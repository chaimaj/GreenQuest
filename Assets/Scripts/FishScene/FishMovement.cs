using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {

	public static float MoveSpeed = 2;
	public float CurveSpeed = 1;

	
	float fTime = 0;
	Vector3 vLastPos = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
		vLastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		vLastPos = transform.position;
		
		fTime += Time.deltaTime * CurveSpeed;
		
		Vector3 vSin = new Vector3(0,2*Mathf.Sin(fTime), 0);
		Vector3 vLin = new Vector3(MoveSpeed,0, 0);
		
		transform.position += (4*vSin +vLin) * Time.deltaTime;
		
		Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
	}
}


