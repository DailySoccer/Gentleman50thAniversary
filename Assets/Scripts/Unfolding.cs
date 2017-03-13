//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unfolding : MonoBehaviour {

	public enum UnfoldAnimation {
		Rotation
	}
	public enum UnfoldDirection {
		Top,
		Bottom,
		Right,
		Left
	}

	public GameObject baseGameObject = null;
	public SpriteList spriteList = null;

	[Header("Animation")]
	public UnfoldAnimation animationType = UnfoldAnimation.Rotation;
	public UnfoldDirection animationDirection = UnfoldDirection.Top;
	public float animationTime = 0.5f;
	public float initialDelay = 3f;
	public int height = 5;
	public bool isRandomPick = true;

	private List<SpriteRenderer> _tileList;

	void Start() {
		if (baseGameObject == null) {
			Debug.LogError("Unfolding needs a base GameObject");
			return;
		}
		if (spriteList == null) {
			Debug.LogError("Unfolding needs a SpriteList");
			return;
		}
		GenerateTiles();
		AnimateTiles();
	}
	
	private void AnimateTiles() {
		for (int i = height - 2; i >= 0; i--) {
			int delayIndex = (height - 2) - i;
			iTween.RotateAdd(_tileList[i].gameObject, iTween.Hash(
				"amount", new Vector3(-180, 0, 0),
				"easetype", iTween.EaseType.easeInOutSine,
				"time", animationTime,
				"delay", (animationTime/4) * delayIndex + initialDelay));
			iTween.ValueTo(_tileList[i].gameObject, iTween.Hash(
				"from", new Vector2(0, i),
				"to", new Vector2(1, i),
				"easetype", iTween.EaseType.linear,
         		"onupdate", "OnColorUpdated",
         		"onupdatetarget", gameObject,
				"time", animationTime/10f,
				"delay", (animationTime/4) * delayIndex + initialDelay));
		}
	}

	public void OnColorUpdated(Vector2 v) {
		SpriteRenderer img = _tileList[Mathf.FloorToInt(v.y)];
		Color c = img.color;
		c.a = v.x;
		img.color = c;
	}

	private void GenerateTiles() {
		_tileList = new List<SpriteRenderer>();
		Color c;
		List<Sprite> srcList = spriteList.spriteList;
		float topY = -1.5f + height;

		for (int i = 0; i < height; i++) {
			GameObject newImageGO = Instantiate(baseGameObject);
			_tileList.Add(newImageGO.GetComponent<SpriteRenderer>());
		}
		
		_tileList[height - 1].transform.SetParent(this.transform);
		for (int i = height - 1; i > 0; i--) {
			_tileList[i - 1].transform.SetParent(_tileList[i].transform);
		}

		for (int i = 0; i < height; i++) {
			_tileList[i].gameObject.transform.localPosition = new Vector3(0, 7.14f, 0);
			_tileList[i].gameObject.transform.localRotation = Quaternion.Euler(180.0f, 0, 0);

			int spriteIndex = (isRandomPick? Mathf.FloorToInt(Random.value * srcList.Count): i) % srcList.Count;
			_tileList[i].sprite = srcList[spriteIndex];
			c = _tileList[i].color;
			c.a = 0;
			_tileList[i].color = c;
		}
		
		
		_tileList[height - 1].transform.localPosition = new Vector3(0, -0.5f, 0);
		_tileList[height - 1].transform.localRotation = Quaternion.Euler(0.0f, 0, 0);
		c = _tileList[height - 1].color;
		c.a = 1;
		_tileList[height - 1].color = c;
	}
}
