using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public int damage = 20;
	public Collider2D attackTrigger;
	
	private bool _attacking = false;
	private float _attackTimer = 0f;
	private float _attackCd = 0.3f;
	private Animator _anim;

	void Awake () {
		_anim = gameObject.GetComponent<Animator>();
		attackTrigger.enabled = false;
	}

	void Update () {
	
		// Check if attack button has been clicked and start cooldown
		if(Input.GetButtonDown("Fire1") && !_attacking)
		{
			_attacking = true;
			_attackTimer = _attackCd;
		}

		if(_attacking){
			if(_attackTimer > 0)
				_attackTimer -= Time.deltaTime;
			else 
				_attacking = false;
		}

		// Activate trigger and notify the animator
		attackTrigger.enabled = _attacking;
		_anim.SetBool("Attacking", _attacking);

	}
}
