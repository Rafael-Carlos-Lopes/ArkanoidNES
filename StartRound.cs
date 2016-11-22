using UnityEngine;
using System.Collections;

public class StartRound : MonoBehaviour {

	[SerializeField]
	GameObject ball, racket, startText;

	void Start()
	{
		racket.SetActive (false);
		Invoke ("StartTheRound", 3f);
	}

	void Update()
	{
		
	}

	void StartTheRound()
	{
		ball.SetActive (true);
		//GameObject g = (GameObject)Instantiate (ball, transform.position, Quaternion.identity);
		racket.SetActive (true);
		startText.SetActive (false);
	}
}
