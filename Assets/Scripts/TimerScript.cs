using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour {

	private static float timer;
	private TextMeshProUGUI timerText;
	private string timerString;

	private void Start() {
		timer = 0;
		timerText = this.GetComponent<TextMeshProUGUI>();

		StartCoroutine(CountTimer());
	}

	private IEnumerator CountTimer() {
		while (!GameScript.gameOver) {
			timer += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void FixedUpdate() {
		timerText.text = MontaTimerDisplay();
	}

	private string MontaTimerDisplay() {
		int min = 0;
		int sec = 0;

		min = (int) timer / 60;
		sec = (int) timer % 60;

		return string.Format("{0:00}:{1:00}", min, sec);
	}

	public static float GetTimer() {
		return timer;
	}
}