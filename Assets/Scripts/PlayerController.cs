using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{

    private KeyCode forwardMovement;
    private KeyCode backwardMovement;
    private KeyCode rightMovement;
    private KeyCode leftMovement;


    public int speed = 300;
    public bool flippedMovement = false;
    private bool isMoving = false;


    private void Start()
    {
        rightMovement = KeyCode.UpArrow;
        leftMovement = KeyCode.DownArrow;
        forwardMovement = KeyCode.RightArrow;
        backwardMovement = KeyCode.LeftArrow;

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
            StartCoroutine(Roll(Vector3.right));
        }
        else if (Input.GetKey(leftMovement))
        {
            StartCoroutine(Roll(Vector3.left));
        }
        else if (Input.GetKey(forwardMovement))
        {
            StartCoroutine(Roll(Vector3.forward));
        }
        else if (Input.GetKey(backwardMovement))
        {
            StartCoroutine(Roll(Vector3.back));
        }
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