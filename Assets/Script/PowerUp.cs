using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Mouvement playerMovement;
    public Jauge_confience jaugeConfience;
    public float powerUpDuration = 5f;
    public float speedMultiplier = 2;
    public float jumpMultiplier = 2; // Définir jumpMultiplier comme une variable publique

    private bool powerUpActive = false;
    private float originalSpeed;
    private float originalJumpSpeed;

    void Start()
    {
        playerMovement = FindObjectOfType<Mouvement>();
        jaugeConfience = FindObjectOfType<Jauge_confience>();
        originalSpeed = playerMovement.speed;
        originalJumpSpeed = playerMovement.jump_speed;
    }

    void Update()
    {
        if (jaugeConfience.seedsCollected >= jaugeConfience.seedsNeededForPowerUp && !powerUpActive)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                ActivatePowerUp();
            }
        }
    }

    void ActivatePowerUp()
    {
        powerUpActive = true;
        playerMovement.speed *= speedMultiplier; // Mettre à jour la vitesse
        playerMovement.SetInvincible(true, jumpMultiplier); // Activer l'invincibilité avec le multiplicateur de saut
        StartCoroutine(DeactivatePowerUpAfterDelay(powerUpDuration));
    }

    IEnumerator DeactivatePowerUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        powerUpActive = false;
        playerMovement.speed = originalSpeed; // Rétablir la vitesse initiale
        playerMovement.SetInvincible(false, 1f); // Désactiver l'invincibilité et rétablir le multiplicateur de saut à 1
    }
}