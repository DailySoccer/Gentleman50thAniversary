using UnityEngine;

public class ExperienceManager : MonoBehaviour {

	public Camera mainCamera;

	private Animator generalAnimator;
	public GameObject skySphere;
	public GameObject world;

	public Animator richardBransonCover;
	public Animator richardBransonBlackBox;
	public GameObject bransonCooperScene;

	void Start() {
		generalAnimator = GetComponent<Animator>();
		generalAnimator.SetTrigger("Start");
	}


	public void ActivateRichardBransonCover() {
		richardBransonCover.SetTrigger("ActivateCover");
	}

	public void ActivateRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("ActivateBox");
	}

	public void DeactivateRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("DeactivateBox");
	}

	public void OpenRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("OpenBox");
		richardBransonCover.SetTrigger("HideCover");
	}

	public void ActivateRichardBransonScene() {
		world.SetActive(false);
		skySphere.SetActive(false);
		bransonCooperScene.SetActive(true);
	}

	public void HideMainCamera() {
		mainCamera.gameObject.SetActive(false);
	}



}
