using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateforme : MonoBehaviour
{
    public float speed; 
    public Transform[] waypoints; // Points de passage que la plateforme va suivre
    private int currentWaypointIndex = 0; // Indice du point de passage actuel

    // Appeler la fonction pour déplacer la plateforme
    void Update()
    {
        MovePlatform(); 
    }

    void MovePlatform()
    {
        // Déplacer la plateforme vers le prochain point de passage
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Vérifier si la plateforme a atteint le point de passage actuel
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            // Passer au point de passage suivant
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Si le joueur est en collision avec la plateforme, le déplacer avec la plateforme
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Si le joueur quitte la plateforme, le détacher de celle-ci
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}