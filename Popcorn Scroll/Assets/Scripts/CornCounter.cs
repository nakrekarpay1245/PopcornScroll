using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornCounter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            Manager.manager.FinishLevel();
            if (other.gameObject.GetComponent<CornContent>().isExploded)
            {
                Manager.manager.IncreaseExplodedCornCount();
            }
        }
    }
}
