using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKeeper : MonoBehaviour
{
    private Transform targetTransform;

    [SerializeField]
    private Transform finishLineTransform;
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float followSpeed = 10;

    [SerializeField]
    private float finishSpeed = 10;

    private float speed;

    [SerializeField]
    private Transform bucketTransform;

    public static CameraKeeper cameraKeeper;
    private void Awake()
    {
        if (!cameraKeeper)
        {
            cameraKeeper = this;
        }
        targetTransform = playerTransform;
        speed = followSpeed;
    }

    void LateUpdate()
    {
        Vector3 followPosition = new Vector3(targetTransform.transform.position.x,
            targetTransform.transform.position.y, targetTransform.transform.position.z);

        transform.position = Vector3.Lerp(transform.position,
            followPosition + offset, Time.deltaTime * speed);
    }

    public void FinishLevel()
    {
        transform.LookAt(bucketTransform);
        offset.z = 0;
        speed = finishSpeed;
        targetTransform = finishLineTransform;
        transform.LookAt(bucketTransform);
    }
}
