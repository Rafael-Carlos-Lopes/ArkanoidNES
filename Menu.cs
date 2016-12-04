using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	[SerializeField]
	GameObject pressStartText;
	float time = 0;

	void Start()
	{
		
	}

	void Update()
	{
		time += Time.deltaTime;

		if (time >= 0.5f) 
		{
			if(pressStartText.activeInHierarchy == false)
			{
				pressStartText.SetActive(true);
			}

			else if(pressStartText.activeInHierarchy == true)
			{
				pressStartText.SetActive(false);
			}

			time = 0;
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			SceneManager.LoadScene ("Fase1");
		}
	}

	void StartTheRound()
	{
		
	}
}
