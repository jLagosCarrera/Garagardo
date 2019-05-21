using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public GameObject customerCollider;
    Rigidbody2D rb;
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(0.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "EndCollider")
        {
            SoundManagerController.PlaySound("horn");
            BartenderController.lifes--;
            Destroy(gameObject);
        }
    }
}
