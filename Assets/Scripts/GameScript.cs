using System.Collections;
using UnityEngine;

public class GameScript : MonoBehaviour {

	private static int timer;
	private static bool gameOver;
	private static int points;

	private void Start() {
		timer = 0;
		gameOver = false;
		points = 0;

		StartCoroutine(CountTimer());
	}

	private void FixedUpdate() {
		if (gameOver) {
			Time.timeScale = 0;
			points += timer;
		}
	}

	public static void AddPoints(int value) {
		points += value;
		print("Points: " + points);
	}

	public static void GameOver() {
		gameOver = true;
	}

	IEnumerator CountTimer() {
		while (true) {
			timer++;
			yield return new WaitForSeconds(1);
		}
	}

	public int getTimer() {
		return timer;
	}
}