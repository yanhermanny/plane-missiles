using System.Collections.Generic;
using UnityEngine;

public class CloudInstantiator : MonoBehaviour {

	private Dictionary<string, string> borderMap = new Dictionary<string, string>();

	private void Start() {
		borderMap.Add("UpperBorder", "LowerBorder");
		borderMap.Add("LeftBorder", "RightBorder");
		borderMap.Add("LowerBorder", "UpperBorder");
		borderMap.Add("RightBorder", "LeftBorder");
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Cloud") {
			MoveCloudToBorder(other.transform);
		}
	}

	private void MoveCloudToBorder(Transform cloud) {
		Transform borderOposto = GameObject.Find(borderMap[this.name]).transform;
		Transform position = borderOposto.GetChild(Random.Range(0, borderOposto.childCount));

		cloud.position = position.position;
	}
}