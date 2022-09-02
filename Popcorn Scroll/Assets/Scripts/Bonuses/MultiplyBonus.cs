using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MultiplyBonus : MonoBehaviour
{
    public int multiplyCount;

    public PlayerCollider playerCollider;

    public TextMeshProUGUI bonusText;

    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
        bonusText = GetComponentInChildren<TextMeshProUGUI>();
        bonusText.text = "x" + multiplyCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CornContent"))
        {
            collider.enabled = false;
            PlayerCollider.playerCollider.MultiplyCorn(multiplyCount);
            Destroy(gameObject, 0.1f);
        }
    }
}
