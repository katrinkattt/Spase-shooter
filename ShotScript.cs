﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {
	public float speed;
	void Start () {
		GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
	}
	
}
