using UnityEngine;

public class ExperienceManager : MonoBehaviour {

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
	}
	
}
