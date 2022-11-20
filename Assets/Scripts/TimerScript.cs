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
			timer += 0.1f;
			yield return new WaitForSeconds(0.1f);
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

		min = (int) timer / 60;
		sec = (int) timer % 60;

		return string.Format("{0:00}:{1:00}", min, sec);
	}

	public static float GetTimer() {
		return timer;
	}
}