using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppLogic : MonoBehaviour {
	public GameObject startPoint, starting;
	public GameObject startUI;
	public GameObject player;
	public GameObject playPointWayPoint;
	public GameObject informationUI;
	public GameObject eventSystem;
	public GameObject horrorUI,educationUI,animationUI,gameUI,artUI;
	public GameObject horrorExperience,educationExperience,animationExperience,gameExperience,artExperience;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (horrorUI.active == false && horrorExperience.active == false && educationUI.active == false && educationExperience.active == false && animationUI.active == false && animationExperience.active == false && gameUI.active == false && gameExperience.active == false && artUI.active == false && artExperience.active == false) {
			resetScene ();
		}
	}
	public void resetScene() {
		SceneManager.LoadScene("mainScene");
	}
	public void startExperience() {
		startUI.SetActive (false);
		informationUI.SetActive (true);
	}
	public void activateWaypoint() {
		
		starting.SetActive (false);
		playPointWayPoint.SetActive (true);
	}
	public void horrorStart() {
		horrorUI.SetActive (false);
		horrorExperience.SetActive (true);
		horrorExperience.GetComponent<GvrAudioSource> ().Play ();
	}
	public void educationStart() {
		educationUI.SetActive (false);
		educationExperience.SetActive (true);
		educationExperience.GetComponent<GvrAudioSource> ().Play ();
	}
	public void animationStart() {
		animationUI.SetActive (false);
		animationExperience.SetActive (true);
		//animationExperience.GetComponent<GvrAudioSource> ().Play ();
		animationExperience.GetComponent<animationLogic> ().startAnim ();
	}
	public void gameStart() {
		gameUI.SetActive (false);
		gameExperience.SetActive (true);
		//gameExperience.GetComponent<GvrAudioSource> ().Play ();
		gameExperience.GetComponent<animationLogic> ().startAnim ();
	}
	public void artStart() {
		artUI.SetActive (false);
		artExperience.SetActive (true);
		artExperience.GetComponent<animationLogic> ().startAnim ();
	}
}
