using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject{

	private Transform transform;
	private Vector3 vector;

	public MapObject(Transform transform, Vector3 vector){
		this.transform = transform;
		this.vector = vector;
	}

	public Transform GetTransform(){
		return this.transform;
	}

	public Vector3 GetVector(){
		return this.vector;
	}
}
