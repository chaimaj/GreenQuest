using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour 
{
	public float timeToAnimate;
	public float tickTimer;
	float animTime;

	void Awake()
	{
		ResetState();
	}

	void ResetState()
	{
		animTime = 0;
		renderer.material.SetFloat("_Cutoff", 1);
	} 

	public void CallAnimation()
	{
		StartCoroutine(AnimMaterialAlpha());
	}

	IEnumerator AnimMaterialAlpha()
	{
		if(renderer.material.GetFloat("_Cutoff") >= 0 && animTime < timeToAnimate)
		{
			animTime += tickTimer;
			yield return new WaitForSeconds(tickTimer);
			renderer.material.SetFloat("_Cutoff", 1- (animTime/timeToAnimate));
		}
	}

	void FixedUpdate()
	{
		//GameObject spawner = GameObject.Find ("Spawner");
		//Score score = spawner.GetComponent<Score>();

		CallAnimation();
		if(renderer.material.GetFloat("_Cutoff") == 0)
		{
			StopCoroutine ("AnimMaterialAlpha()");
			//score.gameOver = true;
		}
	}
}
