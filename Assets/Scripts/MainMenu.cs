using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private Button play, options, quit;
	public Material trapMat, goalMat;
	public Toggle colorblindMode;
	// Use this for initialization
	void Start () {
		play = GameObject.Find("PlayButton").GetComponent<Button>();
		if (play == null)
		{
			Debug.Log("Could not find 'Play' button");
		} else
		{
			play.onClick.AddListener(PlayMaze);
		}
		quit = GameObject.Find("QuitButton").GetComponent<Button>();
		quit.onClick.AddListener(QuitMaze);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayMaze()
	{
		if (colorblindMode == true)
		{
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		}
		Debug.Log("Play button clicked");
		SceneManager.LoadScene("maze");
	}

	void QuitMaze()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}
}
