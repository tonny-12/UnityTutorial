using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

	// direction of Snake's movement
    private Vector2 direction;

	// keeping track of the tail
	private List<Transform> tailList = new List<Transform>();

	// flag for checking if the Snake ate Food
	private bool ate = false;

	// Snake's Tail Prefab for eating Food
	public GameObject tailPrefab;

	public Text gameOverText;
	public Text restartText;

	private bool gameOver;
	private bool restart;

	// Use this for initialization 
	void Start () {
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";

        // Snake starts moving to the right
        direction = Vector2.right;

		// Snake moves every 100ms by calling the Move() function
        InvokeRepeating("Move", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        // Snake direction changes based on pressed key and NO TURNING BACK
		if (Input.GetKey(KeyCode.RightArrow) && (direction != Vector2.left))
        {
            direction = Vector2.right;
        }
		else if (Input.GetKey(KeyCode.LeftArrow) && (direction != Vector2.right))
       	{
            direction = Vector2.left;
        }
		else if (Input.GetKey(KeyCode.UpArrow) && (direction != Vector2.down))
        {
            direction = Vector2.up;
        }
		else if (Input.GetKey(KeyCode.DownArrow) && (direction != Vector2.up))
        {
            direction = Vector2.down;
        }

		if (restart) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			}
		}
		if (gameOver) {
			restartText.text = "Press Space for Restart";
			restart = true;
		}
    }

	// Move used to move the Snake
    void Move()
    {
		// save current position of the Snake's Head
		Vector2 v = transform.position;

		// move Snake's Head one space based on the new direction (gap)
        transform.Translate(direction);

		// check if the ate flag is true
		if (ate) {
			// loads the Tail Prefab to be placed where the Snake's Head was (fills gap)
			GameObject gameObject = (GameObject)Instantiate (tailPrefab, v, Quaternion.identity);

			// adds the loaded Tail Prefab to the Tail list
			tailList.Insert (0, gameObject.transform);

			// Snake finished eating setting ate flag back to false
			ate = false;
		}
		// check if the Snake have a Tail
		else if (tailList.Count > 0) 
		{
			// move last Tail element to where the Head was
			tailList.Last ().position = v;

			// add Tail to the front of the list
			tailList.Insert (0, tailList.Last ());

			// remove Tail from the back of the list
			tailList.RemoveAt (tailList.Count - 1);
		}

    }

	// Trigger event when another object collides with this object
	void OnTriggerEnter2D(Collider2D other) 
	{	
		// checks to see if collided object has the Food tag
		if (other.CompareTag("Food"))
		{	
			// set ate flag to true
			ate = true;
			// destroy the Food
			Destroy (other.gameObject);
		}
		// game ends if collided with any other object
		else 
		{
			gameOver = true;
		}
	}
}
