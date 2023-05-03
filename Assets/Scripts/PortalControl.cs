using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{
    public bool isPlayerHere;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerHere = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject col = other.gameObject;
        if (col.CompareTag("Player"))
        {
            isPlayerHere = true;
            col.GetComponent<PlayerController>().isMoving = false;
        }
    }
}
