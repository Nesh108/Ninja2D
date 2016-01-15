using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	
	public float smoothTimeX;
	public float smoothTimeY;
	public bool isCameraBound;		// is the camera bounded?
	public Vector3 minCameraPos;	// min camera bounds
	public Vector3 maxCameraPos;	// max camera bounds
	private GameObject _player;
	private Vector2 _velocity;

	void Start ()
	{
		_player = GameObject.FindGameObjectWithTag ("Player");

		if (_player == null)
			Debug.LogWarning ("CameraFollow: Player not found. Did you forget setting the tag, mate?");
	}

	void FixedUpdate ()
	{
		float posX = Mathf.SmoothDamp (transform.position.x, _player.transform.position.x, ref _velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, _player.transform.position.y, ref _velocity.y, smoothTimeY);
	
		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (isCameraBound)
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCameraPos.x, maxCameraPos.x),
			                                 Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
			                                 Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
	}
	
	public void SetMinCamPosition ()
	{
		minCameraPos = gameObject.transform.position;
	}
	
	public void SetMaxCamPosition ()
	{
		maxCameraPos = gameObject.transform.position;
	}
}
