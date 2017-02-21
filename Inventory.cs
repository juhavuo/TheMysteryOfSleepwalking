using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory{

	private List<Collectable> inventory;
	private int maxSize;

	public Inventory(int maxSize){
		this.inventory = new List<Collectable> ();
		this.maxSize = maxSize;
	}

	public bool AddItemToInventory(Collectable collectedItem){
		if (this.inventory.Count < this.maxSize) {
			this.inventory.Add (collectedItem);
			return true;
		} else {
			return false;
		}
	}
		
	public Collectable GetItemFromList(int index){
		return this.inventory [index];
	}

	public int GetAmountOfItems(){
		return this.inventory.Count;
	}

}
