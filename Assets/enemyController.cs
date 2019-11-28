using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	public float rotationSpeed;
	public float minSpeed;
	public float maxSpeed;
	public GameObject lazerShotE;
	public Transform lazerGunE;
	public float shotDealy;
	public float nextShot;

	private Rigidbody ShipE;

	void Start () 
	{
		ShipE = GetComponent<Rigidbody>();
	
		// ShipE.angularVelocity = Random.insideUnitSphere * rotationSpeed;

		ShipE.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
		////letit
	}
	
	private void Update()
	{
		bool canShoot = Time.time > nextShot;
		// if(Input.GetButton("Fire1") && canShoot)
		if(canShoot)
		{
			nextShot = Time.time + shotDealy;
			Instantiate(lazerShotE, lazerGunE.position, Quaternion.Euler(0,0,0));
		}
	}


	
}

