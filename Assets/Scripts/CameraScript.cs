using System.Collections;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public Transform player;

	private Vector3 distance;

	private void Start() {
		distance = transform.position - player.position;
	}

	private void Update() {
		if (player != null) {
			Vector3 position = player.position + distance;
			transform.position = position;
		}
	}
}