using UnityEngine;

public class MissileScript : MonoBehaviour {

	public GameObject smokeTrail;
	public GameObject missileExplosion;
	public GameObject planeExplosion;
	private GameObject player;
	private Rigidbody rb;
	private Animator animator;

	private int timerInicial;
	public float speed;
	private float rotationSpeed = 1.2f;
	private float time = 0f;


	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody>();

		animator = GetComponent<Animator>();

		timerInicial = TimerScript.GetTimer();
	}

	private void FixedUpdate() {

		rb.velocity = (transform.up) * speed;

		InstantiateSmokeTrail();

		Vector3 direction = (player.transform.position - transform.position).normalized;
		float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		Quaternion rotateToTarget = Quaternion.Euler(90, angle, 0);

		transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);

		if (TimerScript.GetTimer() - timerInicial > 20f) {
			animator.SetBool("EndMissile", true);
			Destroy(gameObject, 3f);
		}
	}

	private void InstantiateSmokeTrail() {
		time += Time.deltaTime;
		if (time > 0.1f) {
			Instantiate(smokeTrail, transform.position, smokeTrail.transform.rotation);
			time = 0f;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Instantiate(missileExplosion, transform.position, missileExplosion.transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);

			GameScript.AddPoints(5);
		}
		else if (other.tag == "Player") {
			PlayerScript.SetSpeed(1f);
			Instantiate(planeExplosion, player.transform.position, planeExplosion.transform.rotation);
			Destroy(gameObject);
			Destroy(other.gameObject, 2f);

			GameScript.GameOver();
		}
	}
}