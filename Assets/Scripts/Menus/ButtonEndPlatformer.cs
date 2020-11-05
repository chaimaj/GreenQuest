using UnityEngine;
using System.Collections;
using LitJson;
using System.Text;
using System.IO;

public class ButtonEndPlatformer : MonoBehaviour {


	public static bool displayScores=true;
	public GameObject winLayer;
	public int _id;
	public string _name;
	private int _score;
	private bool _locked=false;
	// Use this for initialization
	void OnMouseDown(){
		_score=CollectScript.score;
		PlayerPrefs.SetInt("Score", _score);
		if (File.Exists (Application.persistentDataPath + "/Platformer.txt")) {
			string data = System.IO.File.ReadAllText (Application.persistentDataPath + "/Platformer.txt");
			JsonData json = JsonMapper.ToObject(data);
			if(int.Parse(json["Platformer"]["score"].ToString())<_score){
				MiniToJson();
			}
		}else{
			MiniToJson();
		}
		displayScores = false;
		Destroy (winLayer);
	
	}

	public void MiniToJson(){

		
		StringBuilder sb = new StringBuilder();
		JsonWriter writer = new JsonWriter(sb);
		writer.WriteObjectStart();
		writer.WritePropertyName("Platformer");
		writer.WriteObjectStart();
		writer.WritePropertyName("id");
		writer.Write(_id);
		writer.WritePropertyName("name");
		writer.Write(_name);
		writer.WritePropertyName("locked");
		writer.Write(_locked);
		writer.WritePropertyName("score");
		writer.Write(_score);
		writer.WriteObjectEnd();
		writer.WriteObjectEnd();
		
		Debug.Log(sb.ToString());
		string newData = sb.ToString ();
		System.IO.File.WriteAllText(Application.persistentDataPath + "/Platformer.txt", newData);
		
	}
}
