using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fireball behavior.
/// </summary>
/// This behaviour script is attached to fireball prefab.
public class FireballBehavior : MonoBehaviour {

	private Vector3 randomDirection;

	// Use this for initialization
	/// <summary>
	/// Start this instance.
	/// </summary>
	/// In the start the direction of fireball is chose by using random number generation
	void Start () {
		this.randomDirection = Random.onUnitSphere*0.1f;
		this.randomDirection.z = 0;

	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	/// Controlls the movement of fireball:
	void Update(){
		transform.Translate (this.randomDirection);
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll){
		Object.Destroy (gameObject, 0.1f);
	}
}
