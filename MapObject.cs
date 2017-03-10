using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Map object.
/// </summary>
/// Map object is used to store neseccery information of prefab to be used in level creation.
public class MapObject{

	private Transform transform;
	private Vector3 positionVector;

	/// <summary>
	/// Initializes a new instance of the <see cref="MapObject"/> class.
	/// </summary>
	/// <param name="transform">Transform.</param>
	/// <param name="vector">Vector.</param>
	public MapObject(Transform transform, Vector3 vector){
		this.transform = transform;
		this.positionVector = vector;
	}

	/// <summary>
	/// Gets the transform.
	/// </summary>
	/// <returns>The transform.</returns>
	/// Returns the transform to be placed in the level.
	public Transform GetTransform(){
		return this.transform;
	}

	/// <summary>
	/// Gets the position vector.
	/// </summary>
	/// <returns>The vector.</returns>
	/// Return the position of map object in level.
	public Vector3 GetPositionVector(){
		return this.positionVector;
	}
}
