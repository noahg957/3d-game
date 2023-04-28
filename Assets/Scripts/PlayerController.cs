using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public bool inHole;

    private KeyCode forwardMovement;
    private KeyCode backwardMovement;
    private KeyCode rightMovement;
    private KeyCode leftMovement;
    private Rigidbody rb;



    public int speed = 300;
    public bool flippedMovement = false;
    private bool isMoving = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rightMovement = KeyCode.UpArrow;
        leftMovement = KeyCode.DownArrow;
        forwardMovement = KeyCode.RightArrow;
        backwardMovement = KeyCode.LeftArrow;

        inHole = false;

        if (flippedMovement)
        {
            KeyCode temp;
            temp = forwardMovement;
            forwardMovement = backwardMovement;
            backwardMovement = temp;
        }

    }

    void Update()
    {
      
        if (isCubeMoving())
        {
            return;
        }
        if (Input.GetKey(rightMovement))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(leftMovement))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKey(forwardMovement))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKey(backwardMovement))
        {
            Move(Vector3.back);
        }
        // Check if cube is still on top of an object
        RaycastHit hit;
        if (!(Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f)))
        {
            // Cube is not on top of an object
            if (rb.isKinematic)
            {
                // If the rigidbody is kinematic, set it to not be kinematic so it  falls
                rb.isKinematic = false;
            }
        }


    }
    void Move(Vector3 direction)
    {
        // Check for collisions before moving
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 1.2f))
        {
            Debug.Log("Collision detected!");
            return;
        }

        // Move the cube if there are no collisions
        StartCoroutine(Roll(direction));
    }
    IEnumerator Roll(Vector3 direction)
    {
        isMoving = true;
        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);
        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }
        isMoving = false;
    }

    public bool isCubeMoving()
    {
        return isMoving;
    }
}