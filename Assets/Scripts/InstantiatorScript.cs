using UnityEngine;

public class InstantiatorScript : MonoBehaviour {

	public GameObject[] vetorPositions;
	public GameObject[] vetorMissiles;

	private float time = 0;

	private void FixedUpdate() {
		time += Time.deltaTime;

		if (time > Random.Range(6f, 10f)) {
			GameObject missile = vetorMissiles[Random.Range(0, vetorMissiles.Length)];
			Instantiate(missile, vetorPositions[Random.Range(0, vetorPositions.Length)].transform.position, missile.transform.rotation);

			time = 0f;
		}
	}
}