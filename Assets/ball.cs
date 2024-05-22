using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    public int damageAmount = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            //other.gameObject.GetComponent<CharacterInfo>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Sol"))
        {
            //other.gameObject.GetComponent<CharacterInfo>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

}