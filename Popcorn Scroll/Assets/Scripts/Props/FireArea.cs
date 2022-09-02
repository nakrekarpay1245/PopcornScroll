using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            // Manager.manager.IncreasePopcornCount();
        }
    }
}
