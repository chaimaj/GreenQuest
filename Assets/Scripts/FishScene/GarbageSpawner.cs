using UnityEngine;
using System.Collections;

public class GarbageSpawner : MonoBehaviour {

	public GameObject [] garbageprefabs;
	public GameObject[] alguaprefabs;
	public Transform camPos;
	private bool spawn=true;
	private bool decor=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if (spawn) {
				StartCoroutine(spawnGarbage());
			}
		if (decor) {
			StartCoroutine(spawnAlgua());
		}

	}

	IEnumerator spawnGarbage(){
		spawn = false;
		int randomNumber = Random.Range(0,garbageprefabs.Length);
		float randomPos = Random.Range (-2.6f, 1.5f);
		
		GameObject garbage=(GameObject)Instantiate (garbageprefabs[randomNumber],
		   new Vector3(camPos.position.x+8,randomPos,0),Quaternion.identity);
		GameObject.Destroy(garbage,20);
		yield return new WaitForSeconds(2.5f);
		spawn = true;
		
	}

	IEnumerator spawnAlgua(){
		decor = false;
		int randomNumber = Random.Range(0,alguaprefabs.Length);
		float randomPos = Random.Range (-4.5f, -3.8f);
		
		GameObject garbage=(GameObject)Instantiate (alguaprefabs[randomNumber],new Vector3(camPos.position.x+8,randomPos,0),Quaternion.identity);
		GameObject.Destroy(garbage,20);
		yield return new WaitForSeconds(3f);
		decor = true;
		
	}
}
