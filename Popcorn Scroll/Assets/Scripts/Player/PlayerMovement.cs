using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float moveSpeed;

    private Rigidbody rigidbodyComponent;


    public static PlayerMovement playerMovement;
    private void Awake()
    {
        if (!playerMovement)
        {
            playerMovement = this;
        }
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveForward();
    }

    public void MoveForward()
    {
        rigidbodyComponent.velocity = new Vector3(0, 0, moveSpeed * 100 * Time.fixedDeltaTime);
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    public void StartGame()
    {
        SetMoveSpeed(speed);
    }

    public void FinishLevel()
    {
        SetMoveSpeed(0);
    }
}
