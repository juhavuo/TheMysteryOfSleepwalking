using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy behaviour.
/// </summary>
/// Controls the movement of snake
public class EnemyBehaviour : MonoBehaviour {


	public float walkSpeed = 2.0f;
	public float wallLeft = 0.0f;
	public float wallRight = 5.0f;
	float walkingDirection = 1.0f;
	Vector3 walkAmount;
	Vector3 position;

	/// <summary>
	/// Start this instance.
	/// </summary>
	/// Set the position of snake at start
	void Start(){
		this.position = transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	/// Snake movement controll
	void Update () {
		

		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		/*if (walkingDirection > 0.0f)
			walkingDirection = -1.0f;
		else if (walkingDirection < 0.0f)
			walkingDirection = 1.0f;*/
		transform.Translate(walkAmount);
	}

	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="coll">Coll.</param>
	/// Make snake to react to walls
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag("wall")){
			transform.position = this.position;
		}

	}






} 