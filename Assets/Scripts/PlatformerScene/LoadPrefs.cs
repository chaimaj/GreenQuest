using UnityEngine;
using System.Collections;

public class LoadPrefs : MonoBehaviour {

	public GameObject player;
	public GameObject cam;
	private float posX;
	private float posY;
	// Use this for initialization
	void Awake(){
		GameObject col = GameObject.FindGameObjectWithTag ("collider");
		CollectScript.score=PlayerPrefs.GetInt("Score");
		Timer.timer=PlayerPrefs.GetInt("Time");
		CollectScript.maxGlass=PlayerPrefs.GetInt("NbGlass");
		CollectScript.maxPaper=PlayerPrefs.GetInt("NbPaper");
		CollectScript.maxPlastic=PlayerPrefs.GetInt("NbPlastic");
		CollectScript.maxMetal=PlayerPrefs.GetInt("NbMetal");
		posX = PlayerPrefs.GetFloat("XPos");
		posY = PlayerPrefs.GetFloat ("YPos");
		Debug.Log (PlayerPrefs.GetFloat ("MinPosCam"));
		if (PlayerPrefs.GetFloat ("MinPosCam")!=0) {
						CameraFollowScript.minXCam = PlayerPrefs.GetFloat ("MinPosCam");
				}
		if ((posX == 0) && (posY == 0)) {
			posX=-52.74298f;
			posY=-20.05677f;
				}
		Instantiate (player, new Vector3 (posX, posY, 0), Quaternion.identity);
		cam.transform.position = new Vector3 (posX, posY, -15);
		Vector3 pos = new Vector3(CameraFollowScript.minXCam - 11, posY, 0);
		col.transform.position = pos; 
		Debug.Log ("collider pos "+pos.x);
		LoadJSON.num = PlayerPrefs.GetInt ("NumDialog");
	}
}
