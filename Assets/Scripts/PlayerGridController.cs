using UnityEngine;

public class PlayerGridController : MonoBehaviour
{
    public float speed = 5.0f;
    public float gridSize = 1.0f;

    private Vector3 destination;
    private bool isMoving = false;

    void Update()
    {
        if (!isMoving)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0)
            {
                destination = transform.position + new Vector3(Mathf.Sign(horizontal) * gridSize, 0, 0);
                isMoving = true;
            }
            else if (vertical != 0)
            {
                destination = transform.position + new Vector3(0, 0, Mathf.Sign(vertical) * gridSize);
                isMoving = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

            if (transform.position == destination)
            {
                isMoving = false;
            }
        }
    }
}