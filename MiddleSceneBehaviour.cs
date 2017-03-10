using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Middle scene behaviour.
/// </summary>
/// The middle scene appears everytime one completes level, unless the level is final one.
/// From the middle scene one can continue to play the next level.
public class MiddleSceneBehaviour : MonoBehaviour {
	
	private Button continueButton;
	private Text storyText;

	/// <summary>
	/// Start this instance.
	/// </summary>
	/// In this script story text is changed when game progresses.
	void Start(){
		
		this.continueButton = GameObject.Find ("ContinueButton").GetComponent<Button> ();
		this.storyText = GameObject.Find ("StoryText").GetComponent<Text> ();
		MenuScript.newGame = false;
		this.continueButton.onClick.AddListener (() => ContinueToNextLevel ());
		if (Prefabloader.story == 1) {
			this.storyText.text = "You have found your way back home." + '\n'
			+ "But you soon find ourself feeling very sleepy..." + '\n'
			+ "Soon you fall asleep..." + '\n'
			+ "and again you start sleepwalking and end up somewhere unknown.";
			
		} else if (Prefabloader.story == 2) {
			this.storyText.text = "Again back home..." + '\n'
			+ "What was this, why did it happen again..." + '\n'
			+ "Hopefully this never gonna happen again..." + '\n'
			+ "But it did...";
		} else if (Prefabloader.story == 3) {
			this.storyText.text = "Now I started to afraid of sleeping..." + '\n'
			+ "Will it happen again?" + '\n'
			+ "Sure it did...";
		} else {
			this.storyText.text = "And it happen again....";
		}
	}

	/// <summary>
	/// Continues to next level.
	/// </summary>
	/// This is used by button in the scene. When the button is pressed, the next level is loaded.
	public void ContinueToNextLevel(){
		SceneManager.LoadScene ("Gameplay");
	}
}