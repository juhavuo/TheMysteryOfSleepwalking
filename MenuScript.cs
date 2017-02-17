using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	private Button newGameButton, loadGameButton, optionsButton, exitButton;
	private RawImage openingScreenImage;

	// Use this for initialization
	void Start () {
		this.newGameButton = GameObject.Find ("NewGameButton").GetComponent<Button> ();
		this.newGameButton.onClick.AddListener (() => this.LoadGame ());
		this.exitButton = GameObject.Find ("ExitButton").GetComponent<Button> ();
		this.exitButton.onClick.AddListener (() => this.ExitGame ());
		openingScreenImage = GameObject.Find ("OpeningRawImage").GetComponent<RawImage> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadGame(){
		SceneManager.LoadScene ("GamePlay");
	}

	public void ExitGame(){
		Application.Quit ();
		Debug.Log ("Exit game");
	}
}
