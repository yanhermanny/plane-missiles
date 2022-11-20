using UnityEngine;

public class StarInstantiatorScript : MonoBehaviour {

	public GameObject[] vetorPositions;
	public GameObject star;

	private float startTimer;
	private int interval;

	private void Start() {
		startTimer = TimerScript.GetTimer();
		interval = 20;
	}

	private void Update() {
		if (!GameScript.isGameOver && (TimerScript.GetTimer() - startTimer >= interval)) {
			InstantiateStar();

			interval = Random.Range(45, 60);
			startTimer = TimerScript.GetTimer();
		}
	}

	private void InstantiateStar() {
		Instantiate(star, vetorPositions[Random.Range(0, vetorPositions.Length)].transform.position, star.transform.rotation);
	}
}