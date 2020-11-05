using UnityEngine;
using System.Collections;

public class FinishButton : MonoBehaviour {
		
	public GameObject Scoretotal;
	public GameObject scorePlat;
	public GameObject scoreTurtle;
	public GameObject scoreFish;
	public GameObject scoreTree;
	public GameObject scoreSort;
	// Update is called once per frame

	private int total;
	private int fish;
	private int turtle;
	private int tree;
	private int sort;
	private int plat;

	void Start(){
		fish = PlayerPrefs.GetInt ("ScoreFish");
		turtle = PlayerPrefs.GetInt ("ScoreTurtle");
		tree = PlayerPrefs.GetInt ("ScoreTree");
		plat = PlayerPrefs.GetInt ("Score");
	
	}
	void Update () {
	if (FinalButtons.affiche) {

			scorePlat.GetComponent<TextMesh>().text=""+plat;
			scoreFish.GetComponent<TextMesh>().text=""+fish;
			int sort=PlayerPrefs.GetInt("ScoreSort");
			scoreSort.GetComponent<TextMesh>().text=""+sort;
			scoreTree.GetComponent<TextMesh>().text=""+tree;
			scoreTurtle.GetComponent<TextMesh>().text=""+turtle;
			int total=plat+fish+sort+tree+turtle;
			Scoretotal.GetComponent<TextMesh>().text =""+total;

		
		}
	}

	void OnMouseDown(){
		Application.LoadLevel ("menus");
		PlayerPrefs.DeleteAll();
	}
}
