using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlesSceneManager : MonoBehaviour {

	public GameObject loadingObj;
	public List<GameObject> hideObjects;


	public void GoGallery() {
		Loading();
		SceneManager.LoadScene ("Gallery", LoadSceneMode.Single);
	}

	public void Play() {
		Loading();
		SceneManager.LoadScene ("GentlemanPresentation", LoadSceneMode.Single);
	}

	public void GoToTitleScreen() {
		SceneManager.LoadScene("TitleScreenReplay", LoadSceneMode.Single);
	}

	private void Loading() {
		//cam.transform.rotation = Quaternion.identity;
		foreach(GameObject g in hideObjects) {
			g.SetActive(false);
		}
		loadingObj.SetActive(true);
	}
}
