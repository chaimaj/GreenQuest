using UnityEngine;
using System.Collections;

public class OnScreenTurtle : MonoBehaviour {

	public GameObject gameManager;

	public GameObject garbageAffiche;
	public GameObject timeAffiche;

	public Texture2D textureGarbage;
	public GameObject winLayer;
	public GameObject garbageMesh;
	public GameObject timeMesh;
	public GameObject[] stars;

	public Texture2D myCursor;
	
	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y

	private SpawnSystem s1;

	void Start(){
		Screen.showCursor = false;
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);
		timeAffiche.GetComponent<TextMesh>().text=""+ (int)TurtleTimer.timer;
		garbageAffiche.GetComponent<TextMesh>().text= ClickGarbage.maxGarbage.ToString();

		if (TurtleCollision.turtleFed == 5) {
			timeMesh.GetComponent<TextMesh>().text=""+ (int)TurtleTimer.timer;
			garbageMesh.GetComponent<TextMesh>().text= ClickGarbage.maxGarbage.ToString();
			stars[0].SetActive(true);
			if (ClickGarbage.maxGarbage>10){
				stars[1].SetActive(true);
			}
			if (ClickGarbage.maxGarbage>20){
				stars[2].SetActive(true);
			}
			
			winLayer.SetActive(true);
			s1 = gameManager.GetComponent<SpawnSystem>();
			s1.enabled=false;
		
		}
	}
}
