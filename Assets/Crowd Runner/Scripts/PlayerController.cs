using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header(" Settings ")]
    [SerializeField] private float moveSpeed;

    [Header(" Control ")]
    [SerializeField] private float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        ManageControl();
    }

    private void MoveForward()
    {
        // move player to Z axis.
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        // detect when player tocuhes screen.
        if(Input.GetMouseButtonDown(0))
        {
            //save this position and player position.
            clickedScreenPosition = Input.mousePosition; // position of finger on screen when player taps.
            clickedPlayerPosition = transform.position; // position of character when player taps.
        }
        else if (Input.GetMouseButton(0)) // detect mouse drag.
        {
            // difference between click and current position to move player on x axis.
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;
            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            // prevent player from stopping.
            // get player position of x adn update.
            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;
            transform.position = position;

           // transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;
        }
    }
}
