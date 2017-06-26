using UnityEngine;
using System.Collections;

public class ObstController : MonoBehaviour {
	private PlayerMovement player;
	public GameObject obst;
	private BoxCollider2D box;
	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider2D> ();
		player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;

		box.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y - 0.7f  > obst.transform.position.y) {
			box.isTrigger = false;
		} else if (player.transform.position.y - 0.7f   < obst.transform.position.y) {
			box.isTrigger = true;
		}
	}
}
