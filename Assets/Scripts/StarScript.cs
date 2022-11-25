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
			CollectStar();
		}
	}

	private void CollectStar() {
		if (GameScript.isSFXOn) {
			this.GetComponent<AudioSource>().Play();
		}

		Animator starAnimator = this.GetComponent<Animator>();
		starAnimator.SetTrigger("starCollected");

		GameScript.AddStar();

		Destroy(this.gameObject, 2);
	}
}