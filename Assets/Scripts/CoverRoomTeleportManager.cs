using UnityEngine;

public class CoverRoomTeleportManager : MonoBehaviour {

	public GameObject mainCameraContainer;
	public Camera mainCamera;

	public void TeleportToRoom(GameObject cameraPoint) {
		Vector3 displacement = cameraPoint.transform.position - mainCamera.transform.position;
		Vector3 rotation = cameraPoint.transform.rotation.eulerAngles - mainCameraContainer.transform.rotation.eulerAngles;

		transform.position += displacement;
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + rotation);
	}


}
