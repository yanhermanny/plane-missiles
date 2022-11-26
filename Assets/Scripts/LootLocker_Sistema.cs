using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class LootLocker_Sistema : MonoBehaviour {

	public TextMeshProUGUI[] players;

	private string playerName;

	private static int leaderboardId = 9115;
	private int max = 5;

	private void Start() {
		// Faz Conexão
		LootLockerSDKManager.StartGuestSession((response) => {
			if (response.success) {
				Debug.Log("Conectado");
			} else {
				Debug.Log("Erro na conexão");
			}
		});
	}

	public void EnviarPlacar(int score) {
		playerName = PlayerPrefs.GetString("playerName");

		if (!playerName.Equals("")) {
			LootLockerSDKManager.SubmitScore(playerName, score, leaderboardId, (response) => {
				if (response.success) {
					Debug.Log("Enviado");
				} else {
					Debug.Log("Erro no envio");
				}
			});
		}
	}

	public void MostrarPlacar() {
		LootLockerSDKManager.GetScoreList(leaderboardId, max, (response) => {
			if (response.success) {
				LootLockerLeaderboardMember[] placares = response.items;
				for (int i = 0; i < placares.Length; i++) {
					players[i].text = placares[i].rank + " " + placares[i].member_id + " - " + placares[i].score;
				}

				if (placares.Length < max) {
					for (int i = placares.Length; i < max; i++) {
						players[i].text = (i + 1).ToString() + " 0";
					}
				}
			}
			else {
				Debug.Log("Erro na placar");
			}
		});
	}
}