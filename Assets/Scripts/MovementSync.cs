using UnityEngine;

public class MovementSync : MonoBehaviour {
	
	public class StoreTransform {
		public Vector3 position;
		public Quaternion rotation;
		public Vector3 scale;
	}

	public Transform syncWith;

	public StoreTransform startTransform;

	// Use this for initialization
	void Start () {
		startTransform = new StoreTransform() {
			position = transform.localPosition - syncWith.localPosition,
			rotation = Quaternion.Euler(transform.localRotation.eulerAngles - syncWith.localRotation.eulerAngles),
			scale = transform.localScale - syncWith.localScale
		};
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.localPosition = startTransform.position + syncWith.localPosition;
		transform.localRotation = Quaternion.Euler(startTransform.rotation.eulerAngles + syncWith.localRotation.eulerAngles);
		transform.localScale 	= startTransform.scale + syncWith.localScale;
	}
	
}
