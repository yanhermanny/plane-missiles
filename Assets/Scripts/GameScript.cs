using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour {

	public TextMeshProUGUI starCountText;

	public static bool gameOver;
	private static int starsCount;
	private static int points ;

	private float gameOverTimer;

	private void Start() {
		gameOver = false;
		starsCount = 0;
		points = 0;
		gameOverTimer = 0f;
	}

	private void Update() {
		starCountText.text = string.Format("x {0:00}", starsCount);

		if (gameOver) {
			gameOverTimer = TimerScript.GetTimer();

			if (TimerScript.GetTimer() - gameOverTimer >= 3) {
				Time.timeScale = 0;
				// TODO: Tela de Game Over
			}
		}
	}

	public static void GameOver() {
		gameOver = true;
	}

	public static void AddPoints(int value) {
		points += value;
		print("Points: " + points);
	}

	public static void AddStar() {
		starsCount++;
		AddPoints(10);
	}
}