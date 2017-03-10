using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Button script.
/// </summary>
/// Simple script to keep tract of button, wether it is currently being pressed or not
public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool pressed = false;

	/// <summary>
	/// Raises the pointer down event.
	/// </summary>
	/// <param name="ped">Ped.</param>
	/// If button is pressed boolean isPressed is set to true
	public void OnPointerDown(PointerEventData ped){
		this.pressed = true;
	}

	/// <summary>
	/// Raises the pointer up event.
	/// </summary>
	/// <param name="ped">Ped.</param>
	/// When button is not pressed anymore, value of isPressed returns to false
	public void OnPointerUp(PointerEventData ped){
		this.pressed = false;
	}

	/// <summary>
	/// Gets the pressed.
	/// </summary>
	/// <returns><c>true</c>, if pressed was gotten, <c>false</c> otherwise.</returns>
	/// Returns the information wether button is pressed or not
	public bool GetPressed(){
		return this.pressed;
	}
}