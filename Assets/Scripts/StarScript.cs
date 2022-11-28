using UnityEngine;

public class StarScript : MonoBehaviour {

	// Scripts
	private GameScript gameScript;

	private float startTimer;
	private int interval;

	private void Start() {
		gameScript = GameObject.Find("GameController").GetComponent<GameScript>();
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
		Animator starAnimator = this.GetComponent<Animator>();
		starAnimator.SetTrigger("starCollected");

		if (GameScript.isSFXOn) {
			this.GetComponent<AudioSource>().Play();
		}
		gameScript.AddStar();
		Destroy(this.gameObject, 2);
	}
}