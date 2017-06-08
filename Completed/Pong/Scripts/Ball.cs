using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// speed of the ball is 50 (can be changed from within Unity Editor since it is public)
	public float speed = 50;

	// Use this for initialization
	void Start () {
		// moves Ball to the right at the given speed
		GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
	}

	// Trigger event when another object collides with this object
	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.name == "PaddleLeft") {
			// calculate return hit direction
			float y = hitDirection (transform.position, other.transform.position, other.collider.bounds.size.y);

			// calculate direction with length of 1 (due to normalized)
			Vector2 direction = new Vector2 (1, y).normalized;

			// moves Ball according to the direction and speed
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}

		if (other.gameObject.name == "PaddleRight") {
			// calculate return hit direction
			float y = hitDirection (transform.position, other.transform.position, other.collider.bounds.size.y);

			// calculate direction with length of 1 (due to normalized)
			Vector2 direction = new Vector2 (-1, y).normalized;

			// moves Ball according to the direction and speed
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}
	}

	// calculate return hit direction
	float hitDirection(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight) {
		/*
			||	->	top of paddle		(returns 1 for ---^)	
			|| 
			||	->	middle of paddle 	(returns 0 for --->)
			||
			||	->	bottom of paddle 	(returns -1 for ---v)
		*/
		return (ballPosition.y - paddlePosition.y) / paddleHeight;
	}
}
