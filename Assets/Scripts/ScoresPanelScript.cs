using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresPanelScript : MonoBehaviour {

	public GameObject rankingCardPrefab;

	private static List<RankingCard> rankingCards;
	private static bool showScores = false;

	private void Start() {
		rankingCards = new List<RankingCard>();
	}

	private void Update() {
		if (showScores) {
			foreach (RankingCard rankingCard in rankingCards) {
				InstantiateRankingCard(rankingCard);
			}
			showScores = false;
		}
	}

	private void InstantiateRankingCard(RankingCard rankingCard) {
		GameObject scrollPanel = GameObject.Find("ScrollPanel");
		GameObject rankingCardGameObject = Instantiate(rankingCardPrefab, scrollPanel.transform);

		Transform playerNameText = rankingCardGameObject.transform.Find("PlayerNameText");
		Transform scoreText = rankingCardGameObject.transform.Find("ScoreText");

		playerNameText.GetComponent<TextMeshProUGUI>().text = rankingCard.RankingPosition;
		scoreText.GetComponent<TextMeshProUGUI>().text = rankingCard.RankingScore;
	}

	public static void ShowScores(List<RankingCard> rankingCardsList) {
		rankingCards = rankingCardsList;
		showScores = true;
	}

	public static void ClearScoresList() {
		GameObject scrollPanel = GameObject.Find("ScrollPanel");

		foreach (Transform child in scrollPanel.transform) {
			Destroy(child.gameObject);
		}
	}
}

public class RankingCard {

	private int _rank { get; set; }
	private string _playerName { get; set; }
	private int _playerScore { get; set; }

	public RankingCard(int rank, string playerName, int playerScore) {
		_rank = rank;
		_playerName = playerName;
		_playerScore = playerScore;
	}

	public string RankingPosition {
		get { return $"{_rank}º {_playerName}"; }
		private set {}
	}

	public string RankingScore {
		get { return $"{_playerScore}"; }
		private set {}
	}
}