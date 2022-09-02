using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float rotateSpeed;
    private float rotateX;

    [SerializeField]
    private Joystick rotateJoystick;

    public List<CornContent> cornList;

    public static PlayerRotate playerRotate;

    private void Awake()
    {
        if (!playerRotate)
        {
            playerRotate = this;
        }
    }

    void Update()
    {
        if (Mathf.Abs(rotateX) > 0.25f)
        {
            for (int i = 0; i < cornList.Count; i++)
            {
                cornList[i].LockRigidbody();
            }
        }
        else
        {
            for (int i = 0; i < cornList.Count; i++)
            {
                cornList[i].UnLockRigidbody();
            }
        }
        rotateX = rotateJoystick.Horizontal;

        if (rotateX > 0)
        {
            Manager.manager.StartGame();
        }

        transform.Rotate(0f, rotateX * rotateSpeed * Time.deltaTime, 0f);
    }

    public void SetRotateSpeed(float value)
    {
        rotateSpeed = value;
    }

    public void StartGame()
    {
        SetRotateSpeed(speed);
    }

    public void FinishLevel()
    {
        SetRotateSpeed(0);
    }

    public void AddCorn(CornContent newCorn)
    {
        cornList.Add(newCorn);
    }

    public void RemoveCorn(CornContent newCorn)
    {
        cornList.Remove(newCorn);
    }
}
