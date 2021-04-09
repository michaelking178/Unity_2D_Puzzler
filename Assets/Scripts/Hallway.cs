using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    private enum MovementAxis
    {
        Horizontal,
        Vertical
    }

    private enum MoveDirection
    {
        Right,
        Left,
        Up,
        Down
    }

    [SerializeField] private MovementAxis movementAxis;
    private MoveDirection moveDirection;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindObjectOfType<Camera>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player"){
            return;
        }
        PlayerController player = col.gameObject.GetComponent<PlayerController>();
        Vector3 playerPos = col.gameObject.transform.position;
        Vector3 camPos = mainCamera.transform.position;

        if (movementAxis == MovementAxis.Horizontal && playerPos.x < transform.position.x)
        {
            camPos = new Vector3(camPos.x + 17.5f, camPos.y, camPos.z);
            StartCoroutine(player.MoveTo(Vector2.right));
        }
        else if (movementAxis == MovementAxis.Horizontal && playerPos.x > transform.position.x)
        {
            camPos = new Vector3(camPos.x - 17.5f, camPos.y, camPos.z);
            StartCoroutine(player.MoveTo(Vector2.left));
        }
        else if (movementAxis == MovementAxis.Vertical && playerPos.y < transform.position.y)
        {
            camPos = new Vector3(camPos.x, camPos.y + 17.5f, camPos.z);
            StartCoroutine(player.MoveTo(Vector2.up));
        }
        else if (movementAxis == MovementAxis.Vertical && playerPos.y > transform.position.y)
        {
            camPos = new Vector3(camPos.x, camPos.y - 17.5f, camPos.z);
            StartCoroutine(player.MoveTo(Vector2.down));
        }

        mainCamera.GetComponent<CameraPosition>().SetDestination(camPos);
    }
}
