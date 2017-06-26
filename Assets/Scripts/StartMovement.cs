using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMovement : MonoBehaviour {
 

	private Rigidbody2D myBody;
	 

 
	public Animator anim;
	  

	public float forcaPulo;
	public bool verifJump;
	public float tempTempo;
	public float tempoDestroyObst;
	 
	 
	 
	public Text textScore;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> ();

		 
		verifJump = false;

		if (!PlayerPrefs.HasKey("score")) {
			PlayerPrefs.SetInt ("score", 0);
		}
		textScore.text = PlayerPrefs.GetInt ("score").ToString ();

	}


	void Update () {
  	
		anim.SetBool ("jump", verifJump);
		 
	 
	}
	void pular() {
		  
		myBody.velocity = new Vector2 (0f, forcaPulo);
		 
	}
	void OnCollisionEnter2D(Collision2D coll) { //colição com os combustiveis.
		if (coll.gameObject.tag == "obstaculo") {
			pular ();
			  
			verifJump = true;
			Invoke ("mudarVerifJump", tempTempo);
			  
		}

	}

	public void Reset() {
		SceneManager.LoadScene ("Game");
	}

	void mudarVerifJump() {
		verifJump = false;
	}

	public void StartGame() {
		SceneManager.LoadScene ("Game");
		 

	}
	public void ExitGame() {
		Application.Quit ();
	}

} // PlayerMovement



























































