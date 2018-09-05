using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
	private BoxCollider2D groundCollider;     
	private float groundHorizontalLength;
	// Use this for initialization
	void Awake () {
		groundCollider = GetComponent<BoxCollider2D> ();

		groundHorizontalLength = groundCollider.size.x;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < -groundHorizontalLength)
		{
			
			RepositionBackground ();
		}
	}
	private void RepositionBackground()
	{
		//This is how far to the right we will move our background object, in this case, twice its length. This will position it directly to the right of the currently visible background object.
		Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

		//Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
		transform.position = (Vector2) transform.position + groundOffSet;
	}
}
