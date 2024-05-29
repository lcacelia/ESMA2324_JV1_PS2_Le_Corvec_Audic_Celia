using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private bool isFalling = false;
    public float fallDelay = 0.5f;
    
    // Temps avant que la plateforme ne revienne � sa position d'origine
    public float returnDelay = 5.0f;  
    private Vector2 originalPosition;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.bodyType = RigidbodyType2D.Kinematic;
        // Enregistrez la position d'origine de la plateform
        originalPosition = transform.position; 
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isFalling)
            {
                isFalling = true;
                // D�clenchez la chute apr�s un d�lai
                Invoke("StartFalling", fallDelay);  
            }
        }
    }

    void StartFalling()
    {
        // Change le type de corps � Dynamic pour que la plateforme tombe
        rgbd.bodyType = RigidbodyType2D.Dynamic;
       // Commencez la coroutine pour retourner � la position d'origine
        StartCoroutine(ReturnToOriginalPosition());  
    }

    IEnumerator ReturnToOriginalPosition()
    {
        yield return new WaitForSeconds(returnDelay); 

        rgbd.bodyType = RigidbodyType2D.Kinematic;  
        rgbd.velocity = Vector2.zero;  
        transform.position = originalPosition;  // Replacez la plateforme � la position d'origine
        isFalling = false;  // R�initialisez l'�tat de chute
    }
}