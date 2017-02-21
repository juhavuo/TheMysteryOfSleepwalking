using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	// Use this for initialization

	private SleepwalkerBehavior sleepwalker;
	private PauseMenuScript pauseScript;
	private ButtonScript up, left, right, down;
	private int playerHealth, playerScore;
	private Text scoreText, healthText;
	private Button pauseButton;
	private float movement;
	private bool gamePaused;
	void Start () {
		this.sleepwalker = GameObject.Find ("Sleepwalker").GetComponent <SleepwalkerBehavior>();
		this.pauseScript = GameObject.Find ("PauseMenuCanvas").GetComponent<PauseMenuScript> ();
		this.up = GameObject.Find ("UpButton").GetComponent<ButtonScript>();
		this.left = GameObject.Find ("LeftButton").GetComponent<ButtonScript> ();
		this.right = GameObject.Find ("RightButton").GetComponent<ButtonScript> ();
		this.down = GameObject.Find ("DownButton").GetComponent<ButtonScript> ();
		this.pauseButton = GameObject.Find ("PauseButton").GetComponent<Button> ();
		this.pauseButton.onClick.AddListener (() => pause ());
		this.scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		this.healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		this.movement = 0.2f;
		this.gamePaused = false;
		this.updatePlayerInfo ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.gamePaused) {
			this.updatePlayerInfo ();
			if (!this.sleepwalker.IsAlive ()) {
				this.sleepwalker.Death ();
				this.pauseScript.SetPauseMenuText ("You died");
				this.pauseScript.ChangeVisibility (true);
			}
			if (this.up.GetPressed ()) {
				this.sleepwalker.Move (0, this.movement);
				this.sleepwalker.SetUpwards (true);
			} else {
				this.sleepwalker.SetUpwards (false);
			}

			if (this.down.GetPressed ()) {
				this.sleepwalker.Move (0, -this.movement);
				this.sleepwalker.SetDownwards (true);
			} else {
				this.sleepwalker.SetDownwards (false);
			}	
			if (this.left.GetPressed ()) {
				this.sleepwalker.Move (-this.movement, 0);
				this.sleepwalker.SetToLeft (true);
			} else {
				this.sleepwalker.SetToLeft (false);
			}

			if (this.right.GetPressed ()) {
				this.sleepwalker.Move (this.movement, 0);
				this.sleepwalker.SetToRight (true);
			} else {
				this.sleepwalker.SetToRight (false);
			}
				
		}
						
	}

	public void updatePlayerInfo (){
		this.scoreText.text = "Score " + this.sleepwalker.GetScore();
		this.healthText.text = "Health " + this.sleepwalker.GetHealth ();
	}

	public void pause(){
		if(this.sleepwalker.IsAlive()){
			this.pauseScript.SetPauseMenuText ("Game paused");
		}
		if (this.gamePaused == false) {
			this.gamePaused = true;
			this.pauseScript.ChangeVisibility (true);
			Debug.Log ("Paused");
		}
	}
}
