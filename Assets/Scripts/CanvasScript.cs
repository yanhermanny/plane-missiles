using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public GameObject homePanel;
	public GameObject playerControlsPanel;
	public GameObject hudPanel;
	public GameObject pausePanel;
	public GameObject scoresPanel;
	public GameObject gameOverPanel;

	public TextMeshProUGUI timerPointsText;
	public TextMeshProUGUI starPointsText;
	public TextMeshProUGUI bonusPointsText;
	public TextMeshProUGUI totalPointsText;

	public Button soundButton;
	public Sprite soundOnImage;
	public Sprite soundOffImage;
	public Button musicButton;
	public Sprite musicOnImage;
	public Sprite musicOffImage;

	private static int timerPoints;
	private static int starPoints;
	private static int bonusPoints;
	private static int totalPoints;

	private static bool showGameOver;

    private void Start() {
		homePanel.SetActive(true);
		playerControlsPanel.SetActive(false);
		hudPanel.SetActive(false);
		pausePanel.SetActive(false);
		gameOverPanel.SetActive(false);

		showGameOver = false;
    }

	public void Update() {
		if (showGameOver) {
			timerPointsText.text = "+" + timerPoints.ToString();
			starPointsText.text = "+" + starPoints.ToString();
			bonusPointsText.text = "+" + bonusPoints.ToString();
			totalPointsText.text = totalPoints.ToString();

			playerControlsPanel.SetActive(false);
			gameOverPanel.SetActive(true);
		}
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

	public void SoundButtonClick() {
		if (GameScript.isSoundOn) {
			GameScript.MuteSound();
			soundButton.image.sprite = soundOffImage;
		} else {
			GameScript.SoundOn();
			soundButton.image.sprite = soundOnImage;
		}
	}

	public void MusicButtonClick() {
		if (GameScript.isMusicOn) {
			GameScript.MuteMusic();
			musicButton.image.sprite = musicOffImage;
		} else {
			GameScript.MusicOn();
			musicButton.image.sprite = musicOnImage;
		}
	}

	public static void ShowGameOver(int timerPointsValue, int starPointsValue, int bonusPointsValue, int totalPointsValue) {
		timerPoints = timerPointsValue;
		starPoints = starPointsValue;
		bonusPoints = bonusPointsValue;
		totalPoints = totalPointsValue;

		showGameOver = true;
	}
}