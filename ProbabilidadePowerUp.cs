using UnityEngine;
using System.Collections;

public class ProbabilidadePowerUp : MonoBehaviour {

	int probabilidade = 10;

	void Start()
	{
	}

	void Update()
	{


	}

	public int getProbabilidade()
	{
		return probabilidade;
	}

	public void aumentarProbabilidade(int valor)
	{
		probabilidade += valor;
	}

	public void resetarProbabilidade(int valor)
	{
		probabilidade = valor;
	}
}
