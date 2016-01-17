using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour
{
	private int _damage;

	void Awake ()
	{
		_damage = gameObject.GetComponentInParent<PlayerAttack> ().damage;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (!col.isTrigger && col.CompareTag ("Enemy"))
			col.SendMessageUpwards ("Damage", _damage);

	}
}
