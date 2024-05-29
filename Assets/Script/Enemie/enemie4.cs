using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemie4 : MonoBehaviour
{
    public float chargeSpeed = 5f; // Vitesse de charge de la carotte
    public float detectionRange = 10f; // Distance à laquelle la carotte détecte le joueur
    private Transform player; // Référence au joueur
    private Rigidbody2D rb; // Référence au Rigidbody2D de la carotte
    private bool isCharging = false; // Indique si la carotte est en train de charger

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        DetectAndChargePlayer();
    }

    void DetectAndChargePlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && !isCharging)
        {
            isCharging = true; // Commence à charger
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * chargeSpeed, rb.velocity.y); // Charge horizontalement
        }
        else if (distanceToPlayer > detectionRange)
        {
            isCharging = false; // Arrête de charger
            rb.velocity = Vector2.zero; // Arrête la carotte
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Logique pour ce qui se passe lorsque la carotte touche le joueur
            Debug.Log("Carrot hit the player!");
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Arrête de charger lorsqu'elle heurte un obstacle
            isCharging = false;
            rb.velocity = Vector2.zero;
        }
    }
}