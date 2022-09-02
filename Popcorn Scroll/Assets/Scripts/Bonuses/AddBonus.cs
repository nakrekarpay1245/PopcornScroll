using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddBonus : MonoBehaviour
{
    public int addCount;

    public TextMeshProUGUI bonusText;

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        bonusText = GetComponentInChildren<TextMeshProUGUI>();
        bonusText.text = "+" + addCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            collider.enabled = false;
            PlayerCollider.playerCollider.AddCorn(addCount);
            Destroy(gameObject, 0.1f);
        }
    }
}
