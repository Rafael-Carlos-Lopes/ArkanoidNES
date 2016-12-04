using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

	[SerializeField]
	AudioSource laserSound, explosion;

	Rigidbody2D rb2d;
	float speed = 150;

	[SerializeField]
	GameObject ball, laser;

	bool canShoot = false;
	bool shootCharged = true;
	float delayShoot = 0;
	bool canMove = true;
	Vector3 posLaserDireita;
	Vector3 posLaserEsquerda;

	Animator anim;

	bool lost;
	bool reviving;

	float delay;

	void Start()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		if (canMove == true)
			rb2d.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, 0);
		else if (canMove == false)
			rb2d.velocity = new Vector2 (0, 0);

		if (canShoot == true) 
		{
			if (Input.GetKeyDown (KeyCode.Space)) 
				{
				if (shootCharged == true) 
				{
					laserSound.Play ();
					GameObject g = (GameObject)Instantiate (laser, posLaserDireita, Quaternion.identity);
					GameObject g2 = (GameObject)Instantiate (laser, posLaserEsquerda, Quaternion.identity);
				}

				shootCharged = false;
			}
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
		
		if (lost == true) 
		{
			canMove = false;
			transform.localScale = new Vector2(1,1);
			canShoot  = false;
			reviving = true;
			anim.SetBool("Explosion", true);
			anim.SetBool("NormalRacket", false);
			anim.SetBool("LaserRacket", false);
			//anim.SetBool("Explosion", false);
			explosion.Play();
			lost = false;
		}

		if (reviving == true) 
		{
			delay += Time.deltaTime;
		}

		if (delay >= 1.5f) 
		{
			canMove = true;
			anim.SetBool("Explosion", false);
			anim.SetBool("NormalRacket", true);
			anim.SetBool("LaserRacket", true);
			lost = false;
			reviving = false;
			delay = 0;
		}

		Debug.Log (delay);

		if (shootCharged == false) 
		{
			delayShoot += Time.deltaTime;
		}

		if (delayShoot >= 0.1f) 
		{
			shootCharged = true;
			delayShoot = 0;
		}

		posLaserDireita = new Vector3 (transform.position.x + 7, transform.position.y + 7, transform.position.z);
		posLaserEsquerda = new Vector3 (transform.position.x - 7, transform.position.y + 7, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("PowerUpE")) {
			transform.localScale = new Vector2 (2, transform.localScale.y);
			Destroy (col.gameObject);
			canShoot = false;
			anim.SetBool ("LaserRacket", false);
			anim.SetBool ("NormalRacket", true);
		}

		else if (col.tag.Equals ("PowerUpL")) 
		{
			anim.SetBool ("LaserRacket", true);
			anim.SetBool ("NormalRacket", false);
			transform.localScale = new Vector2 (1, transform.localScale.y);
			Destroy (col.gameObject);
			canShoot = true;
		}

		else if (col.tag.Equals ("PowerUpP")) 
		{
			ball.GetComponent<Ball> ().setLifeUp (true);
			Destroy (col.gameObject);
		}
	}

	public void setLost(bool valor)
	{
		lost = valor;
	}

	public void setCanMove(bool valor)
	{
		canMove = valor;
	}
}
