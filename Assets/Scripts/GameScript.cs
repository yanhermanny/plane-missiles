using UnityEngine;

public class GameScript : MonoBehaviour {

	public static bool gameOver;
	private static int points ;

	private static void Start() {
		gameOver = false;
		points = 0;
	}

	private void FixedUpdate() {
		if (gameOver) {
			// TODO: GAME OVER
		}
	}

	public static void GameOver() {
		gameOver = true;
	}

	public static void AddPoints(int value) {
		points += value;
		print("Points: " + points);
	}
}