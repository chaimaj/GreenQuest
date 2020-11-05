using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dialog {

	private int id;
	private List<Reply> replies;

	public int GetId(){
		return this.id;
		}
	public int Id{

		get{return id;}
		set{ id = value;}


	}

	public void SetId(int id){
		this.id = id;
	}
	public List<Reply>	 Replies
	{
		get {return replies;}
		set{ replies= new List<Reply>(value);}
	}
	public List<Reply> GetReplies () {
		return this.replies;
	}
	public void SetReplies (List<Reply> list) {
		this.replies = list;
	}

	public Dialog(){
		this.id = 0;
		this.replies = new List<Reply>();
	}
public Dialog(Dialog _dialog){
		this.id = _dialog.id;
	this.replies = new List<Reply>(_dialog.Replies);
	}}
