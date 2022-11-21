using UnityEngine;

public class MissileScript : MonoBehaviour {

	public GameObject smokeTrail;
	public GameObject missileExplosion;
	public GameObject planeExplosion;

	private GameObject player;
	private Rigidbody rb;
	private Animator animator;

	public float speed;
	public float rotationSpeed;

	private float startTimerSmokeTrail;
	private float startTimerMissile;

	private void Start() {
		player = GameObject.Find("Player");
		rb = this.GetComponent<Rigidbody>();
		animator = this.GetComponent<Animator>();

		startTimerSmokeTrail = TimerScript.GetTimer();
		startTimerMissile = TimerScript.GetTimer();
	}

	private void FixedUpdate() {
		if (!GameScript.isPaused) {
			MoveForward();
		}
	}

	private void Update() {
		if (!GameScript.isPaused) {
			if (!GameScript.isGameOver) {
				AimToPlayer();
			}

			if (TimerScript.GetTimer() - startTimerSmokeTrail >= 0.05f) {
				InstantiateSmokeTrail();
				startTimerSmokeTrail = TimerScript.GetTimer();
			}

			if (TimerScript.GetTimer() - startTimerMissile >= 20) {
				EndMissile();
			}
		}
	}

	private void MoveForward() {
		rb.velocity = (this.transform.up) * speed;
	}

	private void InstantiateSmokeTrail() {
		Instantiate(smokeTrail, this.transform.position, smokeTrail.transform.rotation);
	}

	private void AimToPlayer() {
		Vector3 direction = (player.transform.position - this.transform.position).normalized;
		float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		Quaternion rotateToTarget = Quaternion.Euler(90, angle, 0);

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);
	}

	private void EndMissile() {
		animator.SetTrigger("endMissile");
		Destroy(this.gameObject, 3f);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Instantiate(missileExplosion, this.transform.position, missileExplosion.transform.rotation);
			Destroy(other.gameObject);
			Destroy(this.gameObject);

			GameScript.AddMissilesDestroyed();
		}
		else if (other.tag == "Player") {
			Destroy(this.gameObject);
			GameScript.isGameOver = true;
		}
	}
}