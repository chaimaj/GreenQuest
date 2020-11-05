using UnityEngine;
using System.Collections;

public class HoleBehaviour : MonoBehaviour {

	public static int plantedTrees=0;
	public static bool plantTexture;
	public static bool normalTexture;
	public Sprite grass;
	public GameObject plantPrefab;
	public GameObject shovelPrefab;
	public GameObject treePrefab;

	GameObject plantTimer;
	private Sprite original;
	private bool plant =true;
	private bool shovel=true;

	// Use this for initialization
	void Start () {

		original =gameObject.GetComponent<SpriteRenderer>().sprite;
		StartCoroutine (PlantTimer ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (plant) {
			Destroy (plantTimer);
			Debug.Log ("plaaant");
			Instantiate (treePrefab, gameObject.transform.position + new Vector3 (0,0.7f,0), Quaternion.identity);
			plantedTrees+=1;
			Destroy (gameObject);
				} else {
			if (shovel){
				StartCoroutine (WaitToPlant());
			}
		}
	
	
	}

	void OnMouseEnter(){
		if (plant) {
			plantTexture=true;
			normalTexture=false;
				} else {
			plantTexture=false;	
			normalTexture=false;
		}
	
	}

	void OnMouseExit(){
		normalTexture=true;
	}


	IEnumerator PlantTimer(){
		plant = true;
		plantTimer=Instantiate (plantPrefab, new Vector3 (transform.position.x, transform.position.y + 0.5f, -1f), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds(2.5f);
		gameObject.GetComponent<SpriteRenderer>().sprite =grass;
		plant = false;
		Destroy (plantTimer);
	
	}
	IEnumerator WaitToPlant(){
		shovel = false;
		GameObject a=Instantiate (shovelPrefab, new Vector3 (transform.position.x, transform.position.y + 0.5f, -1f), Quaternion.identity) as GameObject;
		yield return new WaitForSeconds(2.5f);
		gameObject.GetComponent<SpriteRenderer> ().sprite = original;
		Destroy (a);
		plant = true;
		shovel = true;
		StartCoroutine (PlantTimer ());
	}
	
}
