using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints; // Points de passage que la plateforme va suivre
    private int currentWaypointIndex = 0; // Indice du point de passage actuel
    private Transform playerTransform; // Référence au transform du joueur
    private Vector3 lastPosition; // Dernière position de la plateforme
    private bool playerOnPlatform = false; // Indique si le joueur est sur la plateforme

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();

        // Si le joueur est sur la plateforme, le déplacer avec elle
        if (playerOnPlatform && playerTransform != null)
        {
            Vector3 deltaPosition = transform.position - lastPosition;
            playerTransform.position += deltaPosition;
        }

        lastPosition = transform.position;
    }

    void MovePlatform()
    {
        // Déplacer la plateforme vers le prochain point de passage
        transform.position =
Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Vérifier si la plateforme a atteint le point de passage actuel
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            // Passer au point de passage suivant
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le joueur entre en collision avec la plateforme, indiquer qu'il est sur la plateforme
        if (collision.gameObject.CompareTag("Player"))
        {
            playerTransform = collision.transform;
            playerOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Si le joueur quitte la plateforme, indiquer qu'il n'est plus sur la plateforme
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            playerTransform = null;
        }
    }
}