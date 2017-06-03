using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationLogic : MonoBehaviour {
	public GameObject sightline;
	public GameObject sightlinepos;
	public GameObject eventSystem;
	public GameObject player;
	public GameObject waypoints;
	public GameObject waypoint;
	public GameObject animationUI,animationExperience;
	public GameObject[] soundObjects;
	public int count=0,count2=1;
	//public bool played = false;
	//public GameObject spnl1,spnl2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void startAnim() {
		waypoints.SetActive (false);
		if(animationExperience.GetComponent<GvrAudioSource>()!=null)
			animationExperience.GetComponent<GvrAudioSource> ().Play ();
		sightline.SetActive (true);
		count = 0;
		count2 = 1;
		iTween.MoveTo (player, iTween.Hash ("position", sightlinepos.transform.position, "time", 5f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "activateEventSystem", "oncompletetarget", gameObject));
	}
	public void deactivateEventSystem() {
		eventSystem.SetActive (false);
	}
	public void activateEventSystem() {
		eventSystem.SetActive (true);
	}
	public void screenshot(GameObject spnl2) {
		//this.transform.parent.gameObject.SetActive (false);
		spnl2.SetActive (true);
		if(spnl2.GetComponent<GvrAudioSource>()!=null)
			spnl2.GetComponent<GvrAudioSource> ().Play ();
		//this.transform.parent.gameObject.GetComponent<GvrAudioSource> ().Play ();
	}
	public void moveToNext(GameObject nextpos2) {
		soundObjects [count].SetActive(false);
		count++;
		soundObjects [count2].SetActive (true);
		count2++;
		//nextpos2.transform.parent.gameObject.SetActive (true);
		//this.transform.parent.gameObject.transform.parent.gameObject.SetActive (false);
		iTween.MoveTo (player, iTween.Hash ("position", nextpos2.transform.position, "time", 5f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "activateEventSystem", "oncompletetarget", gameObject));
	}
	public void finalChange() {
		soundObjects [count].SetActive(false);
		iTween.MoveTo (player, iTween.Hash ("position", waypoint.transform.position, "time", 5f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "resetExperience", "oncompletetarget", gameObject));
	}
	public void resetExperience() {
		if(animationExperience.GetComponent<GvrAudioSource>()!=null)
			animationExperience.GetComponent<GvrAudioSource> ().Pause ();
		animationExperience.SetActive (false);
		activateEventSystem ();
		waypoints.SetActive (true);
	}

}
