using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge_confience : MonoBehaviour
{
    public Image[] growthStages; // Tableau contenant les images des différentes étapes de croissance
    private int currentStage = 0; // Indice de l'étape actuelle de croissance

    void Start()
    {
        // Désactiver toutes les images sauf la première
        for (int i = 1; i < growthStages.Length; i++)
        {
            growthStages[i].gameObject.SetActive(false);
        }
    }

    public void CollectSeed()
    {
        if (currentStage < growthStages.Length - 1)
        {
            currentStage++; // Passer à l'étape suivante
            UpdateGrowthStage();
        }
    }

    void UpdateGrowthStage()
    {
        // Désactiver toutes les images
        foreach (Image stage in growthStages)
        {
            stage.gameObject.SetActive(false);
        }

        // Activer seulement l'image correspondant à l'étape actuelle
        growthStages[currentStage].gameObject.SetActive(true);
    }
}