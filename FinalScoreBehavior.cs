using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Final score behavior.
/// </summary>
/// Inserts text to Text component in end scene
public class FinalScoreBehavior : MonoBehaviour {

	private Text scoreText;

	// Use this for initialization
	/// <summary>
	/// Start this instance.
	/// </summary>
	/// Finds necessary components for showing final score text
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		this.scoreText.text = "Your final score is: " + SleepwalkerBehavior.FinalScore;
	}

}
