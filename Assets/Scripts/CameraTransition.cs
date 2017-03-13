using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {

	public GameObject mainCamera = null;
	public GameObject coverCameraContainer = null;
	public GameObject coverCameraRenderTexture = null;
	public GameObject coverCamera = null;
	public GameObject coverAuxItems = null;
	public GameObject coverCase = null;
	private Cover _currentCover = null;

	private List<Cover> coverList = new List<Cover>();
/*
	public GameObject reflectionCameraLeft = null;
	public GameObject reflectionCameraRight = null;
*/
	private bool _done = false;

	void Start() {
		coverList = new List<Cover>(FindObjectsOfType<Cover>());
	}

	public void GoIntoCover(Cover cover) {
		if (_done) return;
		_done = true;

		_currentCover = cover;
		HideOtherCovers();
		ZoomInCoverCam();
		/*WideCover();
		ZoomInMainCam();
		ZoomOutCoverCam();*/
	}

	private void HideOtherCovers() {
		iTween.ValueTo(_currentCover.gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.easeInQuad,
				"onupdate", "OnHideOtherCoversUpdated",
				"onupdatetarget", gameObject,
				"time", 1,
				"delay", 0));
	}

	private void OnHideOtherCoversUpdated(float t) {
		for (int i = 0; i < coverList.Count; i++) {
			if (coverList[i] != _currentCover) {
				coverList[i].alpha = t;
			}
		}
	}

	private void ZoomInCoverCam() {
		mainCamera.SetActive(false);
		coverCameraRenderTexture.SetActive(false);
		coverCamera.SetActive(true);
		coverAuxItems.SetActive(true);
		iTween.MoveAdd(coverCameraContainer, iTween.Hash(
				"amount", new Vector3(0, 0, 3.5f),
				"easetype", iTween.EaseType.easeInOutQuart,
				"time", 2,
				"delay", 1,
				"space", Space.World,
				"oncomplete", "OnZoomInCoverCamComplete",
				"oncompletetarget", gameObject));
	}

	public void OnZoomInCoverCamComplete() {
		coverCase.SetActive(false);
	}

/* 
	private void HideOtherCovers() {
		iTween.ValueTo(_currentCover.gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.easeInQuad,
				"onupdate", "OnHideOtherCoversUpdated",
				"onupdatetarget", gameObject,
				"time", 1,
				"delay", 0));
	}

	private void OnHideOtherCoversUpdated(float t) {
		for (int i = 0; i < coverList.Count; i++) {
			if (coverList[i] != _currentCover) {
				coverList[i].alpha = t;
			}
		}
	}
*/
	private void ZoomInMainCam() {
		iTween.MoveTo(mainCamera, iTween.Hash(
				"position", _currentCover.transform.position + ((mainCamera.transform.position - _currentCover.transform.position).normalized * 1.2f), //new Vector3(0, 0, 1.8f),
				"easetype", iTween.EaseType.easeInOutQuad,
				"time", 2,
				"delay", 0.5));
	}
	private void ZoomOutCoverCam() {
		iTween.MoveBy(coverCamera, iTween.Hash(
				"amount", new Vector3(0, 0, -4f),
				"easetype", iTween.EaseType.linear,
				"time", 2,
				"delay", 0.5,
				"oncomplete", "OnCompleteAnim",
				"oncompletetarget", gameObject));
		/*
		iTween.MoveBy(coverCamera, iTween.Hash(
				"amount", new Vector3(0, 0, -10f),
				"easetype", iTween.EaseType.linear,
				"time", 5,
				"delay", 2.5,
				"oncomplete", "OnCompleteAnim",
				"oncompletetarget", gameObject));
		*/
	}

	private void OnCompleteAnim() {
		Vector3 newEulerRot = coverCamera.transform.localRotation.eulerAngles + mainCamera.transform.localRotation.eulerAngles;
		coverCamera.transform.localRotation = Quaternion.Euler(newEulerRot);
		/*reflectionCameraLeft.transform.localRotation = Quaternion.Euler(newEulerRot);
		reflectionCameraRight.transform.localRotation = Quaternion.Euler(newEulerRot);*/
		coverCamera.GetComponent<Camera>().targetTexture = null;
		//coverCamera.GetComponent<Camera>().cullingMask -= 16;												
		mainCamera.SetActive(false);
		/*reflectionCameraLeft.SetActive(true);
		reflectionCameraRight.SetActive(true);*/
		mainCamera.tag = "Untagged";
		coverCamera.tag = "MainCamera";
	}

	private void WideCover() {
		iTween.ValueTo(_currentCover.gameObject, iTween.Hash(
				"from", new Vector3(0.3f, 0.4f, 0.76f),
				"to", new Vector3(0, 1, 1.96f),
				"easetype", iTween.EaseType.easeOutQuad,
				"onupdate", "OnWideCoverUpdated",
				"onupdatetarget", gameObject,
				"time", 2,
				"delay", 0.5));

		/*iTween.ValueTo(_currentCover.gameObject, iTween.Hash(
				"from", new Vector3(0, 1, 1.96f),
				"to", new Vector3(0, 1, 1.96f * 2),
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnWideCoverUpdated",
				"onupdatetarget", gameObject,
				"time", 5,
				"delay", 2.5));*/
	}

	/*private void OnWideCoverUpdated(Vector3 v) {
		_currentCover.uvRect = new Rect(v.x, 0, v.y, 1);
		_currentCover.rectTransform.sizeDelta = new Vector2 (v.z, Mathf.Max(0.98f, v.z/2));
	}*/
}
