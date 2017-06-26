using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerSound : MonoBehaviour {

	public Toggle tog;
	public bool verifTog;
	public int prefSound;

	// Use this for initialization
	void Awake () {
		tog = GetComponent<Toggle> ();
		if (!PlayerPrefs.HasKey("sound")) {
			//PlayerPrefs.SetInt ("sound", 1);
		}
		if (PlayerPrefs.GetInt ("sound") == 1) {
			tog.isOn = true;
		} else if (PlayerPrefs.GetInt ("sound") == 0) {
			tog.isOn = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		verifTog = tog.isOn;
		if (verifTog == true) {
			PlayerPrefs.SetInt ("sound", 1);
		} else if (verifTog == false) {
			PlayerPrefs.SetInt ("sound", 0);
		}
		prefSound = PlayerPrefs.GetInt ("sound");
	}

	 

}
