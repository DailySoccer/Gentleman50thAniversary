using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAnchored : MonoBehaviour {

	public Vector2 anchor = Vector2.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		GetComponent<RectTransform>().anchoredPosition = anchor;
	}
}
