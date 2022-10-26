using UnityEngine;

public class SmokeTrailScript : MonoBehaviour {

	private void FixedUpdate() {

		MeshRenderer mr = this.GetComponent<MeshRenderer>();
		mr.material.color = new Color(mr.material.color.r, mr.material.color.g, mr.material.color.b, mr.material.color.a - 0.003f);

		if (mr.material.color.a <= 0) {
			Destroy(gameObject, 0f);
		}
	}
}