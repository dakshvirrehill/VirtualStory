using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationLogic : MonoBehaviour {
	public GameObject educationExperience, educationUI;
	public GameObject horse;
	public GameObject tiger;
	public GameObject gorilla;
	public GameObject Tigerpos;
	public GameObject HorsePos;
	public GameObject GorillaPos;
	public GameObject StoryMode;
	public GameObject player;
	public GameObject eventSystem;
	public GameObject horseTest,tigerTest,gorillaTest;
	public GameObject[] buttonsHorse;
	public GameObject[] buttonTiger;
	public GameObject[] buttonGorilla;
	public GameObject waypointPos;
	public GameObject waypoints;
	public GameObject failureNoise;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void playTiger() {
		//tiger.SetActive (true);
		tiger.GetComponent<GvrAudioSource> ().Play ();
		//tiger.SetActive (false);
	}
	public void playHorse() {
		//horse.SetActive (true);
		horse.GetComponent<GvrAudioSource> ().Play ();
		//horse.SetActive (false);
	}
	public void playGorilla() {
		//gorilla.SetActive (true);
		gorilla.GetComponent<GvrAudioSource> ().Play ();
		//gorilla.SetActive (false);
	}
	public void startExperience() {
		waypoints.SetActive (false);
		waypointPos.SetActive(false);
		StoryMode.SetActive (false);
		tiger.SetActive (true);
		gorilla.SetActive (true);
		horse.SetActive (true);
		iTween.MoveTo(player,iTween.Hash("position",HorsePos.transform.position,"time",5f,"onstart","deactivateEventSystem","onstarttarget",gameObject,"oncomplete","activateHorseTest","oncompletetarget",gameObject));
	}
	public void deactivateEventSystem() {
		eventSystem.SetActive (false);
	}
	public void activateEventSystem() {
		eventSystem.SetActive (true);
	}
	public void activateHorseTest() {
		horseTest.SetActive (true);
		activateEventSystem ();
	}
	public void activateGorillaTest() {
		gorillaTest.SetActive(true);
		activateEventSystem ();
	}
	public void activateTigerTest() {
		tigerTest.SetActive (true);
		activateEventSystem ();
	}
	public void testButtonHorse(GameObject horseB) {
		if (horseB.GetInstanceID () == buttonsHorse [0].GetInstanceID ()) {
			failureNoise.GetComponent<GvrAudioSource> ().Play ();
		} else if (horseB.GetInstanceID () == buttonsHorse [1].GetInstanceID ()) {
			horse.GetComponent<Animator> ().SetTrigger ("active");
			horseTest.SetActive (false);
			horse.GetComponent<GvrAudioSource> ().Play ();
			//yield return new WaitForSeconds (2);
			iTween.MoveTo (player, iTween.Hash ("position", Tigerpos.transform.position, "time", 5f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "activateTigerTest", "oncompletetarget", gameObject,"delay",4));
		} else {
			failureNoise.GetComponent<GvrAudioSource> ().Play ();
		}
	}
	public void testButtonTiger(GameObject tigerB) {
		if (tigerB.GetInstanceID () == buttonTiger [0].GetInstanceID ()) {
			failureNoise.GetComponent<GvrAudioSource> ().Play ();
		} else if (tigerB.GetInstanceID () == buttonTiger [1].GetInstanceID ()) {
			failureNoise.GetComponent<GvrAudioSource> ().Play ();
		} else {
			tigerTest.SetActive (false);
			tiger.GetComponent<Animator> ().SetTrigger ("growl");
			tiger.GetComponent<GvrAudioSource> ().Play ();
			//yield return new WaitForSeconds (2);
			iTween.MoveTo (player, iTween.Hash ("position", GorillaPos.transform.position, "time", 5f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "activateGorillaTest", "oncompletetarget", gameObject,"delay",5));
		}
	}
	public void testButtonGorilla(GameObject gorillaB) {
		if (gorillaB.GetInstanceID () == buttonGorilla [0].GetInstanceID ()) {
			failureNoise.GetComponent<GvrAudioSource> ().Play ();
		} else if (gorillaB.GetInstanceID () == buttonGorilla [1].GetInstanceID ()) {
			failureNoise.GetComponent<GvrAudioSource> ().Play ();
		} else {
			gorillaTest.SetActive (false);
			gorilla.GetComponent<Animation>().Play(PlayMode.StopAll);
			gorilla.GetComponent<GvrAudioSource> ().Play ();
			//tiger.GetComponent<Animator> ().SetTrigger ("growl");
			//yield return new WaitForSeconds (2);
			iTween.MoveTo (player, iTween.Hash ("position", waypointPos.transform.position, "time", 5f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "resetExperience", "oncompletetarget", gameObject,"delay",5));
		}
	}
	public void resetExperience() {
		educationExperience.SetActive (false);
		activateEventSystem ();
		waypointPos.SetActive (true);
		waypoints.SetActive (true);
	}
}
