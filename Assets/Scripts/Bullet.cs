using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int damage = 1;

	void OnTriggerEnter2D (Collider2D col)
	{
	
		if (!col.isTrigger) {
			if (col.CompareTag ("Player"))
				col.GetComponent<Player> ().DealDamage (damage);

			Destroy (gameObject);
		}

	}
	

}
