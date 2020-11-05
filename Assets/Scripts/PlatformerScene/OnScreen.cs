using UnityEngine;
using System.Collections;

public class OnScreen : MonoBehaviour {

	
	public GameObject glassText;
	public GameObject paperText;
	public GameObject metalText;
	public GameObject plasticText;
	public GameObject timerText;
	public GameObject scoreText;

	public GameObject glassTextMesh;
	public GameObject paperTextMesh;
	public GameObject metalTextMesh;
	public GameObject plasticTextMesh;
	public GameObject timerTextMesh;
	public GameObject scoreTextMesh;

	public GameObject garbageWindow;
	public GameObject timerWindow;

	public GameObject infoLayer;
	public GameObject winLayer;
	public GameObject[] texts;
	public GameObject [] stars;

	public Texture2D myCursor;
	
	int cursorSizeX = 35;  // Your cursor size x
	int cursorSizeY = 35;  // Your cursor size y

	void Start(){
		Screen.showCursor = false;
	}

	void OnGUI(){
		GUI.DrawTexture (new Rect (Event.current.mousePosition.x - cursorSizeX / 2, Event.current.mousePosition.y - cursorSizeY / 2, cursorSizeX, cursorSizeY), myCursor);
		if (!LoadJSON.winGame) {
						timerText.GetComponent<TextMesh> ().text = "" + (int)Timer.timer;
						scoreText.GetComponent<TextMesh> ().text = "" + CollectScript.score;

						glassText.GetComponent<TextMesh> ().text = "" + CollectScript.maxGlass;
						paperText.GetComponent<TextMesh> ().text = "" + CollectScript.maxPaper;
						plasticText.GetComponent<TextMesh> ().text = "" + CollectScript.maxPlastic;
						metalText.GetComponent<TextMesh> ().text = "" + CollectScript.maxMetal;
				}

		if (CollectScript.info) {
			iTween.MoveTo (infoLayer, Camera.main.transform.position +new Vector3 (0,-6,15),0.01f);
			texts[0].GetComponent<TextMesh>().text=CollectScript.phrase1;
			texts[1].GetComponent<TextMesh>().text=CollectScript.phrase2;
			texts[2].GetComponent<TextMesh>().text=CollectScript.phrase3;
			CollectScript.info=false;
		
		}
		if (LoadJSON.winGame) {
			Destroy (garbageWindow);
			Destroy (timerWindow);
			if (ButtonEndPlatformer.displayScores){
				timerTextMesh.GetComponent<TextMesh>().text=""+(int)Timer.timer;
				scoreTextMesh.GetComponent<TextMesh> ().text = ""+CollectScript.score;
				glassTextMesh.GetComponent<TextMesh> ().text = ""+CollectScript.maxGlass;
				paperTextMesh.GetComponent<TextMesh> ().text = ""+CollectScript.maxPaper;
				plasticTextMesh.GetComponent<TextMesh> ().text = ""+CollectScript.maxPlastic;
				metalTextMesh.GetComponent<TextMesh> ().text = ""+CollectScript.maxMetal;
				stars[0].SetActive(true);
				if (CollectScript.score>25){
					stars[1].SetActive(true);
				}
				if (CollectScript.score>50){
					stars[2].SetActive(true);
				}

			}

			iTween.MoveTo (winLayer, Camera.main.transform.position +new Vector3 (0,1,10),1f);	

		}


		if (Timer.paused) {

		}


	}
}
