using UnityEngine;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour {

	public GameObject pausedCanvas;
	public GameObject pauseButton;
	private Button playButton;

	private void Start() {
		playButton = GetComponent<Button>();
		playButton.onClick.AddListener(ButtonClick);
	}

	private void ButtonClick() {
		pausedCanvas.SetActive(false);
		pauseButton.SetActive(true);
		Time.timeScale = 1;
	}
}