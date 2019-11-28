using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScriptt : MonoBehaviour {
	public float rotationSpeed;
	public float minSpeed;
	public float maxSpeed;

	public GameObject explosion;
	public GameObject explosionPlyer;
	void Start () {
		Rigidbody asteroid = GetComponent<Rigidbody>();
		asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

		asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

	}
	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "gameArea" || other.tag == "asteroid" || other.tag == "metall"){
			return;
		}
		if(other.tag == "Player"){
			Instantiate(explosionPlyer, other.transform.position, other.transform.rotation);
		}
		if(other.tag == "lazer"){
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
		Destroy(other.gameObject);
	}
}
