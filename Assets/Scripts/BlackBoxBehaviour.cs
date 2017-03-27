using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoxBehaviour : MonoBehaviour {

	public GameObject box;
	public GameObject door;
	public GameObject mainCover;
	public List<GameObject> gentlemanCovers;

	public event Action OnBoxActivated;

	public void ActivateBox(float secs) {
		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 0,
				"to", 1,
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnActivatingBoxUpdated",
				"onupdatetarget", gameObject,
				"oncomplete", "OnActivateBoxComplete",
				"oncompletetarget", gameObject,
				"time", secs,
				"delay", 0));
	}

	private void OnActivatingBoxUpdated(float t) {
        box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, t));
	}
	private void OnActivateBoxComplete() {
        box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, 1));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 1));
		OnBoxActivated();
	}

}
