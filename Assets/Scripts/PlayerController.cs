using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    public float speed = 1f;

    [SerializeField] private float raycastDistance = 1.1f;
    
    private Vector2 raycastOffset = new Vector2(0.5f, -0.5f);
    private RaycastHit2D hit;
    private ColorManager colorManager;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorManager = FindObjectOfType<ColorManager>();
    }

    private void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        if (Input.GetButton("Right") && canMove)
        {
            Move(Vector2.right);
        }
        else if (Input.GetButton("Left") && canMove)
        {
            Move(Vector2.left);
        }
        else if (Input.GetButton("Up") && canMove)
        {
            Move(Vector2.up);
        }
        else if (Input.GetButton("Down") && canMove)
        {
            Move(Vector2.down);
        }
    }

    private void Move(Vector2 direction)
    {
        Vector2 startPosition = (Vector2)transform.position + raycastOffset;
        hit = Physics2D.Raycast(startPosition, direction, raycastDistance);

        if (hit.collider && hit.collider.tag == "Wall")
        {
            return;
        }
        else if (hit.collider && hit.collider.tag == "Door")
        {
            Door door = hit.collider.gameObject.GetComponent<Door>();
            if (door.color == spriteRenderer.color)
            {
                door.Deactivate();
            }
            else 
            {
                return;
            }
        }
        transform.Translate(direction * speed * Time.smoothDeltaTime);
    }
}
