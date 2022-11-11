using UnityEngine;

public class StarInstantiatorScript : MonoBehaviour {

	public GameObject[] vetorPositions;
	public GameObject star;

	private float startTimer;
	private int interval;

	private void Start() {
		startTimer = TimerScript.GetTimer();
		interval = 45;
	}

	private void FixedUpdate() {
		if (TimerScript.GetTimer() - startTimer >= interval) {
			Instantiate(star, vetorPositions[Random.Range(0, vetorPositions.Length)].transform.position, star.transform.rotation);

			interval = Random.Range(45, 60);
			startTimer = TimerScript.GetTimer();
		}
	}
}