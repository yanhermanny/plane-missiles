using UnityEngine;

public class StarScript : MonoBehaviour {

	private float time = 0f;

	private void FixedUpdate() {
		time += Time.deltaTime;

		if (time > 20f) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Destroy(gameObject);
			GameScript.AddPoints(10);
		}
	}
}