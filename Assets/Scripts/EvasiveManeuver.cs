using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour
{
	public Boundary boundary;

	public float Dodge;
	public float Smoothing;
	public float Tilt;
	public Vector2 StartWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	// Use this for initialization
	void Start ()
	{
		currentSpeed = GetComponent<Rigidbody>().velocity.z;
		StartCoroutine(Evade());
	}
	
	IEnumerator Evade(){
		yield return new WaitForSeconds (Random.Range (StartWait.x, StartWait.y));

		while (true)
		{
			targetManeuver = Random.Range (1, Dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody>().velocity.x, targetManeuver, Smoothing * Time.deltaTime);
		GetComponent<Rigidbody>().velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
			);

		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody>().velocity.x * -Tilt);
	}
}

