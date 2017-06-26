using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

	public Vector2 movement = new Vector2(0, 0);

	void Update () {
		movement.x = movement.y = 0f;
		Rect Esquerda = new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2-Screen.height / 3.3f, Screen.width / 2, Screen.height /1.2f);
		Rect Direita = new Rect (Screen.width / 2 , Screen.height / 2-Screen.height / 3.3f, Screen.width / 2, Screen.height /1.2f);
		foreach (Touch t in Input.touches) {
			Vector2 vec = t.position;
			vec.y = Screen.height - vec.y; 
			if (Esquerda.Contains (vec)) {
				//this.GetComponent<Rigidbody2D>().AddForce (-Vector2.right*Forca* Time.deltaTime*4);
				movement.x = -1f;
			}
			if (Direita.Contains (vec)) {
				//this.GetComponent<Rigidbody2D>().AddForce (Vector2.right*Forca* Time.deltaTime*4);
				movement.x = 1f;
			}

		}










		if (Input.GetKey ("right") || Input.GetKey ("d")) {
			movement.x = 1f;
		} else if(Input.GetKey ("left") || Input.GetKey ("a")) {
			movement.x = -1f;
		}

		if (Input.GetKey ("up") || Input.GetKey ("w")) {
			movement.y = 1f;
		} else if(Input.GetKey ("down") || Input.GetKey ("s")) {
			movement.y = -1f;
		}
	
	}

} // MovementController
