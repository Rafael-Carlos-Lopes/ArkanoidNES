using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		transform.eulerAngles = new Vector3 (0, 0, 45);
	}

	void Update()
	{
		rb2d.velocity = new Vector2 (0, 100);
	}
}
