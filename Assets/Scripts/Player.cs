using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Player settings
	public float friction = 0.75f;
	public float maxSpeed = 3f;
	public float speed = 50f;
	public float jumpPower = 200f;
	public bool grounded;

	// Player stats
	public int curHealth;
	public int maxHealth = 100;
	public int hpPerHeart = 20;
	public int starsCollected = 0;

	// References
	private Rigidbody2D _rb2d;
	private Animator _anim;
	private bool _canDoubleJump;
	private Animation _playerDamaged;

	void Start ()
	{
		_rb2d = gameObject.GetComponent<Rigidbody2D> ();
		_anim = gameObject.GetComponent<Animator> ();
		_playerDamaged = gameObject.GetComponent<Animation>();

		// Max health at the beginning of the game
		curHealth = maxHealth;
	}

	void Update ()
	{
		float h = Input.GetAxis ("Horizontal");

		_anim.SetBool ("Grounded", grounded);
		_anim.SetFloat ("Speed", Mathf.Abs (_rb2d.velocity.x));

		// Check if player is moving left or right
		if (h < 0f)
			transform.localScale = new Vector3 (-1, 1, 1);
		else if (h > 0f)
			transform.localScale = new Vector3 (1, 1, 1);

		// Handle jumping
		if ((Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Vertical"))) {
			if (grounded) {
				_rb2d.AddForce (Vector2.up * jumpPower);
				_canDoubleJump = true;
			} else {
				if (_canDoubleJump) {
					_canDoubleJump = false;
					_rb2d.velocity = new Vector2 (_rb2d.velocity.x, 0);
					_rb2d.AddForce (Vector2.up * jumpPower / 1.75f);
				}
			}
		}

		// Cap current health
		if (curHealth > maxHealth)
			curHealth = maxHealth;

		CheckDeath ();
	}

	void FixedUpdate ()
	{

		// Calculate and apply fake friction to player movements if not jumping
		if (grounded)
			_rb2d.velocity = new Vector3 (_rb2d.velocity.x * friction, _rb2d.velocity.y, 0.0f);

		// Moving the player
		_rb2d.AddForce (Vector2.right * speed * Input.GetAxis ("Horizontal"));
		
		// Check if velocity is over maxSpeed
		if (_rb2d.velocity.x > maxSpeed)
			_rb2d.velocity = new Vector2 (maxSpeed, _rb2d.velocity.y);
		else if (_rb2d.velocity.x < -maxSpeed)
			_rb2d.velocity = new Vector2 (-maxSpeed, _rb2d.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// If the colliding object is a healing item, use it and destroy it
		if (col.isTrigger){

			if(col.CompareTag ("Healing")){
			
				Heal(col.GetComponent<HealingItem>().healAmount);
				Destroy(col.gameObject);
			}
			else if (col.CompareTag ("Star")){

				// To implement
				starsCollected++;
				Debug.Log ("Got " + starsCollected + " stars!");
				Destroy(col.gameObject);
			}

		}  
	}

	void Heal(int amount){
		curHealth = Mathf.Min(curHealth + amount, 100);
	}

	void Die ()
	{
		// Restart the scene on player's death
		Application.LoadLevel (Application.loadedLevel);
	}

	public void DealDamage (int dmg)
	{
		curHealth -= dmg;
		_playerDamaged.Play("PlayerDamaged");
		CheckDeath ();

	}

	void CheckDeath ()
	{
		if (curHealth <= 0)
			Die ();
	}

	public int GetCurrentHearts ()
	{
		// Make sure current hearts are always non-negative
		return Mathf.Max(curHealth / hpPerHeart, 0);
	}

	public IEnumerator Knockback (float kbDur, float kbPwr, Vector3 kbkDir)
	{

		// Reset timer
		float timer = 0;
	
		while (timer <= kbDur) {

			// Increase timer
			timer += Time.deltaTime;

			// Apply knockback force to the player
			_rb2d.AddForce (new Vector3 (kbkDir.x * - 100, kbkDir.y * kbPwr, transform.position.z));

		}

		yield return 0;
	}
	
}
