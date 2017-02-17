using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {


	private Image pauseMenuBackgroundImage;
	private Button exitGameButton;
	// Use this for initialization
	void Start () {
		this.pauseMenuBackgroundImage = GameObject.Find ("PauseMenuBackground").GetComponent<Image> ();
		this.exitGameButton = GameObject.Find ("ExitToMainButton").GetComponent<Button> ();
		this.exitGameButton.onClick.AddListener (() => exitToMainMenu ());
		this.ChangeVisibility (false);
	}
	
	public void ChangeVisibility(bool visible){
		Color imageColor = this.pauseMenuBackgroundImage.color;
		if (visible) {
			imageColor.a = 1;
			this.exitGameButton.gameObject.SetActive (true);
		} else {
			imageColor.a = 0;
			this.exitGameButton.gameObject.SetActive (false);
		}


		this.pauseMenuBackgroundImage.color = imageColor;
	}

	public void exitToMainMenu(){
		SceneManager.LoadScene ("GameMenu");
	}
}
