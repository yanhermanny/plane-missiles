using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour {

	private static int timer;
	private TextMeshProUGUI timerText;
	private string timerString;

	private void Start() {
		timer = 0;
		timerText = GetComponent<TextMeshProUGUI>();

		StartCoroutine(CountTimer());
	}

	private void FixedUpdate() {
		int min = 0;
		int sec = 0;

		min = timer / 60;
		sec = timer % 60;

		timerString = string.Format("{0:00}:{1:00}", min, sec);
		timerText.text = timerString;
	}

	public static int GetTimer() {
		return timer;
	}

	private IEnumerator CountTimer() {
		while (!GameScript.GetGameOver()) {
			timer++;
			yield return new WaitForSeconds(1);
		}
	}
}