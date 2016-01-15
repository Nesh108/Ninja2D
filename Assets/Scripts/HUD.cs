using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Image HeartUI;

	private Player _player;

	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		
		if (_player == null)
			Debug.LogWarning ("HUD: Player not found. Did you forget setting the tag or the script, mate?");
      
	}

	void Update () {
		HeartUI.sprite = HeartSprites[_player.GetCurrentHearts()];
	}
}
