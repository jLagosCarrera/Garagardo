using UnityEngine;
public class BartenderController : MonoBehaviour
{
    Vector2 beerPos;
    public GameObject beer;
    public GameObject dieMenuUI;
    public GameObject pauseButton;
    public static int lifes = 3;
    public static int points = 0;
    public float throwRate = 0.25f;
    float nextBeer = 0.0f;

    private bool hasMoved = false;
    private readonly float[] positions = { -3.5f, -1.5f, 1.5f, 3.5f };
    private int currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        hasMoved = false;
        lifes = 3;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes == 0)
        {
            pauseButton.SetActive(false);
            dieMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

        if (SwipeManager.IsSwipingLeft())
        {
            if (hasMoved)
            {
                if (Time.time > nextBeer)
                {
                    nextBeer = Time.time + throwRate;
                    throwBeer();
                }
            }
        }

        if (SwipeManager.IsSwipingUp())
        {
            SoundManagerController.PlaySound("woosh");
            if (!hasMoved)
            {
                currentPosition = 2;
                transform.position = new Vector2(transform.position.x, positions[currentPosition]);
                hasMoved = true;
                return;
            }

            if (currentPosition < positions.Length - 1)
            {
                currentPosition++;
                transform.position = new Vector2(transform.position.x, positions[currentPosition]);
            }
        }

        if (SwipeManager.IsSwipingDown())
        {
            SoundManagerController.PlaySound("woosh");
            if (!hasMoved)
            {
                currentPosition = 1;
                transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
                hasMoved = true;
                return;
            }

            if (currentPosition > 0)
            {
                currentPosition--;
                transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
            }
        }
    }

    void throwBeer()
    {
        beerPos = transform.position;
        beerPos += new Vector2(-0.3f, 0f);
        Instantiate(beer, beerPos, Quaternion.identity);
        SoundManagerController.PlaySound("beerOpen");
    }
}
