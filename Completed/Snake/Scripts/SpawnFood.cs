using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	// Food to spawn
	public GameObject food;

	// Walls for spawning area
	public Transform wallTop;
	public Transform wallBottom;
	public Transform wallRight;
	public Transform wallLeft;

	// Use this for initialization
	void Start () {
		// after 3 seconds, Food is spawned every 4 seconds by calling the Spawn() function
		InvokeRepeating ("Spawn", 3, 4);
	}

	// Spawning one food
	void Spawn() {
		// random x position between the left wall and right wall
		int x = (int)Random.Range(wallLeft.position.x, wallRight.position.x);
		// random y position between the left wall and right wall
		int y = (int)Random.Range(wallTop.position.y, wallBottom.position.y);

		// create food at (x,y) with a default rotation (no rotation) 
		Instantiate(food, new Vector2(x,y), Quaternion.identity);
	}
}
