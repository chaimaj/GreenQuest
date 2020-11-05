using UnityEngine;
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;

public class LoadJSON : MonoBehaviour
{	
	public static int num=0;
	public static bool winGame=false;
	public GameObject monkeyDialog;
	public GameObject fishDialog;
	public GameObject turtleDialog;
	public GameObject workerDialog;

	private GameObject dialogLayer;
	private TextAsset dialogText;
	private JsonData data;


    void Start()
    {
        //Load JSON data from Resources
		dialogText = (TextAsset) Resources.Load("dialog", typeof(TextAsset));
		data = JsonMapper.ToObject(dialogText.text);
		dialogLayer = GameObject.FindGameObjectWithTag ("dialog");
    }

	void Update(){
		if ((PlayerControl.monkey) && (num==0)){
					iTween.MoveTo (dialogLayer, Camera.main.transform.position +new Vector3 (0,-6,15),0.01f);
					ProcessDialog (data,0, monkeyDialog);
					
				}
		if ((PlayerControl.turtle) && (num==1)){
			iTween.MoveTo (dialogLayer, Camera.main.transform.position +new Vector3 (0,-6,15),0.01f);
			ProcessDialog (data,1,turtleDialog);
			
		}
		if ((PlayerControl.fish) && (num==2)){
			iTween.MoveTo (dialogLayer, Camera.main.transform.position +new Vector3 (0,-6,15),0.01f);
			ProcessDialog (data,2,fishDialog);
			
		}
		if ((PlayerControl.worker) && (num==3)){
			if (ButtonEndPlatformer.displayScores){
				iTween.MoveTo (dialogLayer, Camera.main.transform.position +new Vector3 (0,-6,15),0.01f);
			}
			winGame =true;
			ProcessDialog (data,3,workerDialog);
			
		}
	}
    //Converts a JSON string into Book objects and shows a book out of it on the screen
	private void ProcessDialog(JsonData data, int i, GameObject animal)
    {

			Dialog dialog= new Dialog();
			dialog.Replies = new List<Reply> (); 
			dialog.SetId(int.Parse(data["Dialog"][i]["id"].ToString()));
	        

			for(int j = 0; j<data["Dialog"][i]["Reply"].Count; j++)
			{   Reply temp= new Reply(); 
				temp.SetId(int.Parse(data["Dialog"][i]["Reply"][j]["id"].ToString()));
				temp.SetText(data["Dialog"][i]["Reply"][j]["text"].ToString());
				temp.SetIsPng(bool.Parse(data["Dialog"][i]["Reply"][j]["isPng"].ToString()));
				dialog.Replies.Add(temp); 
			}
		
		LoadDialog(dialog,animal);

	}

    //Finds book object in application and send the Book as parameter.
    //Currently only works with two books

 private void LoadDialog(Dialog dialog, GameObject animal)
    {
		animal.GetComponent<DialogOnScreen>().LoadDialog (dialog); 
    }

}
