using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization

	private SleepwalkerBehavior sleepwalker;
	private PauseMenuScript pauseScript;
	private ButtonScript up, left, right, down;
	private int playerHealth, playerScore;
	private Text scoreText, healthText;
	private bool newGame=true;
	private Button pauseButton;
	private float movement;
	private bool gamePaused;
	private string filepath;
	private string fileString;
	public Camera mainCamera;
	private Prefabloader prefabloader;

	void Start () {
		this.mainCamera.gameObject.SetActive (false);
		this.fileString = Application.persistentDataPath + "/sleepwalkerInfo.data";
		this.newGame = MenuScript.newGame; //get the boolean value from menu wether start new game or load old one.
		Debug.Log ("Is game new game?" + this.newGame);
		this.sleepwalker = GameObject.Find ("Sleepwalker").GetComponent <SleepwalkerBehavior> (); 

		if (!this.newGame) {
			this.Load ();
		}
		this.prefabloader = new Prefabloader ();
		this.prefabloader.defineUpperLeftCorner (0, 10);
		this.prefabloader.LoadLevel ("Levels/Test2");

		List<MapObject> levelmap = this.prefabloader.getLevelMap ();
		this.pauseScript = GameObject.Find ("PauseMenuCanvas").GetComponent<PauseMenuScript> ();
		this.up = GameObject.Find ("UpButton").GetComponent<ButtonScript> ();
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
		MapObject mo;
		for (int j = 0; j < levelmap.Count; j++) {
			mo = levelmap [j];
			Debug.Log (mo.ToString ());
			Debug.Log (mo.GetTransform ().ToString ());
			Debug.Log (mo.GetVector ().ToString ());
			Instantiate (mo.GetTransform (), mo.GetVector (), Quaternion.identity);
		}
	}

		/*
		Debug.Log (bushprefab.ToString ());
		for (int y = -4; y < 5; y+=2) {
			
		}
		for (int y = -4; y < 5; y++) {
			Instantiate (gemtransform, new Vector3 (6, y, 0), Quaternion.identity);
		}
		Instantiate (enemytransform, new Vector3 (3, 3, 0), Quaternion.identity);
		for (int x = -4; x < 5; x += 2) {
			Instantiate (bricktransform, new Vector3 (x, -10, 0), Quaternion.identity);
		}*/
	//}
	// Update is called once per frame
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
				
		} else {
			if (this.pauseScript.GetIsExiting ()) {
				this.Save ();
				SceneManager.LoadScene ("GameMenu");
			}
		}
						
	}
		
	/*
	 * Updates score and health of player in screen.
	 */
	public void updatePlayerInfo (){
		this.scoreText.text = "Score " + this.sleepwalker.GetScore();
		this.healthText.text = "Health " + this.sleepwalker.GetHealth ();
	}

	public void pause(){
		if (this.gamePaused == false) {
			this.pauseScript.SetMenu (!this.sleepwalker.IsAlive ());
			this.gamePaused = true;
			this.pauseScript.ChangeVisibility (true);
			Debug.Log ("Paused");
		}
	}

	public void Save(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (this.fileString);

		SleepwalkerData swdata = new SleepwalkerData ();
		swdata.health = this.sleepwalker.GetHealth();
		swdata.score = this.sleepwalker.GetScore();

		bf.Serialize (file, swdata);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (this.fileString)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (this.fileString, FileMode.Open);
			Debug.Log (file.ToString ());
			SleepwalkerData swdata = (SleepwalkerData)bf.Deserialize (file);
			this.sleepwalker.setVariables (swdata.health, swdata.score);
			file.Close ();
		}
	}
}

// https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data
[Serializable]
class SleepwalkerData{
	public int health;
	public int score;
}
