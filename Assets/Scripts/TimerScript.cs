using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour {

	private static float timer;
	private TextMeshProUGUI timerText;

	private void Start() {
		timer = 0;
		timerText = this.GetComponent<TextMeshProUGUI>();

		StartCoroutine(CountTimer());
	}

	private IEnumerator CountTimer() {
		while (true) {
			if (!GameScript.isPaused) {
				timer += Time.deltaTime;
			}
			yield return null;
		}
	}

	private void Update() {
		if (!GameScript.isGameOver) {
			timerText.text = MontaTimerDisplay();
		}
	}

	private string MontaTimerDisplay() {
		int min = 0;
		int sec = 0;

		min = (int) (timer / 60);
		sec = (int) (timer % 60);

		return string.Format("{0:00}:{1:00}", min, sec);
	}

	public static float GetTimer() {
		return timer;
	}

	public static void RestartTimer() {
		timer = 0;
	}
}