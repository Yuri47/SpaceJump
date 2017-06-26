using UnityEngine;
using System.Collections;

public class ControllerAnimObst : MonoBehaviour {

	public Animator anim;
	public bool verifPisou;
	public int sound;
	// Use this for initialization
	void Start () {
		verifPisou = false;
		sound = PlayerPrefs.GetInt ("sound");
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("pisou", verifPisou);
	
	}

	void OnCollisionEnter2D(Collision2D coll) { //colição com os combustiveis.
		if (coll.gameObject.tag == "Player") {
 
			//anim.SetBool ("jump", true);
			//Destroy (coll.gameObject);
			//verifJump = true;
			verifPisou = true;
			Debug.Log ("player pisou");
			if (sound == 1) {
			GetComponent<AudioSource> ().Play ();
			}
		}

	}



}
