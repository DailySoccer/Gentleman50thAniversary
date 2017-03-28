using UnityEngine;

public class ExperienceManager : MonoBehaviour {

	public Camera mainCamera;
	public GameObject mainCameraContainer;

	private Animator generalAnimator;
	public GameObject skySphere;
	public GameObject world;



	void Start() {
		generalAnimator = GetComponent<Animator>();
		generalAnimator.SetTrigger("Start");
	}


	public void HideMainCamera() {
		mainCamera.gameObject.SetActive(false);
	}

	public void ShowMainCamera() {
		mainCamera.gameObject.SetActive(true);
	}

	#region Richard Branson

	public Animator richardBransonCover;
	public Animator richardBransonBlackBox;
	public GameObject richardBransonWorldElements;
	public GameObject bransonCooperScene;

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
		richardBransonCover.SetTrigger("HideCover");
	}

	public void ActivateRichardBransonScene() {
		richardBransonWorldElements.SetActive(false);
		skySphere.SetActive(false);
		bransonCooperScene.SetActive(true);
	}

	#endregion


	#region Cooper

	public Animator cooperBlackBox;
	public GameObject cooperBlackBoxContainer;
	public GameObject cooperWorldElements;

	public void ActivateCooperBlackBox() {
		cooperBlackBoxContainer.SetActive(true);
		federerBlackBoxContainer.SetActive(true);

		cooperBlackBox.SetTrigger("ActivateBox");

		mainCamera.gameObject.SetActive(true);
	}

	/*
	public void ActivateRichardBransonCover() {
		richardBransonCover.SetTrigger("ActivateCover");
	}


	public void DeactivateRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("DeactivateBox");
	}

	public void OpenRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("OpenBox");
		richardBransonCover.SetTrigger("HideCover");
	}

	public void ActivateRichardBransonScene() {
		richardBransonWorldElements.SetActive(false);
		skySphere.SetActive(false);
		bransonCooperScene.SetActive(true);
	}
*/
	#endregion


	#region Federer

	public Animator federerBlackBox;
	public GameObject federerBlackBoxContainer;

	public void ActivateFedererBlackBox() {
		federerBlackBox.SetTrigger("ActivateBox");
	}

	/*
	public void ActivateRichardBransonCover() {
		richardBransonCover.SetTrigger("ActivateCover");
	}


	public void DeactivateRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("DeactivateBox");
	}

	public void OpenRichardBransonBlackBox() {
		richardBransonBlackBox.SetTrigger("OpenBox");
		richardBransonCover.SetTrigger("HideCover");
	}

	public void ActivateRichardBransonScene() {
		richardBransonWorldElements.SetActive(false);
		skySphere.SetActive(false);
		bransonCooperScene.SetActive(true);
	}
*/
	#endregion

}
