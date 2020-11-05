using UnityEngine;
using System.Collections;

public class Reply{

	private int id;
	private string text;
	private bool isPng;


	public int GetId(){
		return this.id;
	}

	public void SetId(int id){
				this.id = id;
		}


	public string GetText(){
		return this.text;
	}

	public void SetText(string text){
		this.text = text;
	}

	public bool GetIsPng(){
		return this.isPng;
	}
	public void SetIsPng(bool b){
		this.isPng = b;
	}

}
