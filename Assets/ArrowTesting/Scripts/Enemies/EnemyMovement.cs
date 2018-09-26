﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.
   // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        // if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        // ... set the destination of the nav mesh agent to the player.
        
       

        float distance = Vector3.Distance(transform.position, player.position);
        RaycastHit hit;
        if (distance < 10f)
        {
            nav.SetDestination(player.position);
        } else
        {
            nav.Stop();
        }
        //}
        // Otherwise...
        //else
       // {
            // ... disable the nav mesh agent.
        //    nav.enabled = false;
        //}
    }
}