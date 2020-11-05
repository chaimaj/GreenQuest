using UnityEngine;
using System.Collections;

public class SpawnSort : MonoBehaviour {

	public Transform pos;
	public GameObject [] garbages;

	private bool spawn=true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (spawn) {
			StartCoroutine(spawnGarbage());
		}
	
	}

	IEnumerator spawnGarbage(){
		spawn = false;
		int randomNumber = Random.Range(0,garbages.Length);
		
		GameObject garbage=(GameObject)Instantiate (garbages[randomNumber],pos.position,Quaternion.identity);
		GameObject.Destroy(garbage,12);
		yield return new WaitForSeconds(3f);
		spawn = true;
		
	}
}
