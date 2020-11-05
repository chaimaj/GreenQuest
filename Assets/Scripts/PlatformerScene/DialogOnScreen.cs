using UnityEngine;
using System.Collections;

public class DialogOnScreen : MonoBehaviour
{
	public static bool move =true;
	public static string rep;

	public string levelToLoad;
	private Dialog dialog;

	private int i=0;
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	
	//Is called by LoadXML as a SendMessage
	public void LoadDialog(Dialog _dialog)
	{
		move = false;

		dialog = new Dialog(_dialog);
		Debug.Log("haaaaaaa");
		PlayerPrefs.SetString ("Location","FromGame");
		PlayerPrefs.SetInt("Score", CollectScript.score);
		PlayerPrefs.SetInt("Time",(int)Timer.timer);
		PlayerPrefs.SetInt("NbGlass", CollectScript.maxGlass);
		PlayerPrefs.SetInt("NbPaper", CollectScript.maxPaper);
		PlayerPrefs.SetInt("NbMetal", CollectScript.maxMetal);
		PlayerPrefs.SetInt("NbPlastic", CollectScript.maxPlastic);
		if (LoadJSON.num == 2) {
					PlayerPrefs.SetFloat ("XPos", 413.1272f);
					PlayerPrefs.SetFloat ("YPos", -17.15765f);
					PlayerPrefs.SetFloat ("MinPosCam", 409.4256f);
				} else {
						PlayerPrefs.SetFloat ("XPos", player.transform.position.x);
						PlayerPrefs.SetFloat ("YPos", player.transform.position.y);
						PlayerPrefs.SetFloat ("MinPosCam", transform.position.x - 3);
				}


		if (i< dialog.GetReplies().Count){
		
			rep =dialog.GetReplies()[i].GetText().ToString();
			if ((Input.GetKeyDown (KeyCode.Return)) || (DialogNewtButton.next)){
				DialogNewtButton.next=false;
				i++;		
			}

			}
		if (i == dialog.GetReplies ().Count) {
			move =true;	
			rep=null;
			LoadJSON.num+=1;
			PlayerPrefs.SetInt("NumDialog", LoadJSON.num);
			Application.LoadLevel(levelToLoad);

		}
	}


	
}
