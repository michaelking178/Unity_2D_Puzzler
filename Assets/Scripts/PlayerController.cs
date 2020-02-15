using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool canControlMovement = true;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    public float speed = 5f;

    [SerializeField] private float raycastDistance = 1.1f;
    
    private Vector2 raycastOffset = new Vector2(0.5f, -0.5f);
    private RaycastHit2D hit;
    private ColorManager colorManager;
    private bool isBeingMoved = false;
    private Vector2 direction;
    private float transitionSpeed = 2f; // For hallway transitions
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorManager = FindObjectOfType<ColorManager>();
    }

    private void Update()
    {
        if (canControlMovement)
        {
            MovementInput();
        }
        else if (isBeingMoved)
        {
            Move(direction);
        }
        
        if (Input.GetButtonUp("Restart"))
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }
    }

    private void MovementInput()
    {
        if (Input.GetButton("Right"))
        {
            Move(Vector2.right);
        }
        else if (Input.GetButton("Left"))
        {
            Move(Vector2.left);
        }
        else if (Input.GetButton("Up"))
        {
            Move(Vector2.up);
        }
        else if (Input.GetButton("Down"))
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

    public IEnumerator MoveTo(Vector2 _direction)
    {
        float defaultSpeed = speed;
        speed = transitionSpeed;
        direction = _direction;

        canControlMovement = false;
        isBeingMoved = true;
        yield return new WaitForSeconds(2f);

        canControlMovement = true;
        isBeingMoved = false;
        speed = defaultSpeed;
    }
}
