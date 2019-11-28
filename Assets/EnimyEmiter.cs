using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyEmiter : MonoBehaviour {

public GameObject asteroid;
public GameObject metall;

public float minDelay;
public float maxDelay;

private float nextSpawn;
public float asteroidCount = 1;
public float asteroidIncrece;
private float nextATime = 0.0f;
public float period = 0.9f;


	void Update () {
		if(Time.time > nextSpawn)
		{
			float maxAsteroid = Random.Range(1, asteroidCount);

			for( int i = 0; i < maxAsteroid; i++)
			{
				float randomXposition = Random.Range(-transform.localScale.x /2, transform.localScale.x / 2);

				Vector3 randomPosition = new Vector3(
					randomXposition, 
					transform.position.y, 
					transform.position.z );
			
				Instantiate(asteroid, randomPosition, Quaternion.identity);
				if(Time.time+2 > nextATime){
					nextATime += period;
					Instantiate(metall, randomPosition, Quaternion.identity);
				}
			}
		asteroidCount += asteroidIncrece;
		nextSpawn += Random.Range(minDelay, maxDelay);
		}
	}
}
