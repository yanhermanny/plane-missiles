using UnityEngine;
using TMPro;
using System.Collections;

public class GameScript : MonoBehaviour {

	public TextMeshProUGUI starCountText;
	public GameObject playerExplosion;

	public static bool isGameOver;
	private static int starsCount;
	private static int missilesDestroyed;

	private int timerPoints;
	private int starsPoints;
	private int bonusPoints;
	private int totalPoints;

	private void Start() {
		isGameOver = false;
		starsCount = 0;
		missilesDestroyed = 0;
	}

	private void Update() {
		starCountText.text = string.Format("x {0:00}", starsCount);

		if (isGameOver) {
			timerPoints = (int) TimerScript.GetTimer();
			Instantiate(playerExplosion, this.transform.position, playerExplosion.transform.rotation);
			Destroy(this.gameObject, 0.2f);

			CalculatePoints();
			print("timerPoints: " + timerPoints);
			print("starPoints: " + starsPoints);
			print("bonusPoints: " + bonusPoints);
			print("totalPoints: " + totalPoints);
		}
	}

	public static void AddMissilesDestroyed() {
		missilesDestroyed++;
	}

	public static void AddStar() {
		starsCount++;
	}

	private void CalculatePoints() {
		starsPoints = starsCount * 10;
		bonusPoints = (int) (missilesDestroyed * 2.5f);
		totalPoints = timerPoints + starsPoints + bonusPoints;
	}
}