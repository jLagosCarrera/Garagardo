using UnityEngine;

public class BartenderController : MonoBehaviour
{
    private bool hasMoved = false;
    private readonly float[] positions = { -3.5f, -1.5f, 1.5f, 3.5f };
    private int currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        SwipeManager.OnSwipeDetected += OnSwipeDetected;
    }

    // Update is called once per frame
    void Update()
    {

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
                        transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
                        hasMoved = true;
                        break;
                    }

                    if (currentPosition < positions.Length - 1)
                    {
                        currentPosition++;
                        transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
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
                default:
                    //Do nothing hehe
                    break;
            }
        }
    }
}
