using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool pressed = false;


	public void OnPointerDown(PointerEventData ped){
		this.pressed = true;
	}

	public void OnPointerUp(PointerEventData ped){
		this.pressed = false;
	}

	public bool GetPressed(){
		return this.pressed;
	}
}