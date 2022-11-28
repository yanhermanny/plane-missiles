using UnityEngine;
using LootLocker.Requests;
using System.Collections.Generic;

public class LootLockerScript : MonoBehaviour {

	private static string playerName;
	private static int leaderboardId = 9115;
	private static int max = 5;

	private void Start() {
		// Faz Conexão
		LootLockerSDKManager.StartGuestSession((response) => {
			if (response.success) {
				Debug.Log("LootLocker conectado com sucesso");
			} else {
				Debug.Log("Erro na conexão com LootLocker");
			}
		});
	}

	public static void SaveScore(int score) {
		playerName = PlayerPrefs.GetString("playerName");

		if (!playerName.Equals("")) {
			LootLockerSDKManager.SubmitScore(playerName, score, leaderboardId, (response) => {
				if (response.success) {
					Debug.Log("Placar enviado com sucesso");
				} else {
					Debug.Log("Erro ao salvar placar");
				}
			});
		}
	}

	public static List<RankingCard> LoadScores() {
		List<RankingCard> rankingCards = new List<RankingCard>();

		LootLockerSDKManager.GetScoreList(leaderboardId, max, (response) => {
			if (response.success) {
				LootLockerLeaderboardMember[] scores = response.items;

				foreach (LootLockerLeaderboardMember score in scores) {
					rankingCards.Add(new RankingCard(score.rank, score.member_id, score.score));
				}
			}
			else {
				Debug.Log("Erro ao obter placares");
			}
		});
		return rankingCards;
	}
}