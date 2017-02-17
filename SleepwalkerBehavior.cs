using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepwalkerBehavior : MonoBehaviour {

	private SpriteRenderer sleepwalkerRenderer;
	public Sprite[] spriteSheet;
	private Rigidbody2D sleepwalkerBody;
	private Animator sleeperAnimator;
	private float desiredSpeed;
	//private int counter;
	private int health, maxHealth;
	public float movementX, movementY;
	private int score;
	private bool alive;
	public bool isWalkingLeft, isWalkingRight, isWalkingUp, isWalkingDown;


	void Start () {
		this.spriteSheet = Resources.LoadAll <Sprite>("SleepwalkerSheet");
		Debug.Log (this.spriteSheet.ToString ());
		this.sleepwalkerRenderer = GameObject.Find ("Sleepwalker").GetComponent<SpriteRenderer> ();
		this.sleepwalkerBody = GameObject.Find ("Sleepwalker").GetComponent<Rigidbody2D> ();
		this.sleeperAnimator = GameObject.Find ("Sleepwalker").GetComponent<Animator> ();
		Debug.Log (this.sleeperAnimator.ToString ());
		//this.counter = 0;
		desiredSpeed = 0.05f;
		this.sleeperAnimator.speed = desiredSpeed;
		this.maxHealth = 100;
		this.health = this.maxHealth;
		this.alive = true;
		this.isWalkingDown = false;
		this.isWalkingLeft = false;
		this.isWalkingRight = false;
		this.isWalkingUp = false;
		this.movementX = 0;
		this.movementY = 0;
	}
		

	/*void FixedUpdate(){
		++counter;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (moveHorizontal == 0 && moveVertical == 0) {
			this.sleeperAnimator.Play ("Idle");
		} else if (moveHorizontal <0) {
			this.sleeperAnimator.Play ("WalkLeft");
		} else if (moveHorizontal > 0) {
			this.sleeperAnimator.Play ("WalkRight");
		}

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		this.sleepwalkerBody.velocity = movement;
		if (counter % 20 ==10){
			Debug.Log("Horizontal:"+moveHorizontal);
			Debug.Log("Vertical:" +moveVertical);
		}

	}*/
		
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

	public void ChangeScore(int change){
		this.score += change;
	}

	public void Move(float x, float y){
		this.movementX = x;
		this.movementY = y;
		transform.Translate (x, y, 0);
	}

	public void SetUpwards(bool u){
		this.isWalkingUp = u;
	}

	public void SetDownwards(bool d){
		this.isWalkingDown = d;
	}

	public void SetToLeft(bool l){
		this.isWalkingLeft = l;
	}

	public void SetToRight(bool r){
		this.isWalkingRight = r;
	}

	public int GetHealth(){
		return this.health;
	}

	public bool IsAlive(){
		return this.alive;
	}

	public int GetScore(){
		return this.score;
	}

	/*public void Update(){
		this.sleeperAnimator.SetBool ("isWalkingLeft", this.isWalkingLeft);
		this.sleeperAnimator.SetBool ("isWalkingDown", this.isWalkingDown);
		this.sleeperAnimator.SetBool ("isWalkingRight", this.isWalkingRight);
		this.sleeperAnimator.SetBool ("isWalkingUp", this.isWalkingUp);

	}*/
}