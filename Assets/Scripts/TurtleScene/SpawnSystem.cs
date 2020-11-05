using UnityEngine;
using System.Collections;

public class SpawnSystem : MonoBehaviour {

	public Transform [] nodes;
	public GameObject [] Algues;
	public GameObject [] Background;
	public GameObject garbagePrefab;
	public GameObject jellyPrefab;
	private bool spawn=true;
	private bool spawn2=true;
	private bool spawn3=true;
	private bool spawn4=true;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (spawn) {
			StartCoroutine(spawnGarbage());
			}
		if (spawn2) {
			StartCoroutine (spawnMedusa());
		}
		if (spawn3) {
			StartCoroutine (spawnAlgue());
		}
		if (spawn4) {
			StartCoroutine (spawnBackground());
		}
	}

	IEnumerator spawnGarbage(){
		spawn = false;
		int randomNumber = Random.Range(0,nodes.Length);
	
		GameObject garbage=(GameObject)Instantiate (garbagePrefab,nodes[randomNumber].position,Quaternion.identity);
		GameObject.Destroy(garbage,3);
		yield return new WaitForSeconds(1f);
		spawn = true;

	}

	IEnumerator spawnMedusa(){
		spawn2 = false;
		int randomNumber = Random.Range(0,nodes.Length);
	
		GameObject garbage=(GameObject)Instantiate (jellyPrefab,nodes[randomNumber].position,Quaternion.identity);
		GameObject.Destroy(garbage,3);
		yield return new WaitForSeconds(1f);
		spawn2 = true;
		
	}

	IEnumerator spawnAlgue(){
		spawn3 = false;
		int randomNumber = Random.Range(0,Algues.Length);
		int rotY;
		if(Random.value<0.5f)
			rotY=0;
		else
			rotY=180;
		GameObject garbage=(GameObject)Instantiate (Algues[randomNumber],new Vector3 (0,7,0),Quaternion.identity);
		garbage.transform.Rotate(new Vector3(0, rotY, 0));
		GameObject.Destroy(garbage,8);
		yield return new WaitForSeconds(1f);
		spawn3 = true;
		}

	IEnumerator spawnBackground(){
		spawn4 = false;
		int randomNumber = Random.Range(0,Background.Length);
		int rotY;
		if(Random.value<0.5f)
			rotY=0;
		else
			rotY=180;
		GameObject garbage=(GameObject)Instantiate (Background[randomNumber],new Vector3 (0,7,0),Quaternion.identity);
		garbage.transform.Rotate(new Vector3(0, rotY, 0));
		GameObject.Destroy(garbage,12);
		yield return new WaitForSeconds(1f);
		spawn4 = true;
	}
}
