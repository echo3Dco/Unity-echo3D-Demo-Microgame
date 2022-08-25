using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public float PlayerHeightOffset = 15f;

    public bool ManualControl = false;

    private CharacterController _controller;
    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        Move();
    }

    public Transform GetPlayerTransform()
    {
        return transform;
    }

    private void Move()
    {
        if (!ManualControl)
            return;

        moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

        if (Input.GetKey(KeyCode.Space))
        {
            //transform.Translate(Vector3.up * Time.deltaTime * speed);

            moveDirection = new Vector3(moveDirection.x, 1 * speed /2, moveDirection.z);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            //transform.Translate(Vector3.down * Time.deltaTime * speed);

            moveDirection = new Vector3(moveDirection.x, -1 * speed /2, moveDirection.z);
        }


        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        _controller.Move(moveDirection * Time.deltaTime);


        UIManager.Instance.UpdateHeightsHat(transform.position.y, transform.position.y - Random.Range(-1f, -0.1f));
    }

    public void SetPlayerHeight(float height)
    {
        var finalHeight = PlayerHeightOffset + height;

        if (finalHeight < 0)
            finalHeight = 0;

        transform.position = new Vector3(transform.position.x, finalHeight, transform.position.z);
    }

    public void IncreaseOffsetAltitude()
    {
        if (PlayerHeightOffset == 20)
        {
            return;
        }

        PlayerHeightOffset += 1;

        var newHeight = transform.position.y + 1;

        if (newHeight < 0)
            newHeight = 0;

        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }

    public void DecreaseOffsetAltitude()
    {
        if (PlayerHeightOffset == 0)
            return;

        PlayerHeightOffset -= 1;

        var newHeight = transform.position.y - 1;

        if (newHeight < 0)
            newHeight = 0;

        transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
    }
}
