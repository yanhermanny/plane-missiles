using UnityEngine;

public class SmokeTrailScript : MonoBehaviour {

	private void Update() {
		Destroy(this.gameObject, 10f);
	}
}