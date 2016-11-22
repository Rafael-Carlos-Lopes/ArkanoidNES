using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	[SerializeField]
	GameObject ball;

	[SerializeField]
	GameObject probabilidadePowerUp;

	[SerializeField]
	GameObject PUpE, PUpP, PUpL;

	int probabilidade;

	float sortAparecer;// sorteia se ira aparecer um power up
	float sortQualAparecer;// caso apareca sorteia qual power up ira aparecer

	void OnCollisionEnter2D(Collision2D col)
	{
		sortAparecer = Random.Range (0, 100);
		probabilidade = probabilidadePowerUp.GetComponent<ProbabilidadePowerUp> ().getProbabilidade ();

		if (sortAparecer < probabilidade) {
			sortQualAparecer = Random.Range (0, 26);

			if (sortQualAparecer < 2) {
				GameObject g = (GameObject)Instantiate (PUpP, transform.position, Quaternion.identity);
			}

			if (sortQualAparecer >= 2 && sortQualAparecer <= 14) {
				GameObject g = (GameObject)Instantiate (PUpL, transform.position, Quaternion.identity);
			}

			if (sortQualAparecer > 14) {
				GameObject g = (GameObject)Instantiate (PUpE, transform.position, Quaternion.identity);
			}

			probabilidadePowerUp.GetComponent<ProbabilidadePowerUp> ().resetarProbabilidade (10);
		}

		else 
		{
			probabilidadePowerUp.GetComponent<ProbabilidadePowerUp> ().aumentarProbabilidade (5);
		}

		Destroy (gameObject);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("Laser")) 
		{
			if(ball != null)
			{
			ball.GetComponent<Ball>().setPontos(10);
			}

			sortAparecer = Random.Range (0, 100);
			probabilidade = probabilidadePowerUp.GetComponent<ProbabilidadePowerUp> ().getProbabilidade ();

			if (sortAparecer < probabilidade) {
				sortQualAparecer = Random.Range (0, 26);

				if (sortQualAparecer < 2) {
					GameObject g = (GameObject)Instantiate (PUpP, transform.position, Quaternion.identity);
				}

				if (sortQualAparecer >= 2 && sortQualAparecer <= 14) {
					GameObject g = (GameObject)Instantiate (PUpL, transform.position, Quaternion.identity);
				}

				if (sortQualAparecer > 14) {
					GameObject g = (GameObject)Instantiate (PUpE, transform.position, Quaternion.identity);
				}

				probabilidadePowerUp.GetComponent<ProbabilidadePowerUp> ().resetarProbabilidade (10);
			}

			else 
			{
				probabilidadePowerUp.GetComponent<ProbabilidadePowerUp> ().aumentarProbabilidade (5);
			}

			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
