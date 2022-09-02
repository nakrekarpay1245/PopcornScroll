using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DivideBonus : MonoBehaviour
{
    public int divideCount;

    public PlayerCollider playerCollider;

    public TextMeshProUGUI bonusText;

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        bonusText = GetComponentInChildren<TextMeshProUGUI>();
        bonusText.text = "/" + divideCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            collider.enabled = false;
            PlayerCollider.playerCollider.DivideCorn(divideCount);
            Destroy(gameObject, 0.1f);
        }
    }
}
