using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour {
	public float speed;
	public float tilt;
	public float xMax;
	public float xMin; 
	public float zMax;
	public float zMin;


	public GameObject lazerShot;
	public Transform lazerGun;
	public float shotDealy;
	public float nextShot;

	private Rigidbody Ship;

	void Start () 
	{
		Ship = GetComponent<Rigidbody>();
	}
	
	private void Update()
	{
		bool canShoot = Time.time > nextShot;
		// if(Input.GetButton("Fire1") && canShoot)
		if(canShoot)
		{
			nextShot = Time.time + shotDealy;
			Instantiate(lazerShot, lazerGun.position, Quaternion.Euler(0,0,0));
		}
	}


	void FixedUpdate () {

		float moveHorizonal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// Rigidbody ship = GetComponent <Rigidbody>(); //before version
		Ship.velocity = new Vector3(moveHorizonal, 0, moveVertical) * speed;
		
		float xPosition = Mathf.Clamp(Ship.position.x, xMin, xMax);
		float zPosition = Mathf.Clamp(Ship.position.z, zMin, zMax);

		Ship.position = new Vector3(xPosition, 0, zPosition);

		Ship.rotation = Quaternion.Euler(Ship.velocity.z * tilt, 0, -Ship.velocity.x * tilt);
	}
}
