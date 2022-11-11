using UnityEngine;

public class MissileInstantiatorScript : MonoBehaviour {

	public GameObject[] vetorPositions;
	public GameObject[] vetorMissiles;

	private float startTimer;
	private int interval;

	private void Start() {
		startTimer = TimerScript.GetTimer();
		interval = 5;
	}

	private void FixedUpdate() {
		if (TimerScript.GetTimer() - startTimer >= interval) {
			GameObject missile = vetorMissiles[Random.Range(0, vetorMissiles.Length)];
			Instantiate(missile, vetorPositions[Random.Range(0, vetorPositions.Length)].transform.position, missile.transform.rotation);

			interval = Random.Range(6, 10);
			startTimer = TimerScript.GetTimer();
		}
	}
}