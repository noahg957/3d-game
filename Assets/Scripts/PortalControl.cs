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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            isPlayerHere = true;
        }
    }
}
