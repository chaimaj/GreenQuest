using UnityEngine;
using System.Collections;

public class MiniJeu {

	private int id;
	private string name;
	private bool locked;
	private int score;

	public int GetId(){
		return this.id;
	}
	
	public void SetId(int id){
		this.id = id;
	}

	public string GetName(){
		return this.name;
	}
	
	public void SetName(string name){
		this.name = name;
	}

	public bool GetLocked(){
		return this.locked;
	}
	
	public void SetLocked(bool b){
		this.locked = b;
	}

	public int GetScore(){
		return this.score;
	}
	
	public void SetScore(int score){
		this.score = score;
	}

}
