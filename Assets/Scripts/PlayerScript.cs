using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject propBlured;
	private Rigidbody rb;
	private Animator animator;

	private float speed = 35f;
	private Vector3 angle = new(0, 2.5f, 0);

	private void Start() {
		rb = this.GetComponent<Rigidbody>();
		animator = this.GetComponent<Animator>();
	}

	private void FixedUpdate() {
		if (!GameScript.isPaused) {
			MoveForward();
		}

		if (LR_ButtonsScript.lButtonPressed) {
			animator.SetBool("isTurningLeft", true);
			TurnPlane(-angle);
		} else {
			animator.SetBool("isTurningLeft", false);
		}

		if (LR_ButtonsScript.rButtonPressed) {
			animator.SetBool("isTurningRight", true);
			TurnPlane(angle);
		} else {
			animator.SetBool("isTurningRight", false);
		}
	}

	private void MoveForward() {
		rb.velocity = -(this.transform.up) * speed;
	}

	private void TurnPlane(Vector3 angle) {
		this.transform.Rotate(angle, Space.World);
	}
}