﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;

	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		setCountText ();
		winText.text = "";
	}
	void FixedUpdate()
    {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 mouvment = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (mouvment * speed);
    }

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp")) {
			
			other.gameObject.SetActive (false);
			count++;
			setCountText();

		}
	}
	void setCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 13) 
		{
			winText.text = "YOU WIN";
		}


	}
}