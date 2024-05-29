using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Mouvement playerMovement;
    public Jauge_confience jaugeConfience;
    public float powerUpDuration = 5f;
    public float speedMultiplier = 2;
    public float jumpMultiplier = 2; // D�finir jumpMultiplier comme une variable publique

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
        playerMovement.speed *= speedMultiplier; // Mettre � jour la vitesse
        playerMovement.SetInvincible(true, jumpMultiplier); // Activer l'invincibilit� avec le multiplicateur de saut
        StartCoroutine(DeactivatePowerUpAfterDelay(powerUpDuration));
    }

    IEnumerator DeactivatePowerUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        powerUpActive = false;
        playerMovement.speed = originalSpeed; // R�tablir la vitesse initiale
        playerMovement.SetInvincible(false, 1f); // D�sactiver l'invincibilit� et r�tablir le multiplicateur de saut � 1
    }
}