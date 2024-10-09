using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int health = 5;
	public Text scoreText;
	public Text healthText;

	private int score = 0;
	private bool teleportable = true;
	private Rigidbody rb;
	public GameObject WinLoseBG;
	public Text WinLoseText;
	private GameObject teleportEntrance;
	private GameObject teleportExit;
	private GameObject[] objArr;
	private Scene currentScene;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		objArr = GameObject.FindGameObjectsWithTag("Teleporter");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(Vector3.forward * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.D))
		{
			rb.AddForce(Vector3.right * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(Vector3.back * speed - rb.velocity);
		} else if (Input.GetKey(KeyCode.A))
		{
			rb.AddForce(Vector3.left * speed - rb.velocity);
		} else {
			rb.velocity = new Vector3(0, 0, 0);
		}
	}

	void Update() {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			currentScene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(currentScene.name);
		}
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("menu");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Pickup")
		{
			score += 1;
			SetScoreText();
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "Trap")
		{
			health -= 1;
			SetHealthText();
			if (health <= 0)
			{
				WinLoseBG.SetActive(true);
				WinLoseBG.GetComponent<Image>().color = Color.red;
				WinLoseText.text = "Game Over!";
				WinLoseText.color = Color.white;
			}
		}
		if (other.gameObject.tag == "Teleporter" && teleportable == true)
		{
			teleportable = false;
			Debug.Log("Entered Teleporter <" + other.gameObject.name + ">");
			teleportEntrance = other.gameObject;
			teleportExit = FindNextTeleporter(teleportEntrance);
			this.transform.position = new Vector3(
				teleportExit.transform.position.x,
				this.transform.position.y,
				teleportExit.transform.position.z
			);
		}
		if (other.gameObject.tag == "Goal")
		{
			WinLoseBG.SetActive(true);
			WinLoseBG.GetComponent<Image>().color = Color.green;
			WinLoseText.text = "You Win!";
			WinLoseText.color = Color.black;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Teleporter" && other.gameObject != teleportEntrance)
		{
			teleportable = true;
		}
	}

	GameObject FindNextTeleporter(GameObject currentTele)
	{
		int i = 0;
		while (objArr[i].name != currentTele.name)
		{
			i++;
		}
		i++;
		i = i % objArr.Length;
		return objArr[i];
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}

	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}
}
