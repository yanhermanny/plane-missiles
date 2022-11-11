using UnityEngine;

public class SmokeTrailScript : MonoBehaviour {

	private void FixedUpdate() {
		Destroy(this.gameObject, 10f);
	}
}