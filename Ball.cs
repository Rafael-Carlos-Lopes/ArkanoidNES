using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	[SerializeField]
	AudioSource blockSound, racketSound, gameOverSound, winSound;
	[SerializeField]
	TextMesh PointsTxt;
	[SerializeField]
	GameObject[] vidas;
	[SerializeField]
	GameObject gameOverText, racket, winText;
	int Pontos = 0;
	int Stage = 1;
	bool perdeu = false;
	float speed = 100;
	bool lifeUp;
	Rigidbody2D rb2d;
	float delay = 0;
	bool lost = false;
	bool won = false;
	bool repeatOnce = false;

	// Use this for initialization
	void Start () 
	{
		winText.SetActive (false);
		gameOverText.SetActive (false);
		rb2d = GetComponent<Rigidbody2D> ();
		//PointsTxt.text = GameObject.FindGameObjectWithTag("Pontos");

		rb2d.velocity = Vector2.up * speed;
		//GameOverTxt.text = "";
	}

	void Update()
	{
		if (Pontos == 780) 
		{
			if(repeatOnce == false)
			{
			won = true;
			repeatOnce = true;
			rb2d.velocity = new Vector2(0,0);
			winText.SetActive(true);
			}
		}

		if (won == true) 
		{
			racket.GetComponent<Racket>().setCanMove(false);
			winSound.Play();
			Invoke("GoToMenu", 9f);
			won = false;
		}

		if (transform.position.x < -195) 
		{
			transform.position = new Vector2(-195,transform.position.y);
		}

		if (transform.position.x > 41) 
		{
			transform.position = new Vector2(41,transform.position.y);
		}
		if (lost == true) 
		{
			delay += Time.deltaTime;
			//speed = 100;
			//GetComponent<Rigidbody2D>().velocity = Vector2.up * 100;
			//gameObject.transform.position = new Vector2(-81,-67.9f);
		}

		if (delay >= 1.5f) 
		{
			speed = 100;
			GetComponent<Rigidbody2D>().velocity = Vector2.up * 100;
			gameObject.transform.position = new Vector2(-81,-67.9f);
			lost = false;
			delay = 0;
		}

		PointsTxt.text = Pontos.ToString();
//		stageTxt.text = "Stage " + Stage.ToString ();

		if (lifeUp == true) 
		{
			if (vidas [1].activeInHierarchy == false) 
			{
				vidas [1].SetActive (true);
			}

			else if (vidas [2].activeInHierarchy == false)
			{
				vidas [2].SetActive (true);	
			}

			lifeUp = false;
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
	{

		return(ballPos.x - racketPos.x) / racketWidth;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "racket")
		{
		
			racketSound.Play ();
			speed += 3;

		float x = hitFactor(transform.position,
		                    col.transform.position,
			                    col.collider.bounds.size.x);

			Vector2 dir = new Vector2(x,1).normalized;

			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}

		if (col.gameObject.tag == "Block") 
		{
			blockSound.Play ();
			speed += 3;

			Pontos += 10;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "Line") 
		{
			//speed = 100;
			//GetComponent<Rigidbody2D>().velocity = Vector2.up * 100;
			//gameObject.transform.position = new Vector2(-81,-67.9f);
		
			if(vidas[2].activeInHierarchy == true)
			{	racket.GetComponent<Racket>().setLost(true);
				lost = true;
				vidas[2].SetActive(false);
			}
		
			else if(vidas[1].activeInHierarchy == true)
			{	
				racket.GetComponent<Racket>().setLost(true);
				lost = true;
				vidas[1].SetActive(false);
			}
		
			else if(vidas[0].activeInHierarchy == true)
			{
				vidas[0].SetActive(false);
				racket.GetComponent<Racket>().setCanMove(false);
				gameOverSound.Play ();
				//Time.timeScale = 0;
				gameOverText.SetActive(true);
				Invoke("GoToMenu", 4f);
			}
		}

	}

	public void setLifeUp(bool valor)
	{
		lifeUp = valor;
	}

	public void setPontos(int valor)
	{
		Pontos += valor;
	}

	void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
	}

}


