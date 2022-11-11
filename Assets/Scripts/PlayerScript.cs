using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject propBlured;
	private Rigidbody rb;

	private static float speed = 30f;
	private Vector3 angle = new(0, 2f, 0);

	private void Start() {
		rb = this.GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {
		MoveForward();
	}

	private void Update() {
		if (LR_ButtonsScript.lButtonPressed) {
			TurnPlane(-angle);
		}

		if (LR_ButtonsScript.rButtonPressed) {
			TurnPlane(angle);
		}
	}

	private void MoveForward() {
		rb.velocity = -(this.transform.up) * speed;
	}

	private void TurnPlane(Vector3 angle) {
		this.transform.Rotate(angle, Space.World);
	}

	public static void SetSpeed(float value) {
		speed = value;
	}
}