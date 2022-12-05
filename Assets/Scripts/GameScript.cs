using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	// Game Objects
	public GameObject player;
	public GameObject playerExplosion;

	// Animators
	public Animator bonusAlertAnimator;
	public Animator backgroundMusicAnimator;

	// Audio Components
	public AudioSource backgroundMusic;
	public AudioSource playerSFX;

	// Scripts
	public LeaderborderScript lootLockerScript;
	public CanvasScript canvasScript;

	// Points Tracker
	private int timerPoints;
	private int starPoints;
	private int bonusPoints;
	private int totalPoints;

	// Counters
	private int starsCount = 0;
	private int missilesDestroyed = 0;

	// Global Indicators
	public static bool isGameOver;
	public static bool isPaused;
	public static bool isSFXOn;
	public static bool isMusicOn;

	private void Start() {
		Time.timeScale = 1;
		isGameOver = false;
		isPaused = true;

		isSFXOn = GetPlayerPrefBool("sfxOn");
		isMusicOn = GetPlayerPrefBool("musicOn");

		if (isMusicOn) {
			StartBackgroundMusic();
		}
	}

	public void GameOver() {
		isGameOver = true;
		timerPoints = (int) TimerScript.GetTimer();
		StartCoroutine(GameOverRoutine());
	}

	public void StartGame() {
		isPaused = false;
		if (isSFXOn) {
			playerSFX.Play();
			StartCoroutine(PlayerSFXFadeIn());
		}
		Time.timeScale = 1;
	}

	public void PauseGame() {
		isPaused = true;
		if (isSFXOn) {
			playerSFX.Pause();
		}
		Time.timeScale = 0;
	}

	public void GoHome() {
		TimerScript.RestartTimer();
		SceneManager.LoadScene("GameScene");
	}

	public void AddMissilesDestroyed() {
		missilesDestroyed++;
		bonusAlertAnimator.SetTrigger("addBonus");
	}

	public void AddStar() {
		starsCount++;
		canvasScript.UpdateStarCountText(starsCount);
	}

	public void TurnOnOffBackgroundMusic() {
		if (isMusicOn) {
			StopBackgroundMusic();
			isMusicOn = false;
		} else {
			StartBackgroundMusic();
			isMusicOn = true;
		}
		SavePlayerPrefBool("musicOn", isMusicOn);
	}

	public void TurnOnOffSFX() {
		if (isSFXOn) {
			playerSFX.Pause();
			isSFXOn = false;
		} else {
			playerSFX.UnPause();
			isSFXOn = true;
		}
		SavePlayerPrefBool("sfxOn", isSFXOn);
	}

	private IEnumerator GameOverRoutine() {
		StartCoroutine(DestroyPlayer());
		CalculatePoints();
		StartCoroutine(lootLockerScript.SaveScore(totalPoints));

		yield return new WaitForSeconds(2f);
		canvasScript.ShowGameOver(timerPoints, starPoints, bonusPoints, totalPoints);
	}

	private IEnumerator DestroyPlayer() {
		Vector3 lastPosition = player.transform.position;
		Destroy(player);

		for (int i=0; i<2; i++) {
			GameObject explosion = Instantiate(playerExplosion, lastPosition, playerExplosion.transform.rotation);
			if (!isSFXOn) {
				explosion.GetComponent<AudioSource>().enabled = false;
			}
			yield return new WaitForSeconds(1.5f);
		}
	}

	private void CalculatePoints() {
		starPoints = starsCount * 10;
		bonusPoints = (int) (missilesDestroyed * 2.5f);
		totalPoints = timerPoints + starPoints + bonusPoints;
	}

	private IEnumerator PlayerSFXFadeIn() {
		while (playerSFX.volume < 0.3f) {
			playerSFX.volume += 0.01f;
			yield return new WaitForSeconds(0.1f);
		}
	}

	private void StartBackgroundMusic() {
		backgroundMusic.Play();
		backgroundMusicAnimator.SetTrigger("startBackgroundMusic");
	}

	private void StopBackgroundMusic() {
		backgroundMusic.Stop();
	}

	private void SavePlayerPrefBool(string key, bool value) {
		if (value) {
			PlayerPrefs.SetInt(key, 1);
		} else {
			PlayerPrefs.SetInt(key, 0);
		}
	}

	private bool GetPlayerPrefBool(string key) {
		if (PlayerPrefs.GetInt(key) == 1) {
			return true;
		}
		return false;
	}
}