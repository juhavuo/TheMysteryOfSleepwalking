using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Pause menu script.
/// </summary>
/// Handles the pause menu in game
public class PauseMenuScript : MonoBehaviour {


	public Image pauseMenuBackgroundImage;
	private Button exitGameButton, returnToGameButton;
	private Text pauseMenuText;
	private bool isDeath, isExiting;
	// Use this for initialization
	/// <summary>
	/// Sets the parameters of menu
	/// </summary>
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

	/// <summary>
	/// Changes the visibility of menu
	/// </summary>
	/// <param name="visible">If set to <c>true</c> visible.</param>
	/// From this one can show or hide pausemenu
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

	/// <summary>
	/// Sets the pause menu text.
	/// </summary>
	/// <param name="text">Text.</param>
	/// Set the text of the pause menu
	public void SetPauseMenuText(string text){
		this.pauseMenuText.text = text;
	}

	/// <summary>
	/// Sets the menu.
	/// </summary>
	/// <param name="isDeath">If set to <c>true</c> is death.</param>
	/// Changes settings of the menu, debending the reason for menu to show up
	/// In case of death shows text You died, in case of pause shows text Game Paused.
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

	/// <summary>
	/// Exits to main menu.
	/// </summary>
	public void exitToMainMenu(){
		this.isExiting = true;
	}

	/// <summary>
	/// Gets the is exiting.
	/// </summary>
	/// <returns><c>true</c>, if is exiting was gotten, <c>false</c> otherwise.</returns>
	/// This is the way to tell to game controller, that it is time to exit to main menu
	public bool GetIsExiting(){
		return this.isExiting;
	}

	public void returnToGame(bool dead){
		if (dead) {

		}
	}
}
