using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	private Button newGameButton, loadGameButton, optionsButton, exitButton;
	private RawImage openingScreenImage;
	public static bool newGame; //To pass information to different scene, wether load game from file or set a new one.

	// Use this for initialization
	void Start () {
		this.newGameButton = GameObject.Find ("NewGameButton").GetComponent<Button> ();
		this.newGameButton.onClick.AddListener (() => this.StartGame (true));
		this.loadGameButton = GameObject.Find ("LoadGameButton").GetComponent<Button> ();
		this.loadGameButton.onClick.AddListener (() => this.StartGame (false));
		this.exitButton = GameObject.Find ("ExitButton").GetComponent<Button> ();
		this.exitButton.onClick.AddListener (() => this.ExitGame ());
		openingScreenImage = GameObject.Find ("OpeningRawImage").GetComponent<RawImage> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*
	 * Loads gameplay-scene. With bool parameter one can specify whether new game will be started or old one loaded.
	 */
	public void StartGame(bool startNew){
		newGame = startNew;
		SceneManager.LoadScene ("Gameplay");

	}

	public void ExitGame(){
		Application.Quit ();
		Debug.Log ("Exit game");
	}
}
