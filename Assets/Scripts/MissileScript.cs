using UnityEngine;

public class MissileScript : MonoBehaviour {

	// GameObjects
	private GameObject player;

	// Pefabs
	public GameObject smokeTrail;
	public GameObject missileExplosion;
	public GameObject planeExplosion;

	// Components
	private Rigidbody rb;
	private Animator animator;

	// Scripts
	private GameScript gameScript;

	public float speed;
	public float rotationSpeed;

	private float startTimerSmokeTrail;
	private float startTimerMissile;

	private void Start() {
		player = GameObject.Find("Player");

		gameScript = GameObject.Find("GameController").GetComponent<GameScript>();

		rb = this.GetComponent<Rigidbody>();
		animator = this.GetComponent<Animator>();

		if (!GameScript.isSFXOn) {
			this.GetComponent<AudioSource>().enabled = false;
		}

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

	private void AimToPlayer() {
		Vector3 direction = (player.transform.position - this.transform.position).normalized;
		float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		Quaternion rotateToTarget = Quaternion.Euler(90, angle, 0);

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);
	}

	private void InstantiateSmokeTrail() {
		Vector3 position = this.transform.position - new Vector3(0, 1, 0);
		Instantiate(smokeTrail, position, smokeTrail.transform.rotation);
	}

	private void EndMissile() {
		animator.SetTrigger("endMissile");
		Destroy(this.gameObject, 3f);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			GameObject explosion = Instantiate(missileExplosion, this.transform.position, missileExplosion.transform.rotation);
			if (!GameScript.isSFXOn) {
				explosion.GetComponent<AudioSource>().enabled = false;
			}
			Destroy(this.gameObject);

			gameScript.AddMissilesDestroyed();
		}
		else if (other.tag == "Player") {
			Destroy(this.gameObject);
			gameScript.GameOver();
		}
	}
}