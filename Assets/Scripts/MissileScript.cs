using UnityEngine;

public class MissileScript : MonoBehaviour {

	private GameObject player;
	private Rigidbody rb;

	public float speed;
	private float rotationSpeed = 1.2f;

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() {

		rb.velocity = (transform.up) * speed;

		Vector3 direction = (player.transform.position - transform.position).normalized;
		float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		Quaternion rotateToTarget = Quaternion.Euler(90, angle, 0);

		transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);

		Destroy(gameObject, 20f);
	}
}