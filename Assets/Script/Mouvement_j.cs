using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float speed;
    public float jumpForce;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Déplacement horizontal
        float moveInput = Input.GetAxis("Horizontal");
        rgbd.velocity = new Vector2(moveInput * speed, rgbd.velocity.y);

        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rgbd.velocity = new Vector2(rgbd.velocity.x, jumpForce);
        }

        // Vérifier si le joueur est au sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}