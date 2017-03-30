using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlesSceneManager : MonoBehaviour {


	public void GoGallery() {
		SceneManager.LoadScene ("Gallery", LoadSceneMode.Single);
	}

	public void Play() {
		SceneManager.LoadScene ("GentlemanPresentation", LoadSceneMode.Single);
	}

	public void GoToTitleScreen() {
		SceneManager.LoadScene("TitleScreenReplay", LoadSceneMode.Single);
	}
}
