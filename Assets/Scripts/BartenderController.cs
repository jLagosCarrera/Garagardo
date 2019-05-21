using UnityEngine;

public class BartenderController : MonoBehaviour
{
    Vector2 beerPos;
    public GameObject beer;
    public GameObject dieMenuUI;
    public static int lifes = 3;
    public float throwRate = 0.5f;
    float nextBeer = 0.0f;

    private bool hasMoved = false;
    private readonly float[] positions = { -3.5f, -1.5f, 1.5f, 3.5f };
    private int currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        lifes = 3;
        Time.timeScale = 1f;
        SwipeManager.OnSwipeDetected += OnSwipeDetected;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes == 0)
        {
            dieMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnSwipeDetected(Swipe direction, Vector2 swipeVelocity)
    {
        if (!PauseMenu.isGamePaused)
        {
            switch (direction)
            {
                case Swipe.Up:
                    if (!hasMoved)
                    {
                        currentPosition = 2;
                        transform.position = new Vector2(transform.position.x, positions[currentPosition]);
                        hasMoved = true;
                        break;
                    }

                    if (currentPosition < positions.Length - 1)
                    {
                        currentPosition++;
                        transform.position = new Vector2(transform.position.x, positions[currentPosition]);
                    }

                    break;
                case Swipe.Down:
                    if (!hasMoved)
                    {
                        currentPosition = 1;
                        transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
                        hasMoved = true;
                        break;
                    }

                    if (currentPosition > 0)
                    {
                        currentPosition--;
                        transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
                    }

                    break;
                case Swipe.Left:
                    if (hasMoved)
                    {
                        if (Time.time > nextBeer)
                        {
                            nextBeer = Time.time + throwRate;
                            throwBeer();
                        }
                    }
                    break;
            }
        }
    }

    void throwBeer()
    {
        beerPos = transform.position;
        beerPos += new Vector2(-0.3f, 0f);
        Instantiate(beer, beerPos, Quaternion.identity);
    }
}
