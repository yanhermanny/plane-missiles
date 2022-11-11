using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour {

	public GameObject pausedCanvas;
	private Button pauseButton;

	private void Start() {
		pauseButton = this.GetComponent<Button>();
		pauseButton.onClick.AddListener(ButtonClick);
	}

	private void ButtonClick() {
		pausedCanvas.SetActive(true);
		this.gameObject.SetActive(false);
		Time.timeScale = 0;
	}
}