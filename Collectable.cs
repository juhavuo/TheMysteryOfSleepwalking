using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Collectable.
/// </summary>
/// Interface for collectable items, underused in current game
public interface Collectable{

	/// <summary>
	/// Use this instance.
	/// </summary>
	void Use ();

	/// <summary>
	/// Collect this instance.
	/// </summary>
	void Collect ();
}
