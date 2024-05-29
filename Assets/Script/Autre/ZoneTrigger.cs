using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    private ZoneManager zoneManager;
    private bool hasEntered = false; // Assure que la zone ne soit compt�e qu'une fois

    void Start()
    {
        zoneManager = FindObjectOfType<ZoneManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasEntered)
        {
            hasEntered = true; // Marque la zone comme entr�e
            // Appeler la m�thode ZoneEntered dans ZoneManager
            zoneManager.ZoneEntered();
        }
    }
}

