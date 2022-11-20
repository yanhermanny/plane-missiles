using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	public GameObject player;
	public GameObject playerExplosion;
	public TextMeshProUGUI starCountText;

	public static bool isGameOver;
	public static bool isPaused;
	private static int starsCount;
	private static int missilesDestroyed;

	private int timerPoints;
	private int starPoints;
	private int bonusPoints;
	private int totalPoints;

	private void Start() {
		Time.timeScale = 1;

		isGameOver = false;
		isPaused = true;

		starsCount = 0;
		missilesDestroyed = 0;
	}

	private void Update() {
		starCountText.text = string.Format("x {0:00}", starsCount);

		if (!isGameOver) {
			timerPoints = (int) TimerScript.GetTimer();
		} else {
			if (player != null) {
				Instantiate(playerExplosion, player.transform.position, playerExplosion.transform.rotation);
				Destroy(player, 0.2f);
			}

			CalculatePoints();
			if (TimerScript.GetTimer() - timerPoints >= 2.5f) {
				CanvasScript.ShowGameOver(timerPoints, starPoints, bonusPoints, totalPoints);
			}
		}
	}

	public static void AddMissilesDestroyed() {
		missilesDestroyed++;
	}

	public static void AddStar() {
		starsCount++;
	}

	private void CalculatePoints() {
		starPoints = starsCount * 10;
		bonusPoints = (int) (missilesDestroyed * 2.5f);
		totalPoints = timerPoints + starPoints + bonusPoints;
	}

	public static void StartGame() {
		isPaused = false;
		Time.timeScale = 1;
	}

	public static void PauseGame() {
		isPaused = true;
		Time.timeScale = 0;
	}

	public static void GoHome() {
		SceneManager.LoadScene("GameScene");
	}
}