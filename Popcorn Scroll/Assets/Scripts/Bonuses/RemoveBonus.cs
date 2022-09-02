using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RemoveBonus : MonoBehaviour
{
    public int removeCount;

    public PlayerCollider playerCollider;

    public TextMeshProUGUI bonusText;

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        bonusText = GetComponentInChildren<TextMeshProUGUI>();
        bonusText.text = "-" + removeCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            collider.enabled = false;
            PlayerCollider.playerCollider.RemoveCorn(removeCount);
            Destroy(gameObject, 0.1f);
        }
    }
}
