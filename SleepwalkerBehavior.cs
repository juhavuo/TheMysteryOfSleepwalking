using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sleepwalker behavior.
/// </summary>
/// Behaviour script of games main character. 
public class SleepwalkerBehavior : MonoBehaviour {

	private SpriteRenderer sleepwalkerRenderer;
	public Sprite[] spriteSheet;
	private Rigidbody2D sleepwalkerBody;
	//private Animator sleeperAnimator;
	//private float desiredSpeed;
	private Inventory inventory;
	//private int counter;
	private int health, maxHealth;
	public float movementX, movementY;
	private Collectable cup;
	private Collectable key;
	public static int FinalScore;
	private Collectable book;
	private GameObject slotOne;
	private GameObject slotTwo;
	private GameObject slotThree;
	private GameObject slotFour;
	private GameObject slotFive;
	private GameObject slotSix;
	private GameObject slotSeven;
	private int score;
	private bool alive, needChangeLevel, hasKey;

	void Start () {
		this.spriteSheet = Resources.LoadAll <Sprite>("SleepwalkerSheet");
		Debug.Log (this.spriteSheet.ToString ());
		this.sleepwalkerRenderer = GameObject.Find ("Sleepwalker").GetComponent<SpriteRenderer> ();
		this.sleepwalkerBody = GameObject.Find ("Sleepwalker").GetComponent<Rigidbody2D> ();
		//this.sleeperAnimator = GameObject.Find ("Sleepwalker").GetComponent<Animator> ();
		this.inventory = new Inventory (5);
		//Debug.Log (this.sleeperAnimator.ToString ());
		//this.counter = 0;
		//desiredSpeed = 0.05f;
		//this.sleeperAnimator.speed = desiredSpeed;
		this.maxHealth = 100;
		this.health = this.maxHealth;
		this.alive = true;
		//this.isWalkingDown = false;
		//this.isWalkingLeft = false;
		//this.isWalkingRight = false;
		//this.isWalkingUp = false;
		this.movementX = 0;
		this.movementY = 0;
		this.hasKey = false;
		slotOne = GameObject.Find ("SlotOne");
		slotTwo = GameObject.Find ("SlotTwo");
		slotThree = GameObject.Find ("SlotThree");
		slotFour = GameObject.Find ("SlotFour");
		slotFive = GameObject.Find ("SlotFive");
		slotSix = GameObject.Find ("SlotSix");
		slotSeven = GameObject.Find ("SlotSeven");
		slotOne.SetActive (false);
		slotTwo.SetActive (false);
		slotThree.SetActive (false);
		slotFour.SetActive (false);
		slotFive.SetActive (false);
		slotSix.SetActive (false);
		slotSeven.SetActive (false);
	}

	/// <summary>
	/// Changes the health.
	/// </summary>
	/// <param name="change">Change.</param>
	/// Health can't also go below 0. If health goes to 0, bool variable alive is set to false.
	public void ChangeHealth(int change){
		if(this.health+change>this.maxHealth){
			this.health = this.maxHealth;
		}else if(this.health+change <= 0){
			this.health = 0;
			this.alive = false;
		}else{
			this.health += change;
		}
	}

	/// <summary>
	/// Changes the score.
	/// </summary>
	/// <param name="change">Change.</param>
	/// Changes score by amount of parameter. 
	public void ChangeScore(int change){
		this.score += change;
		FinalScore = this.score;
	}

	/// <summary>
	/// Sets the variables.
	/// </summary>
	/// <param name="health">Health.</param>
	/// <param name="score">Score.</param>
	/// Sets the values of health and score. This is needed, when level is loaded from file in Game Controller script.
	public void setVariables(int health, int score){
		this.health = health;
		this.score = score;
	}

	/// <summary>
	/// Move the specified x and y.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// Moves the player by values of x and y given in parameters.
	public void Move(float x, float y){
		this.movementX = x;
		this.movementY = y;
		transform.Translate (x, y, 0);
	}


	/// <summary>
	/// Gets the health.
	/// </summary>
	/// <returns>The health.</returns>
	public int GetHealth(){
		return this.health;
	}

	/// <summary>
	/// Determines whether this instance is alive.
	/// </summary>
	/// <returns><c>true</c> if this instance is alive; otherwise, <c>false</c>.</returns>
	public bool IsAlive(){
		return this.alive;
	}

	/// <summary>
	/// Gets the score.
	/// </summary>
	/// <returns>The score.</returns>
	public int GetScore(){
		return this.score;
	}

	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <param name="position">Position.</param>
	/// Sets the position of player using Vector3 as parameter
	public void SetPosition(Vector3 position){
		transform.position = position;
	}


	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="coll">Coll.</param>
	/// Checs all the collisions and changes score of health of player when needed.
	void OnCollisionEnter2D(Collision2D coll){
		string name = coll.gameObject.name;
		if (name.Contains ("GemPrefab")) {
			this.ChangeScore (20);
			GameObject.Destroy (coll.collider.gameObject);
		}
		if (name.Contains ("SpikebushPrefab")){
			this.ChangeHealth(-50);
		}
		if (name.Contains("EnemyPrefab")){
			this.ChangeHealth(-10);
		}
		if (name.Equals ("sword")) {
			GameObject.Destroy (coll.collider.gameObject);
			SwordScript sword = new SwordScript ();
			this.inventory.AddItemToInventory (sword);
			Debug.Log(slotOne);
			this.slotOne.SetActive (true);
		}
		if (name.Contains ("CupPrefab")) {
			GameObject.Destroy (coll.collider.gameObject);
			this.inventory.AddItemToInventory (cup);
			this.ChangeScore (100);
			this.slotTwo.SetActive (true);
		}
		if (name.Contains ("KeyPrefab")) {
			GameObject.Destroy (coll.collider.gameObject);
			this.inventory.AddItemToInventory (key);
			this.slotThree.SetActive (true);
			this.ChangeScore (50);
			this.hasKey = true;
		}
		if (name.Equals ("book")) {
			GameObject.Destroy (coll.collider.gameObject);
			this.inventory.AddItemToInventory (book);
			this.slotFour.SetActive (true);
		}
		if (name.Equals("Home")){
			this.needChangeLevel = true;
		}
		if (name.Contains ("LockPrefab") && this.hasKey) {
			GameObject.Destroy (coll.collider.gameObject);
		}
		if (name.Contains ("MushroomPrefab")) {
			this.ChangeHealth (20);
			this.ChangeScore (5);
			GameObject.Destroy (coll.collider.gameObject);
		}
		if (name.Contains ("Fireball")){
			this.ChangeHealth(-20);
		}
	}

	/// <summary>
	/// Gives the information to game controller script, when to change level.
	/// </summary>
	/// <returns><c>true</c>, if need change level was gotten, <c>false</c> otherwise.</returns>
	/// If player collides with exit, the bool variable is set to true and by this function the information
	/// is transmitted to game controller script.
	public bool GetNeedChangeLevel(){
		return this.needChangeLevel;
	}

	/// <summary>
	/// Death this instance.
	/// </summary>
	/// boolean isAlive is set to false
	public void Death(){
		this.sleepwalkerBody.gameObject.SetActive (false);
	}


}