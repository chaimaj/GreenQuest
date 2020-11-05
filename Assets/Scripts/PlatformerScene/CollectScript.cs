using UnityEngine;
using System.Collections;

public class CollectScript: MonoBehaviour {

	public static int score=0;
	public static bool info=false;
	public static int maxPaper=0;
	public static int maxGlass=0;
	public static int maxPlastic=0;
	public static int maxMetal=0;
	public static string phrase1;
	public static string phrase2;
	public static string phrase3;

	public AudioSource collectSound;
	public GameObject[] flowers;


	void OnTriggerEnter2D(Collider2D col){
		collectSound.Play ();
		if (col.gameObject.tag == "Glass") {

			Vector3 pos = col.gameObject.transform.position;
			int randomNumber = Random.Range(0,flowers.Length);
			Instantiate (flowers[randomNumber],pos,Quaternion.identity);
			maxGlass+=1;
			if (maxGlass==1){
				info=true;
				phrase1="Bravo ! Tu viens de ramasser un déchet en verre!";
				phrase2="Ce déchet met 4000 ans pour se dégrader!";
				phrase3="Continue à ramasser pour sauver la nature";
	
			}
			score+=5;
			Destroy (col.gameObject);	
		
		}
		if (col.gameObject.tag == "Paper") {
			Vector3 pos = col.gameObject.transform.position;
			int randomNumber = Random.Range(0,flowers.Length);
			Instantiate (flowers[randomNumber],pos,Quaternion.identity);
			score+=1;
			maxPaper+=1;
			if (maxPaper==1){
				info=true;
				phrase1="Bravo ! Tu viens de ramasser un déchet en papier!";
				phrase2="Ce déchet met entre 1 à 5 mois pour se dégrader!";
				phrase3="Continue à ramasser pour sauver la nature";
				
			}
			Destroy (col.gameObject);
			Debug.Log ("Yeeey Paper");
				
		}
		if (col.gameObject.tag == "metal") {
			Vector3 pos = col.gameObject.transform.position;
			int randomNumber = Random.Range(0,flowers.Length);
			Instantiate (flowers[randomNumber],pos,Quaternion.identity);
			score+=3;
			maxMetal+=1;
			if (maxMetal==1){
				info=true;
				phrase1="Bravo ! Tu viens de ramasser un déchet en metal!";
				phrase2="Ce déchet met entre 50 et 200 ans pour se dégrader!";
				phrase3="Continue à ramasser pour sauver la nature";
				
			}
			Destroy (col.gameObject);
			Debug.Log ("Yeeey Metal");
			
		}
		if (col.gameObject.tag == "plastic") {
			Vector3 pos = col.gameObject.transform.position;
			int randomNumber = Random.Range(0,flowers.Length);
			Instantiate (flowers[randomNumber],pos,Quaternion.identity);
			score+=4;
			maxPlastic+=1;
			if (maxPlastic==1){
				info=true;
				phrase1="Bravo ! Tu viens de ramasser un déchet en plastique!";
				phrase2="Ce déchet met 400 ans pour se dégrader!";
				phrase3="Continue à ramasser pour sauver la nature";
				
			}
			Destroy (col.gameObject);
			Debug.Log ("Yeeey Plastic");
			
		}
	}

	void CollisionGarbage (Collider2D col, int maxCol, int maxscore, int points){


			Vector3 pos = col.gameObject.transform.position;
			int randomNumber = Random.Range(0,flowers.Length);
			Instantiate (flowers[randomNumber],pos,Quaternion.identity);
			maxCol+=1;
			if (maxCol==1){
				info=true;
				}
			maxscore+=points;
			Destroy (col.gameObject);	
			
	}


}
