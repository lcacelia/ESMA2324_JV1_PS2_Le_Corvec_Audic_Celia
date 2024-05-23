using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] public Text piece_counter;

    private int piece = 0;

    private Rigidbody2D rbody;
    private BoxCollider col;

    private void Start()
    {
        DontDestroyOnLoad(this);
        rbody = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Collectible"))
        {
            piece += 1;
            piece_counter.text = "" + piece;
            Destroy(other.gameObject);
        }
    }

}
