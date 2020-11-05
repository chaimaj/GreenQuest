using UnityEngine;
using System.Collections;

public class CanBehaviour : MonoBehaviour {

	public static int score;
	public static int combo =0;
	public string garbageTag;


	private bool addTime=true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
 if ((combo == 3) && (addTime)){
			addTime=false;
			Debug.Log ("aaaaaa");
			SortTimer.timer+=0.5f;

		
		}
if ((combo == 6) && (addTime)){
			SortTimer.timer+=1;
			addTime=false;
			
		}
if ((combo == 9) && (addTime)){
			SortTimer.timer+=1.5f;
			addTime=false;
			
		}
if ((combo == 12) && (addTime)){
			SortTimer.timer+=2;
			addTime=false;
			
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		GarbageBehaviour.drag = false;
		if (col.gameObject.tag == garbageTag) {
						addTime=true;
						combo+=1;
						score +=1;
						Debug.Log ("Goood");	
						Destroy (col.gameObject);
				} else {
				combo=0;
			if (score>0){
				score -=1;}
				Debug.Log ("Wrooong");	
				Destroy (col.gameObject);
				}

	
	}
}
