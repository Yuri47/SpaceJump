using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Rigidbody2D myBody;
	public float forcaPulo;
	public float Forca = 11500f;

	public float velocidadeX;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		velocidadeX = myBody.velocity.x;

		Rect Esquerda = new Rect (Screen.width / 2 - Screen.width / 2, Screen.height / 2-Screen.height / 3.3f, Screen.width / 2, Screen.height /1.2f);
		Rect Direita = new Rect (Screen.width / 2 , Screen.height / 2-Screen.height / 3.3f, Screen.width / 2, Screen.height /1.2f);
		foreach (Touch t in Input.touches) {
			Vector2 vec = t.position;
			vec.y = Screen.height - vec.y; 
			if (Esquerda.Contains (vec)) {
				//this.GetComponent<Rigidbody2D>().AddForce (-Vector2.right*Forca* Time.deltaTime*4);
				myBody.AddForce (new Vector2(-100, 0));
			}
			if (Direita.Contains (vec)) {
				//this.GetComponent<Rigidbody2D>().AddForce (Vector2.right*Forca* Time.deltaTime*4);
				myBody.AddForce (new Vector2(100, 0));
			}
		}

		if (velocidadeX > 0) { //controla o avanço lateral, não deixa ir infinitamente.
			myBody.AddForce (Vector3.left * 50);
		} else if (velocidadeX < 0) {
			myBody.AddForce (Vector3.right * 50);
		}


		//pular ();
		if (Input.GetKey ("right") || Input.GetKey ("d")  ) {
 
			myBody.AddForce (new Vector2(300, 0));
		} else if(Input.GetKey ("left") || Input.GetKey ("a")  ) {
 
			myBody.AddForce (new Vector2(-300, 0));
		}

	}
	void pular() {
		//if (Input.GetKeyDown ("up") || Input.GetKey ("w")) {
			Debug.Log ("up");
		myBody.velocity = new Vector2 (0f, forcaPulo);
			//myBody.AddForce(0, ForceMode.Impulse);

		//}
	}
	void OnCollisionEnter2D(Collision2D coll) { //colição com os combustiveis.
		if (coll.gameObject.tag == "obstaculo") {
			pular ();
			Destroy (coll.gameObject);
			}

		}

	 
	}


