using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HorrorLogic : MonoBehaviour {
	public GameObject door;
	public GameObject player;
	public GameObject horrorexpoint;
	public GameObject eventSystem;
	public GameObject storymode;
	public GameObject[] pages;
	public Animator vibrateBed;
	public GameObject waypoints;
	//public float turning = 10f;
	//private Quaternion ending = Quaternion.identity;
	public Animator openDoor;
	public Animator skelMover;
	public GameObject skeleton;
	public GameObject hposition;
	//public GameObject waypoint1;
	public bool doorOpenedOnce=false;
	//public GameObject key1;
	//public GameObject key2;
	public GameObject finalpos;
	public GameObject horrorui;
	//public GameObject medbox;
	public GameObject bed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//if (ending != Quaternion.identity) {
		//	door.transform.rotation = Quaternion.Slerp (door.transform.rotation, ending, turning * Time.time);
	//	}
	}
	public void openGate() {
		//Quaternion ending = Quaternion.Euler (0, -180f, 0);
		if (!doorOpenedOnce) {
			openDoor.SetTrigger ("open");
			door.GetComponent<GvrAudioSource> ().Play ();
		//	key1.SetActive (true);
		//	key2.SetActive (true);
			iTween.MoveTo (player, iTween.Hash ("position", horrorexpoint.transform.position, "time", 20f, "onstart", "deactivateEventSystem", "onstarttarget", gameObject, "oncomplete", "closeDoor", "oncompletetarget", gameObject));
			doorOpenedOnce = true;
		} else {
			
		}
	}
	public void deactivateEventSystem() {
		eventSystem.SetActive (false);
	}
	public void closeDoor() {
		eventSystem.SetActive (true);
		openDoor.SetTrigger ("close");
		openDoor.SetTrigger ("exitto");
		door.GetComponent<GvrAudioSource> ().Play ();
		storymode.SetActive (true);
		waypoints.SetActive (false);
		//Destroy(door.GetComponent ("Event Trigger"));
	}
	public void pageTurner(GameObject pagenum) {
		pagenum.SetActive (false);
		for (int i = 0; i < 5; i++) {
			if (pagenum.GetInstanceID () == pages [i].GetInstanceID ()) {
					pages [i + 1].SetActive (true);
			}
		}
	}
	public void startAnim(GameObject pagenum) {
		pagenum.SetActive (false);
		iTween.MoveTo (player, iTween.Hash("position", hposition.transform.position, "time", 5f));
		vibrateBed.SetBool ("startvib", true);
		bed.GetComponent<GvrAudioSource> ().Play ();

	}
	public void stopbedVib() {
		vibrateBed.SetBool ("startvib",false);
		bed.GetComponent<GvrAudioSource> ().Pause ();
		skeleton.SetActive (true);
		skeleton.GetComponent<GvrAudioSource> ().Play ();
		skelMover.SetBool ("moveskel",true);
		//waypoint1.SetActive (true);
		//eventSystem.SetActive (true);
	}
	public void moveToKey() {
		skeleton.GetComponent<GvrAudioSource> ().Pause ();
		iTween.MoveTo (player, iTween.Hash ("position", finalpos.transform.position, "time", 10f, "onstart", "openAndDeactivate", "onstarttarget", gameObject, "oncomplete", "closeDoorFinal", "oncompletetarget", gameObject));
	}
	public void openAndDeactivate() {
		eventSystem.SetActive (false);
		openDoor.SetTrigger ("open");
		door.GetComponent<GvrAudioSource> ().Play ();
	}
	public void closeDoorFinal() {
		openDoor.SetTrigger ("close");
		openDoor.SetTrigger ("exitto");
		door.GetComponent<GvrAudioSource> ().Play ();
		eventSystem.SetActive (true);
		waypoints.SetActive (true);
		gameObject.SetActive (false);
	}
}

