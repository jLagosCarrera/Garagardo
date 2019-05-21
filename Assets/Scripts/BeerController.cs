using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerController : MonoBehaviour
{
    public GameObject beerCollider;
    public float velX = -5f;
    float velY = 0f;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "BeerCollider")
        {
            BartenderController.lifes--;
            Destroy(gameObject);
        }
    }
}
