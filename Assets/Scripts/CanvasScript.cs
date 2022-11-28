using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	// Panels
	public GameObject homePanel;
	public GameObject playerControlsPanel;
	public GameObject hudPanel;
	public GameObject pausePanel;
	public GameObject scoresPanel;
	public GameObject gameOverPanel;
	public GameObject loginPanel;

	// Script
	public GameScript gameScript;
	public LeaderborderScript lootLockerScript;

	// Text fields
	public TMP_InputField playerNameText;
	public TextMeshProUGUI timerPointsText;
	public TextMeshProUGUI starPointsText;
	public TextMeshProUGUI bonusPointsText;
	public TextMeshProUGUI totalPointsText;
	public TextMeshProUGUI starCountText;

	// Sound Buttons
	public Button sfxButton;
	public Button musicButton;

	// UI Images
	public Sprite sfxOnImage;
	public Sprite sfxOffImage;
	public Sprite musicOnImage;
	public Sprite musicOffImage;

    private void Start() {
		homePanel.SetActive(true);
		playerControlsPanel.SetActive(false);
		hudPanel.SetActive(false);
		pausePanel.SetActive(false);
		gameOverPanel.SetActive(false);
		scoresPanel.SetActive(false);

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

		gameScript.StartGame();
	}

	public void ScoresButtonClick() {
		scoresPanel.SetActive(true);
		StartCoroutine(lootLockerScript.LoadScores());
	}

	public void BackButtonClick() {
		lootLockerScript.ClearLeaderboard();
		scoresPanel.SetActive(false);
	}

	public void PauseButtonClick() {
		if (!GameScript.isGameOver) {
			pausePanel.SetActive(true);
			playerControlsPanel.SetActive(false);

			gameScript.PauseGame();
		}
	}

	public void HomeButtonClick() {
		gameScript.GoHome();
	}

	public void SFXButtonClick() {
		gameScript.TurnOnOffSFX();
		if (GameScript.isSFXOn) {
			sfxButton.image.sprite = sfxOnImage;
		} else {
			sfxButton.image.sprite = sfxOffImage;
		}
	}

	public void MusicButtonClick() {
		gameScript.TurnOnOffBackgroundMusic();
		if (GameScript.isMusicOn) {
			musicButton.image.sprite = musicOnImage;
		} else {
			musicButton.image.sprite = musicOffImage;
		}
	}

	public void ShowGameOver(int timerPoints, int starPoints, int bonusPoints, int totalPoints) {
        timerPointsText.text = "+" + timerPoints.ToString();
        starPointsText.text = "+" + starPoints.ToString();
        bonusPointsText.text = "+" + bonusPoints.ToString();
        totalPointsText.text = totalPoints.ToString();

		playerControlsPanel.SetActive(false);
		gameOverPanel.SetActive(true);
	}

	public void UpdateStarCountText(int value) {
		starCountText.text = string.Format("x {0:00}", value);
	}
}