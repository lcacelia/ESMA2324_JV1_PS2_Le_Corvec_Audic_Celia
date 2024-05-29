using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seedcollector : MonoBehaviour
{
    private Jauge_confience jaugeConfience;

    void Start()
    {
        jaugeConfience = FindObjectOfType<Jauge_confience>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Seed"))
        {
            jaugeConfience.IncreaseSeedCount();
            Destroy(other.gameObject);
        }
    }
}