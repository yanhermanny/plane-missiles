using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour {

	public TextMeshProUGUI starCountText;

	public static bool gameOver;
	private static int starsCount;
	private static int points ;

	private void Start() {
		gameOver = false;
		starsCount = 0;
		points = 0;
	}

	private void Update() {
		starCountText.text = string.Format("x {0:00}", starsCount);

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

	public static void AddStar() {
		starsCount++;
		AddPoints(10);
	}
}