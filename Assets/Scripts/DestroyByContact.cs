using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("Boundary"))
		{
			return;
		}

		if (other.CompareTag("Enemy"))
		{
			return;
		}

		if (explosion != null) {
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag("Player"))
		{
			if (playerExplosion != null) {
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			}

			if (gameController != null) {
				gameController.GameOver();
			}	
		}

		if (gameController != null) {
			gameController.AddScore(scoreValue);
		}	

		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
