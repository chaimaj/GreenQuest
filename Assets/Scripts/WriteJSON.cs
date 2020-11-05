using UnityEngine;
using System.Collections;
using LitJson;
using System.Text;
using System.IO;


public class WriteJSON : MonoBehaviour {

	public int _id;
	public string _name;
	public string nomMini;
	private bool _locked;
	private int _score;
	private StringBuilder sb;
	private JsonWriter writer;
	private bool tree = true;
	private bool turtle = true;
	private bool fish = true;
	private bool sort = true;
	private bool platformer = true;
	private bool all = true;


	void Update(){
		if ((TreeTimer.win) && (tree)){

			tree=false;
			_locked=false;
			_score=HoleBehaviour.plantedTrees;
			PlayerPrefs.SetInt("ScoreTree", _score);
			if (File.Exists (Application.persistentDataPath + "/MiniTree.txt")) {
				string data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniTree.txt");
				JsonData json = JsonMapper.ToObject(data);
				if(int.Parse(json[nomMini]["score"].ToString())<_score){
						MiniToJson();
				}
			}else{
				MiniToJson();
			}
		}
		if ((TurtleCollision.turtleFed == 5)  && (turtle)){
			turtle=false;
			_locked=false;
			_score=ClickGarbage.maxGarbage;
			PlayerPrefs.SetInt("ScoreTurtle", _score);
			if (File.Exists (Application.persistentDataPath + "/MiniTurtle.txt")) {
				string data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniTurtle.txt");
				JsonData json = JsonMapper.ToObject(data);
				if(int.Parse(json[nomMini]["score"].ToString())<_score){
					MiniToJson();
				}
			}else{
				MiniToJson();
			}
			
		}
		if ((SortTimer.finish) && (sort)){
			sort=false;
			_locked=false;
			_score=CanBehaviour.score;
			PlayerPrefs.SetInt("ScoreSort", _score);
			if (File.Exists (Application.persistentDataPath + "/MiniSort.txt")) {
				string data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniSort.txt");
				JsonData json = JsonMapper.ToObject(data);
				if(int.Parse(json[nomMini]["score"].ToString())<_score){
					MiniToJson();
				}
			}else{
				MiniToJson();
			}
			
		}

		if ((ProgressionBar.end) && (fish)){
			fish=false;
			_locked=false;
			_score=CollectGarbage.collectedGarbage;
			PlayerPrefs.SetInt("ScoreFish", _score);
			if (File.Exists (Application.persistentDataPath + "/MiniFish.txt")) {
				string data = System.IO.File.ReadAllText (Application.persistentDataPath + "/MiniFish.txt");
				JsonData json = JsonMapper.ToObject(data);
				if(int.Parse(json[nomMini]["score"].ToString())<_score){
					MiniToJson();
				}
			}else{
				MiniToJson();
			}
			
		}


	
	}
	
	public void MiniToJson(){


		StringBuilder sb = new StringBuilder();
		JsonWriter writer = new JsonWriter(sb);
		writer.WriteObjectStart();
		writer.WritePropertyName(nomMini);
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
		System.IO.File.WriteAllText(Application.persistentDataPath + "/"+nomMini+".txt", newData);
	
		}
}
