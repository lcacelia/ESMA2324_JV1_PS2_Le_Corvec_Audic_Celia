using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vie_degat
    : MonoBehaviour
{
    public int health = 3;
    private Rigidbody2D body;
    private BoxCollider2D col;
    private bool invicible;

    public Image[] hearts;
    public Sprite full_heart;
    public Sprite empty_heart;

    private bool invincible = false;
    void Start()
    {
        DontDestroyOnLoad(this);
        body = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        invicible = false;

    }

    private void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = empty_heart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = full_heart;
        }
    }
    void degat_mechant()
    {
        health -= 1;
        if (health <= 0)
        {
            Die();
        }
    }

    void degat_Boss()
    {
        health -= 2;
        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        body.bodyType = RigidbodyType2D.Static;
        Restart_level();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.gameObject.CompareTag("Mechant"))
            {
                degat_mechant();
            }
            if (collision.gameObject.CompareTag("Boss"))
            {
                degat_Boss();
            }
        }
    }

    private void Restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}