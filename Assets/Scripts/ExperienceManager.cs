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

	#region Branson
	[Header("Branson")]
	public GameObject bransonBlackboxContainer;
	public Animator bransonCover;
	public Animator bransonBlackBox;
	public GameObject bransonWorldElements;
	[Header("Branson-Cooper")]
	public GameObject bransonCooperScene;

	public void ActivateRichardBransonCover() {
		bransonCover.SetTrigger("ActivateCover");
	}

	public void ActivateRichardBransonBlackBox() {
		bransonBlackBox.SetTrigger("ActivateBox");
	}

	public void DeactivateRichardBransonBlackBox() {
		bransonBlackBox.SetTrigger("DeactivateBox");
	}

	public void OpenRichardBransonBlackBox() {
		bransonCover.SetTrigger("HideCover");
	}

	public void ActivateRichardBransonScene() {
		bransonWorldElements.SetActive(false);
		//bransonBlackboxContainer.SetActive(false);
		skySphere.SetActive(false);
		bransonCooperScene.SetActive(true);
	}

	#endregion


	#region Cooper

	[Header("Cooper")]
	public Animator cooperBlackBox;
	public GameObject cooperBlackBoxContainer;
	public GameObject cooperWorldElements;

	public void ActivateCooperBlackBox() {
		cooperBlackBoxContainer.SetActive(true);
		federerBlackBoxContainer.SetActive(true);

		cooperBlackBox.SetTrigger("ActivateBox");

		mainCamera.gameObject.SetActive(true);
	}
	public void DeactivateCooperBlackBox() {
		cooperBlackBox.SetTrigger("DeactivateBox");
		ActivateCooperCoverWorld();
	}

	private void ActivateCooperCoverWorld() {
		cooperWorldElements.SetActive(true);
		skySphere.SetActive(true);
		bransonCooperScene.SetActive(false);
	}

	#endregion


	#region Federer

	[Header("Federer")]
	public Animator federerBlackBox;
	public GameObject federerBlackBoxContainer;
	[Header("Federer-Rolls")]
	public GameObject federerRollsScene;

	public void ActivateFedererBlackBox() {
		federerBlackBox.SetTrigger("ActivateBox");
	}

	public void ActivateFedererScene_pre() {
		federerRollsScene.SetActive(true);
	}

	public void ActivateFedererScene() {
		cooperWorldElements.SetActive(false);
		federerBlackBoxContainer.SetActive(false);
		cooperBlackBoxContainer.SetActive(false);
		skySphere.SetActive(false);
	}

	#endregion

}
