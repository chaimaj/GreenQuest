using UnityEngine;
using System.Collections;

public class RobotBehaviour : MonoBehaviour {


	public static int numberOfTrees;
	public GameObject HandPrefab;
	public GameObject HolePrefab;

	private GameObject [] trees;
	private bool take=true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (take) {
			StartCoroutine	(TakeATree());
		}
	
	}


	IEnumerator TakeATree(){
	
		trees = GameObject.FindGameObjectsWithTag ("tree");
		numberOfTrees = trees.Length;
		if ((numberOfTrees > 0) && (numberOfTrees<17)){
						take = false;
						int randomNumber = Random.Range (0, trees.Length);
						Vector3 pos = trees [randomNumber].transform.position;
						GameObject Hand; 
						Hand = Instantiate (HandPrefab, new Vector3 (pos.x, 4, 0), Quaternion.identity) as GameObject;
						iTween.MoveTo (Hand, new Vector3 (Hand.transform.position.x, pos.y+ 1.2f, 0), 3f);
						yield return new WaitForSeconds (1.5f);
						StartCoroutine (StartHand());
						Destroy (Hand);
						Destroy (trees [randomNumber]);
						Instantiate (HolePrefab, pos + new Vector3 (0, -0.7f, 0), Quaternion.identity);
				}

	}

	IEnumerator StartHand(){
				yield return new WaitForSeconds (0.1f);
				take = true;
		}
}
