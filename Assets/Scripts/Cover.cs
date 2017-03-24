using UnityEngine;

public class Cover : MonoBehaviour {
/*
	private CanvasGroup _alphaManager;
	private PointOfInterest _pointOfInterest;
	public static Cover _lastSelectedCover;
	public GameObject testObject;
	private Color initialTint;

	public float alpha {
		get { return _alphaManager.alpha;  }
		set { _alphaManager.alpha = value; }
	}

	void Start() {
		_alphaManager = GetComponentInChildren<CanvasGroup>();
		_pointOfInterest = GetComponentInChildren<PointOfInterest>();
		_pointOfInterest.OnFireAction.AddListener(OnFirePointOfInterest);
	}

	void OnFirePointOfInterest() {
		//HideStaticCover();
		//MoveIntoCover();
		//PlayRichardBransonTween();
		ModifyShader();
	}
	private void ModifyShader() {
		initialTint = testObject.GetComponent<Renderer>().material.GetColor("_TintColor");
		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.linear,
				"onupdate", "OnModifyShaderUpdated",
				"onupdatetarget", gameObject,
				"time", 3,
				"delay", 0));
	}
	private void OnModifyShaderUpdated(float t) {
        //rend.material.shader = Shader.Find("Specular");
		float st = (t-0.5f)*2;
        testObject.GetComponent<Renderer>().material.SetColor("_TintColor", initialTint * new Color(st, st, st, t*2));
	}


	private void PlayRichardBransonTween() {
		iTween.MoveTo(ExperienceManager.instance.bransonCameraContainer, iTween.Hash(
			"path", iTweenPath.GetPath("RichardBranson"),
			"easetype", iTween.EaseType.linear,
			"time", 10));
	}
	private void MoveIntoCover() {
		iTween.MoveAdd(ExperienceManager.instance.cameraContainer, iTween.Hash(
				"amount", new Vector3(0, 0, 3.5f),
				"easetype", iTween.EaseType.easeInOutQuart,
				"time", 2,
				"delay", 1,
				"space", Space.World,
				"oncomplete", "OnZoomInCoverCamComplete",
				"oncompletetarget", gameObject));
	}

	public void OnZoomInCoverCamComplete() {
		ExperienceManager.instance.MoveIntoCoverCompleted();
	}

	private void HideStaticCover() {
		iTween.ValueTo(gameObject, iTween.Hash(
				"from", 1,
				"to", 0,
				"easetype", iTween.EaseType.easeInQuad,
				"onupdate", "OnHideStaticCoverUpdated",
				"onupdatetarget", gameObject,
				"time", 1,
				"delay", 0));
	}

	private void OnHideStaticCoverUpdated(float t) {
		alpha = t;
	}
	*/
}
