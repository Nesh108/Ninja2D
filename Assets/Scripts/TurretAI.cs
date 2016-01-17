using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour
{
	
	// Integers
	public int curHealth;
	public int maxHealth;
	
	// Floats
	public float distance;				// Distance between player and turret
	public float wakeRange;				// Range inside of which the turret will wake up
	public float shootInterval;
	public float bulletSpeed = 100f;
	public float bulletTimer;			// Bullet cooldown

	// Booleans
	public bool isAwake = false;
	public bool isLookingRight = true;
	
	// References
	public GameObject bullet;
	public Transform shootPointLeft;	// Where the turret will shoot from
	public Transform shootPointRight;	// Same

	private Transform _target;
	private Animator _anim;

	void Awake ()
	{
		_anim = gameObject.GetComponent<Animator> ();
		_target = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Start ()
	{
		curHealth = maxHealth;
	}

	void Update ()
	{
		_anim.SetBool ("Awake", isAwake);
		_anim.SetBool ("LookingRight", isLookingRight);

		// Check if the turret should awake/sleep
		RangeCheck ();

		// Check Player position
		if (_target.position.x > transform.position.x)
			isLookingRight = true;
		else
			isLookingRight = false;

	}

	void RangeCheck ()
	{
		distance = Vector3.Distance (transform.position, _target.transform.position); 

		if (distance <= wakeRange)
			isAwake = true;
		else
			isAwake = false;

	}

	public void Attack (bool attackingRight)
	{

		// Increase timer
		bulletTimer += Time.deltaTime;
	
		if (bulletTimer >= shootInterval) {

			Vector2 bulletDirection = _target.transform.position - transform.position;
			bulletDirection.Normalize ();

			GameObject bulletClone;

			if (!attackingRight)
				// Instantiate a new bullet on the left
				bulletClone = Instantiate (bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
			else 
				// Instantiate a new bullet on the right
				bulletClone = Instantiate (bullet, shootPointRight.transform.position, shootPointLeft.transform.rotation) as GameObject;

			bulletClone.GetComponent<Rigidbody2D> ().velocity = bulletDirection * bulletSpeed;


			// Reset timer
			bulletTimer = 0;
		}
	
	}
}
