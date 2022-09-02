using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            PlayerCollider.playerCollider.RemoveCorn(other.gameObject.GetComponent<CornContent>());
        }
    }
}
