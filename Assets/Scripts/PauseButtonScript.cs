using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour {

	private GameObject pausedCanvas;
	private Button pauseButton;

	private void Start() {
		pausedCanvas = GameObject.Find("PausedCanvas");
		pausedCanvas.SetActive(false);

		pauseButton = this.GetComponent<Button>();
		pauseButton.onClick.AddListener(ButtonClick);
	}

	private void ButtonClick() {
		pausedCanvas.SetActive(true);
		this.gameObject.SetActive(false);
		Time.timeScale = 0;
	}
}