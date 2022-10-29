using UnityEngine;

public class StarInstantiatorScript : MonoBehaviour {

	public GameObject[] vetorPositions;
	public GameObject star;

	private float time = 0;

	private void FixedUpdate() {
		time += Time.deltaTime;

		if (time > Random.Range(45f, 60f)) {
			Instantiate(star, vetorPositions[Random.Range(0, vetorPositions.Length)].transform.position, star.transform.rotation);
			time = 0f;
		}
	}
}