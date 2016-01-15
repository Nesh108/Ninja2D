using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{
	
	public int damage = 2;	// How much damage the spikes deal to the player
	public float damageDuration = 0.02f;
	public float damagePower = 350f;
	private Player _player;
	private Vector3 _playerPos;

	void Start ()
	{
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		
		if (_player == null)
			Debug.LogWarning ("Spikes: Player not found. Did you forget setting the tag, mate?");

	}

	void Update ()
	{
		_playerPos = _player.transform.position;
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{

		// If the player is the colliding object, deal dmg to it
		if (col.CompareTag ("Player")) {
			// Knockback player
			StartCoroutine (_player.Knockback (damageDuration, damagePower, _playerPos));

			// Deal damage to player
			_player.DealDamage (damage);
		}
	}
}
