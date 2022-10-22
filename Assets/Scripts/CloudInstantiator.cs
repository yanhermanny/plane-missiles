using System.Collections.Generic;
using UnityEngine;

public class CloudInstantiator : MonoBehaviour {

	public GameObject[] vetorPositions;
	private Dictionary<string, string> borderMap = new Dictionary<string, string>();

	private void Start() {
		borderMap.Add("UpperBorder", "LowerBorder");
		borderMap.Add("LeftBorder", "RightBorder");
		borderMap.Add("LowerBorder", "UpperBorder");
		borderMap.Add("RightBorder", "LeftBorder");
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Cloud") {
			Transform borderOposto = GameObject.FindGameObjectWithTag(borderMap[this.tag]).transform;
			Transform position = borderOposto.GetChild(Random.Range(0, borderOposto.childCount));

			other.transform.position = position.position;
		}
	}
}