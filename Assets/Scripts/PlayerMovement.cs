using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;
	public float maxVelocityX = 3f;
	public float maxVelocityY = 5f;

	private bool grounded;
	public float flySpeed = 15f;
	public float airSpeed = .3f;

	private Rigidbody2D myBody;
	public float velocidadeX;
	public float contraVel;
	 
	private MovementController movementController;
	public Animator anim;
	public Text score;
	private int nScore = 0;
	 
	public float forcaPulo;
	public bool verifJump;
	public float tempTempo;
	public float tempoDestroyObst;
	private float altitude;
	private float valorMax;
	 

	public int tempScore;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();
		 
		movementController = GetComponent<MovementController> ();
		verifJump = false;
		valorMax = 0;
	 
	}
	

	void Update () {
		altitude = myBody.transform.position.y;
		if (altitude > valorMax) {//pegar valor da altura máxima
			valorMax = altitude;
		}

		if (valorMax >= altitude + 25) {
			Reset ();
		}


		anim.SetBool ("jump", verifJump);

		score.text = nScore.ToString (); 



		velocidadeX = myBody.velocity.x;
		var forceX = 0f;
		var forceY = 0f;

		var absX = Mathf.Abs (myBody.velocity.x);
		var absY = Mathf.Abs (myBody.velocity.y);

		if (absY < .2f) {
			grounded = true;
		} else {
			grounded = false;
		}

		if (movementController.movement.x != 0) {

			if (absX < maxVelocityX) {

				if(grounded) {
					forceX = speed * movementController.movement.x;
				} else {
					forceX = speed * movementController.movement.x * airSpeed;
				}

			}

			if(forceX > 0) {
				//transform.localScale = new Vector3(1, 1, 1);
			} else if(forceX < 0) {
				//transform.localScale = new Vector3(-1, 1, 1);
			}

			 

		} else {
			 
		}

		if (movementController.movement.y != 0) {

			if (absY < maxVelocityY) {

				forceY = flySpeed * movementController.movement.y;

				 
			}

		} else if (absY > 0) {
			 
		}

		myBody.AddForce (new Vector2(forceX, forceY));


		if (velocidadeX > 0) { //controla o avanço lateral, não deixa ir infinitamente.
			myBody.AddForce (Vector3.left * contraVel);
		} else if (velocidadeX < 0) {
			myBody.AddForce (Vector3.right * contraVel);
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
			//anim.SetBool ("jump", true);
			Destroy (coll.gameObject, tempoDestroyObst);
			 
			verifJump = true;
			Invoke ("mudarVerifJump", tempTempo);
			nScore++;

		}

	}

	public void Reset() {
		tempScore = Mathf.Max(nScore, PlayerPrefs.GetInt("score"));

		PlayerPrefs.SetInt ("score", tempScore);
		SceneManager.LoadScene ("Start");
	}

	void mudarVerifJump() {
		verifJump = false;
	}
	 
} // PlayerMovement
































































