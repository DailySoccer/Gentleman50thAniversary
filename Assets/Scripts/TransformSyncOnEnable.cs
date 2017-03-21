using UnityEngine;

public class TransformSyncOnEnable : MonoBehaviour {
	
	public class StoreTransform {
		public Vector3 position;
		public Quaternion rotation;
		public Vector3 scale;
	}

	public bool syncPosition = true;
	public bool syncRotation = true;
	public bool syncScale = true;

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
	
	void OnEnable()	{
		if(syncPosition) transform.localPosition = startTransform.position + syncWith.localPosition;
		if(syncRotation) transform.localRotation = Quaternion.Euler(startTransform.rotation.eulerAngles + syncWith.localRotation.eulerAngles);
		if(syncScale)    transform.localScale    = startTransform.scale + syncWith.localScale;
	}
	
}
