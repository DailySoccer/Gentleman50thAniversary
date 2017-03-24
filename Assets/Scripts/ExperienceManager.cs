using UnityEngine;

public class ExperienceManager : MonoBehaviour {

/* 
	public GameObject mainCameraContainer;
	public BlackBoxBehaviour richardBransonBlackBox;

	void Start() {
		iTween.MoveTo(mainCameraContainer, iTween.Hash(
			"path", iTweenPath.GetPath("RichardBranson_1"),
			"easetype", iTween.EaseType.linear,
			"time", 5,
			"oncomplete", "OnRichardBransonPathComplete_1",
			"oncompletetarget", gameObject));
	}

	private void OnRichardBransonPathComplete_1() {
		richardBransonBlackBox.ActivateBox(0.5f);

		iTween.MoveTo(mainCameraContainer, iTween.Hash(
			"path", iTweenPath.GetPath("RichardBranson_2"),
			"easetype", iTween.EaseType.easeOutQuad,
			"time", 2,
			"oncomplete", "OnRichardBransonPathComplete_2",
			"oncompletetarget", gameObject));
	}
	private void OnRichardBransonPathComplete_2() {
	}
*/
	/*
	private static ExperienceManager _instance;

	public GameObject cameraContainer;
	public GameObject bransonCameraContainer;

	public static ExperienceManager instance {
		get { return _instance;	}
	}

	public GameObject walls;

	// Use this for initialization
	void Awake() {
		if (_instance == null) { _instance = this; }
	}
	public void MoveIntoCoverCompleted() {
		walls.SetActive(false);
	}*/
	
}
