using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseUI;

	private bool _paused = false;

	void Start ()
	{
		// disable the pause menu
		pauseUI.SetActive(false);

	}

	void Update () {
		if(Input.GetButtonDown("Pause"))
			_paused = !_paused;

		pauseUI.SetActive(_paused);
	
		// pause game if needed
		if(_paused)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}

	public void Resume() {
		_paused = false;
	}

	public void Restart() {
		// Load the same level again
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenu() {
		Application.LoadLevel(0);
	}

	public void Quit() {
		Application.Quit();
	}
}
