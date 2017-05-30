using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetryGameEvent : MonoBehaviour
{
	private GameController gameController;

	// Use this for initialization
	void Start()
	{		
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (gameController != null) {
			gameController.retryGame ();
		}
	}
}

