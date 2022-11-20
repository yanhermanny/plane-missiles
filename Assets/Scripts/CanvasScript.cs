using UnityEngine;

public class CanvasScript : MonoBehaviour {

	public GameObject homePanel;
	public GameObject playerControlsPanel;
	public GameObject hudPanel;
	public GameObject pausePanel;
	public GameObject scoresPanel;

    private void Start() {
		homePanel.SetActive(true);
		playerControlsPanel.SetActive(false);
		hudPanel.SetActive(false);
		pausePanel.SetActive(false);
    }

	public void StartButtonClick() {
		homePanel.SetActive(false);
		playerControlsPanel.SetActive(true);
		hudPanel.SetActive(true);

		GameScript.StartGame();
	}

	public void ScoresButtonClick() {
		// TODO:
	}

	public void PauseButtonClick() {
		pausePanel.SetActive(true);
		playerControlsPanel.SetActive(false);

		GameScript.PauseGame();
	}

	public void UnpauseButtonClick() {
		pausePanel.SetActive(false);
		playerControlsPanel.SetActive(true);

		GameScript.StartGame();
	}

	public void HomeButtonClick() {
		GameScript.GoHome();
	}
}