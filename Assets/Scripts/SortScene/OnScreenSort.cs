using UnityEngine;
using System.Collections;

public class OnScreenSort : MonoBehaviour {

	public GameObject gameManager;

	public GameObject scoreAffiche;
	public GameObject comboAffiche;
	public GameObject timeAffiche;

	public GameObject winLayer;
	public GameObject garbageMesh;
	public GameObject[] stars;

	public Texture2D myCursor;
	public Texture2D catchCursor;

	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y

	private SpawnSort s1;

	void Start(){
		Screen.showCursor = false;
	}

	// Use this for initialization
	void OnGUI(){

		scoreAffiche.GetComponent<TextMesh>().text = ""+CanBehaviour.score;
		comboAffiche.GetComponent<TextMesh>().text = ""+CanBehaviour.combo;
		timeAffiche.GetComponent<TextMesh>().text = ""+(int)SortTimer.timer;

		if (GarbageBehaviour.drag) {
			GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), catchCursor);
			
		} else {
			GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);

		}
		
		if (SortTimer.finish) {
			garbageMesh.GetComponent<TextMesh>().text = CanBehaviour.score.ToString();
			stars[0].SetActive(true);
			if (CanBehaviour.score>10){
				stars[1].SetActive(true);
			}
			if (CanBehaviour.score>20){
				stars[2].SetActive(true);
			}
			
			winLayer.SetActive(true);
			s1 = gameManager.GetComponent<SpawnSort>();
			s1.enabled=false;
		}
		
	}
}
