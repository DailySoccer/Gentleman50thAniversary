using UnityEngine;
using UnityEngine.SceneManagement;

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
		//bransonBlackboxContainer.SetActive(false);
		bransonCooperScene.SetActive(true);
		bransonWorldElements.SetActive(false);
		skySphere.SetActive(false);
	}

	#endregion


	#region Cooper

	[Header("Cooper")]
	public Animator cooperBlackBox;
	public GameObject cooperBlackBoxContainer;
	public GameObject cooperWorldElements;

	public void ActivateCooperBlackBox() {
		bransonBlackboxContainer.SetActive(false);
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
	public GameObject federerRollsWorldElements;
	[Header("Rolls")]
	public GameObject rollsBlackBoxContainer;

	public void ActivateFedererBlackBox() {
		federerBlackBox.SetTrigger("ActivateBox");
	}

	public void ActivateFedererScene_pre() {
		federerRollsScene.SetActive(true);
	}

	public void ActivateFedererScene() {
		cooperWorldElements.SetActive(false);
		//federerBlackBoxContainer.SetActive(false);
		cooperBlackBoxContainer.SetActive(false);
		skySphere.SetActive(false);
		//mainCameraContainer.SetActive(false);
	}

	private void ActivateRollsCoverWorld() {
		federerRollsWorldElements.SetActive(true);
		skySphere.SetActive(true);
		rollsBlackBoxContainer.SetActive(true);
		mainCameraContainer.SetActive(true);
		adriaBlackBoxContainer.SetActive(true);
		//federerRollsScene.SetActive(false);

		//bransonCooperScene.SetActive(false);
	}

	private void DeactivateFedererRollsScene() {
		federerRollsScene.SetActive(false);
	}

	#endregion

	#region Federer

	[Header("Adria")]
	public Animator adriaBlackBox;
	public GameObject adriaBlackBoxContainer;
	[Header("Adria-Gardner")]
	public GameObject adriaGardnerScene;
	public GameObject adriaGardnerWorldElements;

	[Header("Gardner")]
	public GameObject gardnerBlackBoxContainer;
	public Animator gardnerBlackBox;


	public void ActivateAdriaBlackBox() {
		adriaBlackBox.SetTrigger("ActivateBox");
	}

	public void ActivateAdriaScene() {
		adriaGardnerScene.SetActive(true);
	}

	public void HideAdriaGardnerWorldElements() {
		federerRollsWorldElements.SetActive(false);
		rollsBlackBoxContainer.SetActive(false);
		adriaBlackBox.SetTrigger("ActivateBox");
		skySphere.SetActive(false);
	}

	public void ActivateGardnerBlackBox() {
		gardnerBlackBoxContainer.SetActive(true);
		mainCameraContainer.SetActive(true);
		gardnerBlackBox.SetTrigger("ActivateBox");
	}

	private void ActivateGardnerCoverWorld() {
		adriaGardnerWorldElements.SetActive(true);
		skySphere.SetActive(true);
		gardnerBlackBox.SetTrigger("DeactivateBox");
		//rollsBlackBoxContainer.SetActive(true);
		//mainCameraContainer.SetActive(true);
		//federerRollsScene.SetActive(false);

		//bransonCooperScene.SetActive(false);
	}

	/*
	public void ActivateFedererScene_pre() {
		federerRollsScene.SetActive(true);
	}

	public void ActivateFedererScene() {
		cooperWorldElements.SetActive(false);
		federerBlackBoxContainer.SetActive(false);
		cooperBlackBoxContainer.SetActive(false);
		skySphere.SetActive(false);
		mainCameraContainer.SetActive(false);
	}

	private void ActivateRollsCoverWorld() {
		federerRollsWorldElements.SetActive(true);
		skySphere.SetActive(true);
		rollsBlackBoxContainer.SetActive(true);
		mainCameraContainer.SetActive(true);
		//federerRollsScene.SetActive(false);

		//bransonCooperScene.SetActive(false);
	}
	*/

	#endregion

	public void GoToTitleScreen() {
		SceneManager.LoadScene("TitleScreenReplay", LoadSceneMode.Single);
	}
}
