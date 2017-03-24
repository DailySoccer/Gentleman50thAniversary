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

	public void Start() {
        box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, 0));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0));
	}

	public void HideBox(float secs) {
		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnHidingBoxUpdated_1",
				"onupdatetarget", gameObject,
				"oncomplete", "OnHideBoxComplete_1",
				"oncompletetarget", gameObject,
				"time", secs/2,
				"delay", 0));

		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnHidingBoxUpdated_2",
				"onupdatetarget", gameObject,
				"oncomplete", "OnHideBoxComplete_2",
				"oncompletetarget", gameObject,
				"time", secs/2,
				"delay", secs/2));
	}

	private void OnHidingBoxUpdated_1(float t) {
		float dup = Mathf.Clamp01(t * 2);
		float half = Mathf.Clamp01((t - 0.5f) * 2);
        //box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(dup, dup, dup, half));
	}
	
	private void OnHidingBoxUpdated_2(float t) {
        box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
	}
	private void OnHideBoxComplete_1() {
        mainCover.SetActive(false);
		for (int i = 0; i < gentlemanCovers.Count; i++) {
			gentlemanCovers[i].SetActive(false);
		}
	}
	private void OnHideBoxComplete_2() {
        box.SetActive(false);
        door.SetActive(false);
	}

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

	public void ShowBox(float secs) {
		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnHidingBoxUpdated_2",
				"onupdatetarget", gameObject,
				"oncomplete", "OnHideBoxComplete_2",
				"oncompletetarget", gameObject,
				"time", secs/2,
				"delay", secs/2));

		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 0,
				"to", 1,
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnShowBoxUpdated_2",
				"onupdatetarget", gameObject,
				"oncomplete", "OnHideBoxComplete_2",
				"oncompletetarget", gameObject,
				"time", secs/2,
				"delay", 0));
	}

	private void OnShowingBoxUpdated_1(float t) {
        box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
	}
	private void OnShowingBoxUpdated_2(float t) {
        //box.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(0, 0, 0, t));
        door.GetComponent<Renderer>().material.SetColor("_TintColor", new Color(t, t, t, 1));
	}
	private void OnShowBoxComplete_1() {
        mainCover.SetActive(false);
		for (int i = 0; i < gentlemanCovers.Count; i++) {
			gentlemanCovers[i].SetActive(false);
		}
	}
	private void OnShowBoxComplete_2() {
        box.SetActive(false);
        door.SetActive(false);
	}

}
