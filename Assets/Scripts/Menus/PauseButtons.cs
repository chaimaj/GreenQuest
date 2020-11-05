using UnityEngine;
using System.Collections;

public class PauseButtons : MonoBehaviour {


	public GameObject menuPause;
	public string thisLevel;

	public bool restart;
	public bool menu;
	public bool continuer;
	
	public bool platformer;
	public bool turtle;
	public bool fish;
	public bool tree;
	public bool sort;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		if (continuer) {
			DialogOnScreen.move=true;
			menuPause.SetActive (false);
		
		}
		if (restart) {
			menuPause.SetActive (false);
			Time.timeScale = 1;


		if (turtle) {
			
			TurtleCollision.turtleFed = 0;
			TurtleTimer.timer = 0;
			ClickGarbage.maxGarbage = 0;
		} else if (fish) {
			
			ProgressionBar.end = false;
			FishTimer.timer = 0;
			CollectGarbage.collectedGarbage = 0;
		} else if (tree) {
	
			RobotBehaviour.numberOfTrees = 0;
			TreeTimer.win = false;
			TreeTimer.timer = 0;
			HoleBehaviour.plantedTrees = 0;
			
		} else if (sort) {
	
			SortTimer.timer=60;
			SortTimer.finish=false;
			CanBehaviour.combo=0;
			CanBehaviour.score=0;
		}
			else if (platformer){
				PlayerPrefs.DeleteAll();
			
			}
			Application.LoadLevel (thisLevel);


		}
		else if (menu) {
			Time.timeScale = 1;
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
		

			Application.LoadLevel ("menus");
		}

		
	}
}
