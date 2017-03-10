using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Exit trigger.
/// </summary>
/// Needed only to set position of exit. Most function replaced with functions in sleepwalker behavior
public class ExitTrigger : MonoBehaviour {
	
	/// <summary>
	/// Sets the position.
	/// </summary>
	/// <param name="position">Position.</param>
	/// Sets the position of exit so the place of exit can be defined in level text file.
	public void SetPosition(Vector3 position){
		transform.position = position;
	}
}
