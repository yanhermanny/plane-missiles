using UnityEngine;

public class CanvasScript : MonoBehaviour {

	public GameObject homeCanvas;
	public GameObject playerControlsCanvas;
	public GameObject hudCanvas;
	public GameObject pausedCanvas;

    private void Start() {
		homeCanvas.SetActive(true);
		playerControlsCanvas.SetActive(false);
		hudCanvas.SetActive(false);
		pausedCanvas.SetActive(false);
    }

	public void StartButtonClick() {
		homeCanvas.SetActive(false);
		playerControlsCanvas.SetActive(true);
		hudCanvas.SetActive(true);

		GameScript.StartGame();
	}

	public void ScoresButtonClick() {
		// TODO:
	}

	public void PauseButtonClick() {
		pausedCanvas.SetActive(true);
		playerControlsCanvas.SetActive(false);

		GameScript.PauseGame();
	}

	public void UnpauseButtonClick() {
		pausedCanvas.SetActive(false);
		playerControlsCanvas.SetActive(true);

		GameScript.StartGame();
	}

	public void HomeButtonClick() {
		GameScript.GoHome();
	}
}