using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
	
	Transform player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	NavMeshAgent nav;
	
	public int minRange = 15;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent <EnemyHealth>();
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//get the distance from enemey to the player
		float distance = Vector3.Distance(transform.position, player.position);
		
		//If the enemey and the player have health
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && distance < minRange)
		{
			//moves the enemy
			Move();
		}
		else
		{
			nav.enabled = false;
		}
	}
	
	void Move() {
		
		//new destination of the player
		nav.SetDestination(player.position);
	}
}
