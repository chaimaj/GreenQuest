using UnityEngine;
using System.Collections;

public class OnScreenTree: MonoBehaviour {
	
	public GameObject gameManager;

	public GameObject garbageAffiche;
	public GameObject timeAffiche;

	public Texture2D textureTree;
	public GameObject winLayer;
	public GameObject garbageMesh;
	public GameObject timeMesh;
	public GameObject[] stars;
	public Texture2D myCursor;
	public Texture2D plantCursor;
	public Texture2D shovelCursor;

	private RobotBehaviour s1;
	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y

	void Start(){
		Screen.showCursor = false;
	}
	
	void OnGUI(){
		timeAffiche.GetComponent<TextMesh>().text=""+(int)TreeTimer.timer;
		garbageAffiche.GetComponent<TextMesh>().text= HoleBehaviour.plantedTrees.ToString();
		
		if (TreeTimer.win) {
			HoleBehaviour.normalTexture=true;
			GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);
			timeMesh.GetComponent<TextMesh>().text=""+(int)TreeTimer.timer;
			garbageMesh.GetComponent<TextMesh>().text= HoleBehaviour.plantedTrees.ToString();
			stars[0].SetActive(true);
			if (HoleBehaviour.plantedTrees>10){
				stars[1].SetActive(true);
			}
			if (HoleBehaviour.plantedTrees>20){
				stars[2].SetActive(true);
			}
			
			winLayer.SetActive(true);
			s1 = gameManager.GetComponent<RobotBehaviour>();
			s1.enabled=false;


		}

		if (HoleBehaviour.normalTexture) {
						GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);
			
				} else if (HoleBehaviour.plantTexture) {
						GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), plantCursor);
				} else {
						GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), shovelCursor);
				}
	}
}
