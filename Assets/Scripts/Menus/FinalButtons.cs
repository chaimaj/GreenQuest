using UnityEngine;
using System.Collections;

public class FinalButtons : MonoBehaviour {


	public static bool affiche=false;
	public bool restart;
	public bool menu;
	public bool continuer;

	public bool turtle;
	public bool fish;
	public bool tree;
	public bool sort;
	public string thisLevel;
	public GameObject winLayer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if (turtle) {
						PlayerPrefs.SetInt("ScoreTurtle",ClickGarbage.maxGarbage);
						TurtleCollision.turtleFed = 0;
						TurtleTimer.timer = 0;
						ClickGarbage.maxGarbage = 0;
				} else if (fish) {
						PlayerPrefs.SetInt("ScoreFish",CollectGarbage.collectedGarbage);
						ProgressionBar.end = false;
						FishTimer.timer = 0;
						CollectGarbage.collectedGarbage = 0;
				} else if (tree) {
						PlayerPrefs.SetInt("ScoreTree",HoleBehaviour.plantedTrees);
						RobotBehaviour.numberOfTrees = 0;
						TreeTimer.win = false;
						TreeTimer.timer = 0;
						HoleBehaviour.plantedTrees = 0;
			
				} else if (sort) {
						PlayerPrefs.SetInt("ScoreSort",CanBehaviour.score);
						SortTimer.timer=60;
						SortTimer.finish=false;
						CanBehaviour.combo=0;
						CanBehaviour.score=0;
				}
		if (restart) {
						winLayer.SetActive (false);
						Time.timeScale = 1;
						Application.LoadLevel (thisLevel);
				}
		else if (menu) {
						Time.timeScale = 1;
						Application.LoadLevel ("menus");
				}
		else if ((continuer) && (sort)) {
					iTween.MoveTo (Camera.main.gameObject, new Vector3 (20,0,-15), 1f);
					affiche=true;
				}
		else {
			if (PlayerPrefs.GetString("Location").Equals("FromMenu")){
				Application.LoadLevel ("menus");
			}
			else{
			Time.timeScale=1;
			Application.LoadLevel ("Scene1");
			}

				}

	}
}
