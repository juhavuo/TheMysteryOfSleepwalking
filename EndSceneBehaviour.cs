using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// End scene behaviour.
/// </summary>
/// End scene is played, when the player has passed all levels.
public class EndSceneBehaviour : MonoBehaviour {

	private Button toMainMenuButton;
	//private Text scoreText; 

	// Use this for initialization
	/// <summary>
	/// Start this instance.
	/// </summary>
	/// Creates the needed UI components in the end scene
	void Start () {
		this.toMainMenuButton = GameObject.Find ("ToMainMenuButton").GetComponent<Button> ();
		//this.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		//this.scoreText.text = "Your final score is " + SleepwalkerBehavior.FinalScore;
		this.toMainMenuButton.onClick.AddListener (() => GoToMainMenu ());
	}
	/// <summary>
	/// Gos to main menu.
	/// </summary>
	/// Change the scene from end scene to main menu scene.
	public void GoToMainMenu(){
		SceneManager.LoadScene("GameMenu");
	}
}
