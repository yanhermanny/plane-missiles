using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	public GameObject player;
	public GameObject playerExplosion;
	public TextMeshProUGUI starCountText;
	public Animator bonusAlertAnimator;

	public LootLocker_Sistema lootLockerScript;

	public static bool isGameOver;
	public static bool isPaused;
	public static bool isSFXOn;
	public static bool isMusicOn;

	private static AudioSource backgroundMusic;
	private static AudioSource playerSFX;
	private static Animator backgroundMusicAnimator;

	private static bool addBonusText;

	private static int starsCount;
	private static int missilesDestroyed;

	private int timerPoints;
	private int starPoints;
	private int bonusPoints;
	private int totalPoints;

	private static bool startPlayerSFX;
	private static bool saveScore;

	private void Start() {

		PlayerPrefs.SetString("playerName", "");
		Time.timeScale = 1;

		addBonusText = false;
		isGameOver = false;
		isPaused = true;

		isSFXOn = GetPlayerPrefBool("sfxOn");
		isMusicOn = GetPlayerPrefBool("musicOn");

		startPlayerSFX = false;
		saveScore = true;

		starsCount = 0;
		missilesDestroyed = 0;

		backgroundMusicAnimator = this.GetComponent<Animator>();
		backgroundMusic = this.GetComponent<AudioSource>();
		if (isMusicOn) {
			StartBackgroundMusic();
		}

		playerSFX = GameObject.Find("Player").GetComponent<AudioSource>();
	}

	private void Update() {
		starCountText.text = string.Format("x {0:00}", starsCount);

		if (!isGameOver) {
			timerPoints = (int) TimerScript.GetTimer();

			if (addBonusText) {
				bonusAlertAnimator.SetTrigger("addBonus");
				addBonusText = false;
			}

			if (startPlayerSFX) {
				playerSFX.Play();
				StartCoroutine(StartPlayerSFX());
			}
		} else {
			if (player != null) {
				StartCoroutine(DestroyPlayer());
			}

			CalculatePoints();
			if (saveScore) {
				lootLockerScript.EnviarPlacar(totalPoints);
				saveScore = false;
			}
			if (TimerScript.GetTimer() - timerPoints >= 2.5f) {
				CanvasScript.ShowGameOver(timerPoints, starPoints, bonusPoints, totalPoints);
			}
		}
	}

	private IEnumerator StartPlayerSFX() {
		startPlayerSFX = false;

		while (playerSFX.volume < 0.3f) {
			playerSFX.volume += 0.01f;
			yield return new WaitForSeconds(0.1f);
		}
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

	public static void AddMissilesDestroyed() {
		missilesDestroyed++;
		addBonusText = true;
	}

	public static void AddStar() {
		starsCount++;
	}

	private void CalculatePoints() {
		starPoints = starsCount * 10;
		bonusPoints = (int) (missilesDestroyed * 2.5f);
		totalPoints = timerPoints + starPoints + bonusPoints;
	}

	public static void StartGame() {
		isPaused = false;

		if (isSFXOn) {
			startPlayerSFX = true;
		}
		Time.timeScale = 1;
	}

	public static void PauseGame() {
		isPaused = true;
		playerSFX.Pause();
		Time.timeScale = 0;
	}

	public static void GoHome() {
		SceneManager.LoadScene("GameScene");
		TimerScript.RestartTimer();
	}

	public static void MuteSFX() {
		playerSFX.Pause();
		isSFXOn = false;

		SavePlayerPrefBool("sfxOn", isSFXOn);
	}

	public static void SFXOn() {
		playerSFX.UnPause();
		isSFXOn = true;

		SavePlayerPrefBool("sfxOn", isSFXOn);
	}

	public static void MuteMusic() {
		backgroundMusic.Stop();
		isMusicOn = false;

		SavePlayerPrefBool("musicOn", isMusicOn);
	}

	public static void MusicOn() {
		StartBackgroundMusic();
		isMusicOn = true;

		SavePlayerPrefBool("musicOn", isMusicOn);
	}

	private static void StartBackgroundMusic() {
		backgroundMusic.Play();
		backgroundMusicAnimator.SetTrigger("startBackgroundMusic");
	}

	private static void SavePlayerPrefBool(string key, bool value) {
		if (value) {
			PlayerPrefs.SetInt(key, 1);
		} else {
			PlayerPrefs.SetInt(key, 0);
		}
	}

	private static bool GetPlayerPrefBool(string key) {
		if (PlayerPrefs.GetInt(key) == 1) {
			return true;
		}
		return false;
	}
}