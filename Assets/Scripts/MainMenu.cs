using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public GameObject mainMenuUI;


	void Start ()
	{

	}

	void Update () {

	}

	public void NewGame() {
		Application.LoadLevel(1);
	}

	public void Quit() {
		Application.Quit();
	}
}
