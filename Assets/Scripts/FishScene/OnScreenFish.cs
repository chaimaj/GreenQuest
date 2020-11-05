using UnityEngine;
using System.Collections;

public class OnScreenFish : MonoBehaviour {

	public GameObject gameManager;

	public GameObject timeAffiche;
	public GameObject garbageAffiche;


	public GameObject winLayer;

	public GameObject timeMesh;
	public GameObject garbageMesh;
	public GameObject [] stars;

	public Texture2D myCursor;
	public Texture2D catchCursor;


	private FishTimer s1;
	private ProgressionBar s2;
	private GarbageSpawner s3; 
	
	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y

	void Start(){
		Screen.showCursor = false;
	}
	
	
	void OnGUI(){
		timeAffiche.GetComponent<TextMesh>().text=""+(int)FishTimer.timer;
		garbageAffiche.GetComponent<TextMesh>().text= CollectGarbage.collectedGarbage.ToString();

		if (DragGarbage.drag) {
			GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), catchCursor);
			
		} else {
			GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);

		if (ProgressionBar.end) {
			Debug.Log ("eeend");
			timeMesh.GetComponent<TextMesh>().text=""+(int)FishTimer.timer;
			garbageMesh.GetComponent<TextMesh>().text= CollectGarbage.collectedGarbage.ToString();
			stars[0].SetActive(true);
			if (CollectGarbage.collectedGarbage>10){
				stars[1].SetActive(true);
			}
			if (CollectGarbage.collectedGarbage>20){
				stars[2].SetActive(true);
			}

			winLayer.SetActive(true);
			 s2 = gameManager.GetComponent<ProgressionBar> ();
			 s3 = gameManager.GetComponent<GarbageSpawner> ();
			s2.enabled=false;
			s3.enabled=false;
	
		}
		
	}
}
}
