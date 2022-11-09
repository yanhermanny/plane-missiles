using UnityEngine;

public class GameScript : MonoBehaviour {

	private static bool gameOver;
	private static int points = 0;

	public static void AddPoints(int value) {
		gameOver = false;
		points += value;
		print("Points: " + points);
	}

	private void FixedUpdate() {
		if (gameOver) {
			// TODO: GAME OVER
		}
	}

	public static void GameOver() {
		gameOver = true;
	}

	public static bool GetGameOver() {
		return gameOver;
	}
}