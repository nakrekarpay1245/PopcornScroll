using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornContent : MonoBehaviour
{
    private GameObject corn;
    private GameObject popCorn;
    [SerializeField]
    private List<GameObject> popCornPrefabs;

    [SerializeField]
    private GameObject explosionParticle;

    [SerializeField]
    private float explosionForce;

    private Rigidbody rigidbodyComponent;

    public bool isExploded;
    public bool isTouching;

    private float xPosition;
    private float zPosition;
    private float yPosition;

    private void Awake()
    {
        corn = transform.GetChild(0).gameObject;
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        xPosition = transform.position.x;

        yPosition = transform.position.y;

        zPosition = Mathf.Clamp(transform.position.z,
            transform.parent.transform.position.z + Random.Range(1, 5),
            transform.parent.transform.position.z + 10);

        transform.position = Vector3.Lerp(transform.position,
            new Vector3(xPosition, yPosition, zPosition), Time.fixedDeltaTime);
    }

    public void LockRigidbody()
    {
        if (isTouching)
        {
            rigidbodyComponent.isKinematic = true;
        }
        else
        {
            UnLockRigidbody();
        }
    }

    public void UnLockRigidbody()
    {
        rigidbodyComponent.isKinematic = false;
    }

    public void Explosion()
    {
        isExploded = true;

        Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 3);

        rigidbodyComponent.AddForce(Vector3.up * Random.Range(50, 100) * explosionForce);

        Destroy(corn);

        popCorn = Instantiate(popCornPrefabs[Random.Range(0, popCornPrefabs.Count)],
            transform.position, Quaternion.identity);

        popCorn.transform.parent = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FireArea"))
        {
            if (!isExploded)
            {
                Explosion();
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Road"))
        {
            isTouching = false;
        }
    }
}
