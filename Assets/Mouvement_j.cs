using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float speed;
    public float jump_speed;

    public Transform ground_check;
    public LayerMask ground;

    void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // DEPLACEMENT
        rgbd.velocity = new Vector2 (Input.GetAxis("Horizontal") * speed, rgbd.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            rgbd.velocity = new Vector2(rgbd.velocity.x, jump_speed);
        }
    }
     // Permet de savoir quand le joeur touche le sol
    private bool Grounded(){ return Physics2D.OverlapCircle(ground_check.position, 0.2f, ground); }
}