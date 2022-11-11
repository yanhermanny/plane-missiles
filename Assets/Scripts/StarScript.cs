using UnityEngine;

public class StarScript : MonoBehaviour {

	private float startTimer;
	private int interval;

	private void Start() {
		startTimer = TimerScript.GetTimer();
		interval = 20;
	}

	private void FixedUpdate() {
		if (TimerScript.GetTimer() - startTimer >= interval) {
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