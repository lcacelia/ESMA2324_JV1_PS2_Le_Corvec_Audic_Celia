using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jauge_confience : MonoBehaviour
{
    public GameObject player;
    public PowerUp powerUp; // Ajout de la référence au script PowerUp
    public Mouvement playerMovement; // Ajout de la référence au script Mouvement
    public List<Image> plantGrowthStages;
    private bool powerActive = false;
    public int maxGrowthStage = 5;
    public int seedsNeededForPowerUp = 4;
    public int seedsCollected = 1;
    public float powerUpDuration = 5f;
    public float jumpMultiplier = 2; // Ajout du jumpMultiplier

    void Start()
    {
        SetPlantGrowthStage(0);
        powerUp = FindObjectOfType<PowerUp>(); // Trouver le script PowerUp dans la scène
        playerMovement = player.GetComponent<Mouvement>(); // Récupérer le script Mouvement du joueur
    }

    void Update()
    {
        if (seedsCollected >= seedsNeededForPowerUp && !powerActive)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ActivatePowerUp();
            }
        }
    }
    void ActivatePowerUp()
    {
        powerActive = true;
        playerMovement.SetInvincible(true, jumpMultiplier); // Utiliser la méthode SetInvincible avec jumpMultiplier
        StartCoroutine(DeactivatePowerUpAfterDelay(powerUpDuration));
        ResetPlantToLevel(0);
    }

    IEnumerator DeactivatePowerUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        powerActive = false;
        playerMovement.SetInvincible(false, 1f); // Rétablir la méthode SetInvincible avec un jumpMultiplier de 1
    }

    public void IncreaseSeedCount()
    {
        seedsCollected++;
        if (seedsCollected <= maxGrowthStage) // Changer le niveau de la plante en fonction du nombre de graines collectées
        {
            SetPlantGrowthStage(seedsCollected - 1);
        }
    }

    public void SetPlantGrowthStage(int stage)
    {
        for (int i = 0; i < plantGrowthStages.Count; i++)
        {
            if (i == stage)
            {
                plantGrowthStages[i].gameObject.SetActive(true);
            }
            else
            {
                plantGrowthStages[i].gameObject.SetActive(false);
            }
        }
    }

    public void ResetPlantToLevel(int level)
    {
        seedsCollected = 0;
        SetPlantGrowthStage(level);
    }
}