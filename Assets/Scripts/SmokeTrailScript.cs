using UnityEngine;

public class SmokeTrailScript : MonoBehaviour {

	private void FixedUpdate() {
		Destroy(gameObject, 10f);
	}
}