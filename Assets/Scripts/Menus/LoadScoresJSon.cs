using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;

public class LoadScoresJSon : MonoBehaviour {


	private string data;
	public GameObject[] texts;
	public GameObject[] jeux;
	public GameObject[] locks;

	private int total;


	// Use this for initialization
	void Start () {
		if (File.Exists (Application.persistentDataPath + "/MiniTree.txt")) {
						Debug.Log ("file exists");
						data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniTree.txt");
						ProcessMini (data, "MiniTree", texts [0], jeux [0], locks [0]);
				}
		if (File.Exists (Application.persistentDataPath + "/MiniTurtle.txt")) {
						Debug.Log ("file exists");
			data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniTurtle.txt");
						ProcessMini (data, "MiniTurtle", texts [1], jeux [1], locks [1]);
				}
		if (File.Exists (Application.persistentDataPath + "/MiniFish.txt")) {
						Debug.Log ("file exists");
						data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniFish.txt");
						ProcessMini (data,"MiniFish",texts[2],jeux[2],locks[2]);
				}
		if (File.Exists (Application.persistentDataPath + "/MiniSort.txt")) {
			Debug.Log ("file exists");
			data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniSort.txt");
			ProcessMini (data,"MiniSort",texts[3],jeux[3],locks[3]);
		}
		if (File.Exists (Application.persistentDataPath + "/Platformer.txt")) {
			Debug.Log ("file exists");
			data = System.IO.File.ReadAllText (Application.persistentDataPath + "/Platformer.txt");
			ProcessMiniPlat (data,"Platformer",texts[4]);
		}
		total=0;
		for (int i=0; i<5; i++) {
			int inter=int.Parse(texts[i].GetComponent<TextMesh>().text);
			total=total+inter;
		}
		texts [5].GetComponent<TextMesh> ().text = ""+total;	

	}
	
	// Update is called once per frame
	void Update () {


	}
	private void ProcessMiniPlat(string json, string nomMini, GameObject textMesh)
	{
		if (json.Contains(nomMini)){
			Debug.Log ("yeeey");
			JsonData data = JsonMapper.ToObject(json);
			MiniJeu mini = new MiniJeu();
			
			mini.SetId(int.Parse(data[nomMini]["id"].ToString()));
			mini.SetName(data[nomMini]["name"].ToString());
			mini.SetLocked(bool.Parse(data[nomMini]["locked"].ToString()));
			mini.SetScore(int.Parse(data[nomMini]["score"].ToString()));
			
			textMesh.GetComponent<TextMesh> ().text = mini.GetScore().ToString();

		}
		
		
	}

	private void ProcessMini(string json, string nomMini, GameObject textMesh, GameObject miniGame, GameObject lockIcon)
	{
		if (json.Contains(nomMini)){
			Debug.Log ("yeeey");
		JsonData data = JsonMapper.ToObject(json);
		MiniJeu mini = new MiniJeu();

		mini.SetId(int.Parse(data[nomMini]["id"].ToString()));
		mini.SetName(data[nomMini]["name"].ToString());
		mini.SetLocked(bool.Parse(data[nomMini]["locked"].ToString()));
		mini.SetScore(int.Parse(data[nomMini]["score"].ToString()));


		textMesh.GetComponent<TextMesh> ().text = mini.GetScore().ToString();
		miniGame.tag = "unlocked";
		Destroy (lockIcon);
		}
	
		
	}
}
