using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// Game controller.
/// </summary>
public class GameController : MonoBehaviour {

	// Use this for initialization

	public SleepwalkerBehavior sleepwalker;
	private PauseMenuScript pauseScript;
	private ButtonScript up, left, right, down;
	private int playerHealth, playerScore, currentLevel;
	private Text scoreText, healthText, levelText;
	private bool newGame=true;
	private Button pauseButton;
	private float movement;
	private bool gamePaused;
	private string filepath;
	private string fileString;
	public Camera mainCamera;
	private Prefabloader prefabloader;
	private List<MapObject> levelmap;
	private Transform homeTransform;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		this.mainCamera.gameObject.SetActive (false);
		this.fileString = Application.persistentDataPath + "/sleepwalkerInfo.data";
		this.newGame = MenuScript.newGame; //get the boolean value from menu wether start new game or load old one.
		Debug.Log ("Is game new game?" + this.newGame);
		this.sleepwalker = GameObject.Find ("Sleepwalker").GetComponent <SleepwalkerBehavior> ();
		this.homeTransform = GameObject.Find ("Home").GetComponent<Transform> ();
		this.prefabloader = new Prefabloader ();

		if (!this.newGame) {
			this.Load ();
		}



		this.pauseScript = GameObject.Find ("PauseMenuCanvas").GetComponent<PauseMenuScript> ();
		this.up = GameObject.Find ("UpButton").GetComponent<ButtonScript> ();
		this.left = GameObject.Find ("LeftButton").GetComponent<ButtonScript> ();
		this.right = GameObject.Find ("RightButton").GetComponent<ButtonScript> ();
		this.down = GameObject.Find ("DownButton").GetComponent<ButtonScript> ();
		this.pauseButton = GameObject.Find ("PauseButton").GetComponent<Button> ();
		this.pauseButton.onClick.AddListener (() => pause ());
		this.scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		this.healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		this.levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		this.movement = 0.2f;
		this.gamePaused = false;
		this.updatePlayerInfo ();
		this.newLevel (this.currentLevel);

	}

	public void newLevel(int currentLevel){
		this.prefabloader.LoadLevel (currentLevel);
		this.levelmap = this.prefabloader.getLevelMap ();
		MapObject mo;
		for (int j = 0; j < levelmap.Count; j++) {
			mo = levelmap [j];
			Instantiate (mo.GetTransform (), mo.GetPositionVector (), Quaternion.identity);
			this.sleepwalker.SetPosition (this.prefabloader.GetPlayerVector ());
			this.homeTransform.position = this.prefabloader.GetExitVector ();
		}
	}

		
	//}
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		if (!this.gamePaused) {
			this.updatePlayerInfo ();
			if (!this.sleepwalker.IsAlive ()) {
				this.sleepwalker.Death ();
				this.mainCamera.gameObject.SetActive (true);
				this.gamePaused = true;
				this.pauseScript.SetMenu (true);
				this.pauseScript.ChangeVisibility (true);
			}
			if (this.up.GetPressed ()) {
				this.sleepwalker.Move (0, this.movement);

			} 

			if (this.down.GetPressed ()) {
				this.sleepwalker.Move (0, -this.movement);

			} 
			if (this.left.GetPressed ()) {
				this.sleepwalker.Move (-this.movement, 0);

			} 

			if (this.right.GetPressed ()) {
				this.sleepwalker.Move (this.movement, 0);

			} 
			if(this.sleepwalker.GetNeedChangeLevel()){
				if (this.prefabloader.GetCurrentLevel () + 1 < this.prefabloader.GetAmountOfLevels ()) {
					this.currentLevel = this.prefabloader.GetNextLevel ();
					this.Save ();
					Debug.Log ("level" + this.currentLevel);
					SceneManager.LoadScene ("MiddleScene");
				} else {
					SceneManager.LoadScene ("EndScene");
				}
			}

		} else {
			if (this.pauseScript.GetIsExiting ()) {
				
					this.Save ();

					SceneManager.LoadScene ("GameMenu");
				
				
			}
		}
						
	}
		
	/// <summary>
	/// Updates the player info.
	/// </summary>
	/// Updates the player health and score Text-objects and Text-object describing the level player is in
	public void updatePlayerInfo (){
		this.scoreText.text = "Score " + this.sleepwalker.GetScore();
		this.healthText.text = "Health " + this.sleepwalker.GetHealth ();
		int representedLevel = this.currentLevel + 1;
		this.levelText.text = "Level " + representedLevel;
	}

	public void pause(){
		if (this.gamePaused == false) {
			this.pauseScript.SetMenu (!this.sleepwalker.IsAlive ());
			this.gamePaused = true;
			this.pauseScript.ChangeVisibility (true);
			Debug.Log ("Paused");
		}
	}

	/// <summary>
	/// Save the player data to file.
	/// </summary>
	public void Save(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (this.fileString);

		SleepwalkerData swdata = new SleepwalkerData ();
		swdata.health = this.sleepwalker.GetHealth();
		swdata.score = this.sleepwalker.GetScore();
		swdata.level = this.currentLevel;

		bf.Serialize (file, swdata);
		file.Close ();
	}

	/// <summary>
	/// Load the player data from file
	/// </summary>
	public void Load(){
		if (File.Exists (this.fileString)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (this.fileString, FileMode.Open);
			Debug.Log (file.ToString ());
			SleepwalkerData swdata = (SleepwalkerData)bf.Deserialize (file);
			this.sleepwalker.setVariables (swdata.health, swdata.score);
			this.currentLevel = swdata.level;
			file.Close ();
		
		}
	}
}

/// <summary>
/// Sleepwalker data.
/// </summary>
/// Stores playerdata to be saved to and loaded from file.
// https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data
[Serializable]
class SleepwalkerData{
	public int health;
	public int score;
	public int level;
}
