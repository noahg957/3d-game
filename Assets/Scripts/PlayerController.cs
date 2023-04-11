using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 100f;   // speed of movement
    public float gridSize = 1f;    // size of the grid
    public float jumpForce = 7f;   // force of jump

    public float rateOfMove = 5;
    private float lastMove = 0;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        // Rotate movement vector to match camera angle
        //direction = Quaternion.Euler(45, 0, 0) * direction;

        // Calculate movement vector
        Vector3 movement = direction * gridSize;

        // Move character
        if ((lastMove + 1 / rateOfMove) < Time.time)
        {
            lastMove = Time.time;
            rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);

        }

        // Jump if space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
