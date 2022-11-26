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
	public GameObject loginPanel;

	public TextMeshProUGUI timerPointsText;
	public TextMeshProUGUI starPointsText;
	public TextMeshProUGUI bonusPointsText;
	public TextMeshProUGUI totalPointsText;
	public TMP_InputField playerNameText;

	public Button sfxButton;
	public Sprite sfxOnImage;
	public Sprite sfxOffImage;
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

		if (GameScript.isSFXOn) {
			sfxButton.image.sprite = sfxOnImage;
		} else {
			sfxButton.image.sprite = sfxOffImage;
		}

		if (GameScript.isMusicOn) {
			musicButton.image.sprite = musicOnImage;
		} else {
			musicButton.image.sprite = musicOffImage;
		}

		if (PlayerPrefs.GetString("playerName").Equals("")) {
			loginPanel.SetActive(true);
		} else {
			loginPanel.SetActive(false);
		}
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

	public void OkButtonClick() {
		if (!playerNameText.text.Equals("")) {
			PlayerPrefs.SetString("playerName", playerNameText.text);
			loginPanel.SetActive(false);
		}
	}

	public void PlayButtonClick() {
		homePanel.SetActive(false);
		pausePanel.SetActive(false);
		playerControlsPanel.SetActive(true);
		hudPanel.SetActive(true);

		GameScript.StartGame();
	}

	public void ScoresButtonClick() {
		// TODO:
	}

	public void PauseButtonClick() {
		if (!GameScript.isGameOver) {
			pausePanel.SetActive(true);
			playerControlsPanel.SetActive(false);

			GameScript.PauseGame();
		}
	}

	public void HomeButtonClick() {
		GameScript.GoHome();
	}

	public void SFXButtonClick() {
		if (GameScript.isSFXOn) {
			GameScript.MuteSFX();
			sfxButton.image.sprite = sfxOffImage;
		} else {
			GameScript.SFXOn();
			sfxButton.image.sprite = sfxOnImage;
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