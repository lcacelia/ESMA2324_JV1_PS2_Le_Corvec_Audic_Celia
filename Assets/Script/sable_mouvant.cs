using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sable_mouvant : MonoBehaviour
{
    public float fallForce = 10f; // Force appliqu�e si le joueur ne saute pas
  

    // Fonction appel�e lorsque le joueur entre en collision avec le sable mouvant
    void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifier si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // R�cup�rer le composant Rigidbody2D du joueur
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            // Si le joueur ne saute pas
            if (!Input.GetButton("Jump"))
            {
                // Appliquer une force vers le bas sur le joueur pour simuler la chute
                playerRigidbody.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);

                
            }
        }
    }
}