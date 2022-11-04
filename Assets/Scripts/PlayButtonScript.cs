using UnityEngine;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour {

	private GameObject pausedCanvas;
	private Button playButton;
	private GameObject pauseButton;

	private void Start() {
		pausedCanvas = GameObject.Find("PausedCanvas");
		pauseButton = GameObject.Find("PauseButton");

		playButton = GetComponent<Button>();
		playButton.onClick.AddListener(ButtonClick);
	}

	private void ButtonClick() {
		pausedCanvas.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}
}