using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedcollector : MonoBehaviour
{
    private Jauge_confience jaugeConfience;

    void Start()
    {
        jaugeConfience = FindObjectOfType<Jauge_confience>(); // Trouver le script Jauge_confience dans la sc�ne
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seed")) // V�rifier si c'est une graine
        {
            jaugeConfience.CollectSeed(); // Appeler la m�thode CollectSeed du script Jauge_confience
            Destroy(other.gameObject); // D�truire la graine
        }
    }
}
