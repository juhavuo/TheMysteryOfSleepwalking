using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inventory.
/// </summary>
/// Inventory is not fully implemented in game
public class Inventory{

	private List<Collectable> inventory;
	private int maxSize;

	/// <summary>
	/// Initializes a new instance of the <see cref="Inventory"/> class.
	/// </summary>
	/// <param name="maxSize">Max size.</param>
	public Inventory(int maxSize){
		this.inventory = new List<Collectable> ();
		this.maxSize = maxSize;
	}

	/// <summary>
	/// Adds the item to inventory.
	/// </summary>
	/// <returns><c>true</c>, if item to inventory was added, <c>false</c> otherwise.</returns>
	/// <param name="collectedItem">Collected item.</param>
	public bool AddItemToInventory(Collectable collectedItem){
		if (this.inventory.Count < this.maxSize) {
			this.inventory.Add (collectedItem);
			return true;
		} else {
			return false;
		}
	}

	/// <summary>
	/// Gets the item from list.
	/// </summary>
	/// <returns>The item from list.</returns>
	/// <param name="index">Index.</param>
	public Collectable GetItemFromList(int index){
		return this.inventory [index];
	}

	/// <summary>
	/// Gets the amount of items.
	/// </summary>
	/// <returns>The amount of items.</returns>
	public int GetAmountOfItems(){
		return this.inventory.Count;
	}

}
