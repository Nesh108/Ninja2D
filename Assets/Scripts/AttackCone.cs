using UnityEngine;
using System.Collections;

public class AttackCone : MonoBehaviour {

	public bool isRight = true;

	private TurretAI _turretAI;

	void Awake () {
		_turretAI = gameObject.GetComponentInParent<TurretAI>();
	}

	void OnTriggerStay2D (Collider2D col) {
		if(col.CompareTag("Player"))
			_turretAI.Attack(isRight);
	}

}
