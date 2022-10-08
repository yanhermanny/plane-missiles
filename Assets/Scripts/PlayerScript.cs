using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject propBlured;
	private Rigidbody rb;

	private readonly float speed = 30f;
	private Vector3 angle = new(0, 2f, 0);

	private void Start() {
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		MovePlane();

		if (LR_ButtonsScript.lButtonPressed) {
			TurnPlane(-angle);
		}

		if (LR_ButtonsScript.rButtonPressed) {
			TurnPlane(angle);
		}
	}

	private void MovePlane() {
		rb.velocity = -(transform.up) * speed;
	}

	public void TurnPlane(Vector3 angle) {
		transform.Rotate(angle, Space.World);
	}
}