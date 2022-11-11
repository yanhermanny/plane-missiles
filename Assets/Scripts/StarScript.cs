using UnityEngine;

public class StarScript : MonoBehaviour {

	private float startTimer;
	private int interval;

	private void Start() {
		startTimer = TimerScript.GetTimer();
		interval = 20;
	}

	private void Update() {
		if (TimerScript.GetTimer() - startTimer >= interval) {
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Destroy(this.gameObject);
			GameScript.AddPoints(10);
		}
	}
}