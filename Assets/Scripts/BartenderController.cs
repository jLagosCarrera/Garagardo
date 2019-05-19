using UnityEngine;

public class BartenderController : MonoBehaviour
{
    private bool hasMoved = false;
    private readonly float[] positions = { -5.5f, -2.5f, 2.5f, 5.5f };
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
        float tileHeight;

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

                break;
            case Swipe.Down:
                if (!hasMoved)
                {
                    currentPosition = 1;
                    transform.position = new Vector3(transform.position.x, positions[currentPosition], transform.position.z);
                    hasMoved = true;
                    break;
                }

                break;
            default:
                //Do nothing hehe
                break;
        }
    }
}
