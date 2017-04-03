using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceToCalculator : MonoBehaviour {


	public GameObject objTo;

	void Update() {
		if (objTo != null) {
			Debug.Log(Vector3.Distance(this.transform.position, objTo.transform.position));
		}
	}
}
