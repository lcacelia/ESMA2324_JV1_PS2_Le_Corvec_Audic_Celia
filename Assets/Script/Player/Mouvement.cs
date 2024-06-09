using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float speed;
    public float jump_speed;
    public float invincibleSpeed;
    private bool isInvincible = false;
    public Animator animator;

    public Transform ground_check;
    public LayerMask ground;

    private float originalJumpSpeed;

    void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
        originalJumpSpeed = jump_speed;
    }

    void Update()
    {
        // DEPLACEMENT
        float currentHorizontalInput = Input.GetAxis("Horizontal");
        float currentSpeed = isInvincible ? invincibleSpeed : speed;
        rgbd.velocity = new Vector2(currentHorizontalInput * currentSpeed, rgbd.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rgbd.velocity = new Vector2(rgbd.velocity.x, jump_speed);
            animator.SetBool("isJumping", true);
        }

        // Vérifie si le joueur touche le sol pour arrêter l'animation de saut
        if (Grounded())
        {
            animator.SetBool("isJumping", false);
        }

        animator.SetFloat("SPEED", Mathf.Abs(currentHorizontalInput));
    }

    public void SetInvincible(bool value, float jumpMultiplier)
    {
        isInvincible = value;
        if (isInvincible)
        {
            jump_speed *= jumpMultiplier; // Multiplier la hauteur de saut lorsque le joueur est invincible
        }
        else
        {
            jump_speed = originalJumpSpeed; // Rétablir la hauteur de saut initiale lorsque le joueur n'est plus invincible
        }
    }

    // Permet de savoir quand le joueur touche le sol
    private bool Grounded() { return Physics2D.OverlapCircle(ground_check.position, 0.2f, ground); }
}