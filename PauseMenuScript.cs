using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {


	public Image pauseMenuBackgroundImage;
	private Button exitGameButton;
	private Text pauseMenuText;
	// Use this for initialization
	void Start () {
		this.pauseMenuBackgroundImage = GameObject.Find ("PauseMenuBackground").GetComponent<Image> ();
		this.exitGameButton = GameObject.Find ("ExitToMainButton").GetComponent<Button> ();
		this.pauseMenuText = GameObject.Find ("PauseMenuText").GetComponent<Text> ();
		this.exitGameButton.onClick.AddListener (() => exitToMainMenu ());
		this.ChangeVisibility (false);
	}
	
	public void ChangeVisibility(bool visible){
		Color imageColor = this.pauseMenuBackgroundImage.color;
		if (visible) {
			imageColor.a = 1;
			this.exitGameButton.gameObject.SetActive (true);
			this.pauseMenuText.enabled = true;
		} else {
			imageColor.a = 0;
			this.exitGameButton.gameObject.SetActive (false);
			this.pauseMenuText.enabled = false;
		}


		this.pauseMenuBackgroundImage.color = imageColor;
	}

	public void SetPauseMenuText(string text){
		this.pauseMenuText.text = text;
	}

	public void exitToMainMenu(){
		SceneManager.LoadScene ("GameMenu");
	}
}
