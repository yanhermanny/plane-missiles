using UnityEngine;
using LootLocker.Requests;
using System.Collections;
using TMPro;

public class LeaderborderScript : MonoBehaviour {

	public GameObject scrollPanel;
	public GameObject rankingCardPrefab;

	private string playerName;

	private const int leaderboardId = 9115;
	private const int max = 100; //TODO: Como buscar todos os registros?

	private void Start() {
		StartCoroutine(StartConnection());
	}

	private IEnumerator StartConnection() {
		bool done = false;

		LootLockerSDKManager.StartGuestSession((response) => {
			if (response.success) {
				Debug.Log("LootLocker successfully connected");
				done = true;
			} else {
				Debug.Log("Connection to LootLocker failed");
				done = true;
			}
		});
		yield return new WaitWhile(() => done == false);
	}

	public IEnumerator SaveScore(int score) {
		playerName = PlayerPrefs.GetString("playerName");
		bool done = false;

		if (!playerName.Equals("")) {
			LootLockerSDKManager.SubmitScore(playerName, score, leaderboardId, (response) => {
				if (response.success) {
					Debug.Log("Score submitted successfully");
					done = true;
				} else {
					Debug.Log("Failed when submitting score" + response.Error);
					done = true;
				}
			});
		} else {
			Debug.Log("Player is not logged in");
			done = true;
		}
		yield return new WaitWhile(() => done == false);
	}

	public IEnumerator LoadScores() {
		bool done = false;

		LootLockerSDKManager.GetScoreList(leaderboardId, max, (response) => {
			if (response.success) {
				LootLockerLeaderboardMember[] members = response.items;

				foreach (LootLockerLeaderboardMember member in members) {
					InstantiateRankingCard(member.rank, member.member_id, member.score);
				}
				done = true;
			}
			else {
				Debug.Log("Failed when loading highscores" + response.Error);
				done = true;
			}
		});
		yield return new WaitWhile(() => done == false);
	}

	private void InstantiateRankingCard(int rank, string name, int score) {
		GameObject rankingCardTemp = Instantiate(rankingCardPrefab, scrollPanel.transform);

		Transform playerNameText = rankingCardTemp.transform.Find("PlayerNameText");
		Transform scoreText = rankingCardTemp.transform.Find("ScoreText");

		playerNameText.GetComponent<TextMeshProUGUI>().text = $"{rank}º {name}";
		scoreText.GetComponent<TextMeshProUGUI>().text = $"{score}";
	}

	public void ClearLeaderboard() {
		foreach (Transform child in scrollPanel.transform) {
			Destroy(child.gameObject);
		}
	}
}