using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

	private Player _player;

	void Start(){
		_player = gameObject.GetComponentInParent<Player>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.isTrigger) {
			_player.grounded = true;
		}
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (!col.isTrigger) {
			_player.grounded = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col)
	{
		if (!col.isTrigger) {
			_player.grounded = false;
		}
	}
}
