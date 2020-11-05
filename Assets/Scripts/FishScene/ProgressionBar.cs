using UnityEngine;
using System.Collections;

public class ProgressionBar : MonoBehaviour {

	public static bool end=false;

	public GameObject fish;
	public GameObject barFish;
	public GameObject gameBegin;
	public GameObject gameEnd;
	public GameObject barBegin;
	public GameObject barEnd;

	private float gameDistance;
	private float bardistance;
	private float ratio;

	// Use this for initialization
	void Start () {
		 
		gameDistance = gameEnd.transform.position.x - gameBegin.transform.position.x;
		bardistance = barEnd.transform.position.x - barBegin.transform.position.x;
		ratio = bardistance / gameDistance;
		Debug.Log (gameDistance);
	
	}
	
	// Update is called once per frame
	void Update () {
		Progression ();
		if (fish.transform.position.x >= gameEnd.transform.position.x) {
			end =true;
			}

			
	}

	void Progression(){

		float newX = barBegin.transform.position.x + (fish.transform.position.x - gameBegin.transform.position.x) * ratio;
		Vector3 newPos = new Vector3 (newX, barBegin.transform.position.y, 0);
		barFish.transform.position = Vector3.Slerp (barFish.transform.position,newPos , Time.time);
	}


}
