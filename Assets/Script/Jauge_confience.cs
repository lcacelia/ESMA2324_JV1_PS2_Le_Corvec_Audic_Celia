using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge_confience : MonoBehaviour
{
    public Image[] growthStages; // Tableau contenant les images des diff�rentes �tapes de croissance
    private int currentStage = 0; // Indice de l'�tape actuelle de croissance

    void Start()
    {
        // D�sactiver toutes les images sauf la premi�re
        for (int i = 1; i < growthStages.Length; i++)
        {
            growthStages[i].gameObject.SetActive(false);
        }
    }

    public void CollectSeed()
    {
        if (currentStage < growthStages.Length - 1)
        {
            currentStage++; // Passer � l'�tape suivante
            UpdateGrowthStage();
        }
    }

    void UpdateGrowthStage()
    {
        // D�sactiver toutes les images
        foreach (Image stage in growthStages)
        {
            stage.gameObject.SetActive(false);
        }

        // Activer seulement l'image correspondant � l'�tape actuelle
        growthStages[currentStage].gameObject.SetActive(true);
    }
}