using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesFollowPlayer : MonoBehaviour
{
    public Transform player;  // R�f�rence au joueur
    public Transform pigeon;  // R�f�rence au pigeon pour garder les yeux � leur position fixe

    void Update()
    {
        if (player != null)
        {
            // Garder la position des yeux fixe par rapport au pigeon
            transform.position = pigeon.position;

            // Calculer la direction vers le joueur
            Vector2 direction = (player.position - transform.position).normalized;

            // Calculer l'angle bas� sur la direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Appliquer la rotation aux yeux avec un d�calage pour corriger la direction
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        }
    }
}