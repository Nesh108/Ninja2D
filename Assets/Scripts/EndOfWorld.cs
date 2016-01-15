using UnityEngine;
using System.Collections;

public class EndOfWorld : MonoBehaviour
{
	
	public int damage = int.MaxValue;		// Insta-death if player falls outside the level boundaries
	private Player _player;

	void Start ()
	{
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		
		if (_player == null)
			Debug.LogWarning ("Spikes: Player not found. Did you forget setting the tag, mate?");

	}

	void Update ()
	{

	}
	
	void OnTriggerEnter2D (Collider2D col)
	{

		// If the player is the colliding object, kill player
		if (col.CompareTag ("Player"))
			_player.DealDamage (damage);

	}
}
