using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private Button play, options, quit;
	// Use this for initialization
	void Start () {
		play = GameObject.Find("PlayButton").GetComponent<Button>();
		if (play == null)
		{
			Debug.Log("Could not find 'Play' button");
		} else
		{
			play.onClick.AddListener(PlayButtonClick);
		}
		quit = GameObject.Find("QuitButton").GetComponent<Button>();
		quit.onClick.AddListener(QuitButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayButtonClick()
	{
		Debug.Log("Play button clicked");
		SceneManager.LoadScene("maze");
	}

	void QuitButtonClick()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}
}
