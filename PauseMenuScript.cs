using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {


	public Image pauseMenuBackgroundImage;
	private Button exitGameButton, returnToGameButton;
	private Text pauseMenuText;
	private bool isDeath, isExiting;
	// Use this for initialization
	void Start () {
		this.pauseMenuBackgroundImage = GameObject.Find ("PauseMenuBackground").GetComponent<Image> ();
		this.exitGameButton = GameObject.Find ("ExitToMainButton").GetComponent<Button> ();
		this.returnToGameButton = GameObject.Find ("ReturnToGameButton").GetComponent<Button> ();
		this.pauseMenuText = GameObject.Find ("PauseMenuText").GetComponent<Text> ();
		this.exitGameButton.onClick.AddListener (() => exitToMainMenu ());
		this.returnToGameButton.onClick.AddListener (() => returnToGame (this.isDeath));
		this.ChangeVisibility (false);
		this.isDeath = false;
		this.isExiting = false;
	}
	
	public void ChangeVisibility(bool visible){
		Color imageColor = this.pauseMenuBackgroundImage.color;
		if (visible) {
			imageColor.a = 1;
			this.exitGameButton.gameObject.SetActive (true);
			this.returnToGameButton.gameObject.SetActive (true);
			this.pauseMenuText.enabled = true;
		} else {
			imageColor.a = 0;
			this.exitGameButton.gameObject.SetActive (false);
			this.returnToGameButton.gameObject.SetActive (false);
			this.pauseMenuText.enabled = false;
		}


		this.pauseMenuBackgroundImage.color = imageColor;
	}

	public void SetPauseMenuText(string text){
		this.pauseMenuText.text = text;
	}

	public void SetMenu(bool isDeath){
		this.isDeath = isDeath;
		if (this.isDeath) {
			this.pauseMenuText.text = "You died.";
			this.returnToGameButton.GetComponentInChildren<Text> ().text = "Respawn";
			Debug.Log (isDeath);
		} else {
			this.pauseMenuText.text = "Game paused.";
			this.returnToGameButton.GetComponentInChildren<Text> ().text = "Continue game.";
		}
	}

	public void exitToMainMenu(){
		this.isExiting = true;
	}

	public bool GetIsExiting(){
		return this.isExiting;
	}

	public void returnToGame(bool dead){
		if (dead) {

		}
	}
}
