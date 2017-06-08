using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// specify string of the axis
	public string axis;

	// speed of the ball is 50 (can be changed from within Unity Editor since it is public)
	public float speed = 50;

	//FixedUpdate is called in a fixed time interval (time interval is the same as Physics of Unity)
	void FixedUpdate() {
		// get the key press input based on the axis
		float v = Input.GetAxisRaw(axis);
		// move the Paddle based on the speed and axis
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, v) * speed;
	}
}
