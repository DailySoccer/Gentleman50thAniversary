using UnityEngine;

public class Cover : MonoBehaviour {

	private CanvasGroup _alphaManager;

	public float alpha {
		get { return _alphaManager.alpha;  }
		set { _alphaManager.alpha = value; }
	}

	void Start() {
		_alphaManager = GetComponentInChildren<CanvasGroup>();
	}

}
